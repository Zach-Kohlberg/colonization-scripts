using UnityEngine;
using System.Collections;

public class Worker : Unit {
	
	//Private fields
	private float mass;
	private MapObject deposit;
	private GameObject buildingPrefab;
	private float lastTick;
	
	//Public properties
	public float Mass {
		get { return mass; }
		private set { mass = value; }
	}
	public float MaxMass {
		get { return manager.Stat(tag+"MaxMass"); }
	}
	new public float FoodRate {
		get { return (On)?manager.Stat(tag+"FoodRate"):0; }
	}
	public float MineRate {
		get { return (On)?manager.Stat(tag+"MineRate"):0; }
	}
    
    private void Awake() {
        WorkerInit();
    }
    
	private void WorkerInit() {
		UnitInit();
    	mass = 0;
    	tag = "Worker";
    	deposit = null;
    	buildingPrefab = null;
		lastTick = Time.time;
    }
    
    private bool Move() {
    	if (Vector2.Distance(position,targetPosition) <= Speed) {
    		position = targetPosition;
    		return false;
    	}
    	else {
    		position += (Vector3)Vector2.ClampMagnitude(targetPosition - (Vector2)position,Speed);
    		return true;
    	}
    }
    
    private bool MoveNextTo() {
		if (Vector2.Distance(position,NextTo(targetPosition)) <= Speed) {
			position = NextTo(targetPosition);
			return false;
		}
		else {
			position += (Vector3)Vector2.ClampMagnitude(targetPosition - (Vector2)position,Speed);
			return true;
		}
    }
    
    private MapObject NearestDepot() {
    	MapObject depot = null;
		GameObject[] go = GameObject.FindGameObjectsWithTag("MapObject");
		foreach (GameObject g in go) {
			MapObject m = g.GetComponent<MapObject>();
			if (m.Tag == "Factory" || m.Tag == "Base") {
				if (depot == null || Vector2.Distance(position,m.position) < Vector2.Distance(position,depot.position)) {
					depot = m;
				}
			}
		}
		return depot;
    }
    
    protected override void TaskSet() {
    	if (task != "mine") {
    		deposit = null;
    	}
    }
    
    public void Build(GameObject building, Vector2 pos) {
		buildingPrefab = building;
		SetTask("build", pos);
    }
    
    private void PerformTask() {
    	if (task == "move") {
			if (!Move()) {
				SetTask("none", position);
    		}
    	}
    	else if (task == "mine") {
			if (targetObject == null || (targetObject as MassDeposit).Current == 0) {
    			if (mass > 0) {
    				SetTask("deposit", NearestDepot());
    			}
    			else {
    				SetTask("none", position);
    			}
    		}
    		else if (!Move()) {
				mass += (targetObject as MassDeposit).Mine(Mathf.Min(MaxMass-mass,MineRate*Time.deltaTime));
				if (mass >= MaxMass) {
					deposit = NearestDepot();
	    			task = "mine-deposit";
	    			targetPosition = NextTo(deposit.position);
    			}
    		}
    	}
    	else if (task == "mine-deposit") {
			if (deposit == null) {
				SetTask("none", position);
			}
    		else if (!Move()) {
				if (deposit.Tag == "Factory") {
					(deposit as Factory).DepositMass(mass);
				}
				else {
					(deposit as Base).DepositMass(mass);
				}
				mass = 0;
				task = "mine";
				if (targetObject == null) {
					SetTask("none", position);
				}
				else {
					targetPosition = NextTo(targetObject.position);
				}
    		}
    	}
    	else if (task == "deposit") {
			if (targetObject == null) {
				SetTask("none", position);
			}
			else if (!Move()) {
				if (deposit.Tag == "Factory") {
					(deposit as Factory).DepositMass(mass);
				}
				else {
					(deposit as Base).DepositMass(mass);
				}
				mass = 0;
				SetTask("none", position);
    		}
    	}
    	else if (task == "build") {
    		if (!MoveNextTo()) {
    			Building b = (Instantiate(buildingPrefab, position, transform.rotation) as GameObject).GetComponent<Building>();
    			if (manager.SpendMass(manager.GetCost(b.Tag))) {
	    			b.position = targetPosition;
	    			SetTask("none", position);
    			}
    			else {
    				Destroy(b.gameObject);
    			}
    		}
    	}
    }
    
    private void Update() {
    	if (on) {
			PerformTask();
            Debug.Log("Worker Update");
			if (Time.time > lastTick + 1) {
				if (!manager.SpendFood(-FoodRate*Time.deltaTime)) {
					Kill();
				}
				lastTick++;
			}
        }
    }
}
