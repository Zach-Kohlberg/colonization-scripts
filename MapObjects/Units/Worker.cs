using UnityEngine;
using System.Collections;

public class Worker : Unit {
    
	//Inspector fields
	public int unitCapacity, foodPerSec;
	
	//Private fields
	private float mass, maxMass, foodRate;
	private Factory deposit;
	private GameObject buildingPrefab;
	private float lastTick;
	
	//Public properties
	public float Mass {
		get { return mass; }
		private set { mass = value; }
	}
	public float MaxMass {
		get { return maxMass; }
		private set { maxMass = value; }
	}
	public float FoodRate {
		get { return foodRate; }
		private set { foodRate = value; }
	}
    
    private void Awake() {
        WorkerInit();
    }
    
	private void WorkerInit() {
		UnitInit();
    	mass = 0;
    	maxMass = unitCapacity;
    	foodRate = foodPerSec;
    	tag = "Worker";
    	deposit = null;
    	buildingPrefab = null;
		lastTick = Time.time;
    }
    
    private bool Move() {
    	if (Vector2.Distance(position,targetPosition) <= speed) {
    		position = targetPosition;
    		return false;
    	}
    	else {
    		position += (Vector3)Vector2.ClampMagnitude(targetPosition - (Vector2)position,speed);
    		return true;
    	}
    }
    
    private bool MoveNextTo() {
		if (Vector2.Distance(position,NextTo(targetPosition)) <= speed) {
			position = NextTo(targetPosition);
			return false;
		}
		else {
			position += (Vector3)Vector2.ClampMagnitude(targetPosition - (Vector2)position,speed);
			return true;
		}
    }
    
    private Factory NearestFactory() {
    	Factory f = null;
		GameObject[] go = GameObject.FindGameObjectsWithTag("MapObject");
		foreach (GameObject g in go) {
			MapObject m = g.GetComponent<MapObject>();
			if (m.Tag == "Factory") {
				if (f == null || Vector2.Distance(position,m.position) < Vector2.Distance(position,f.position)) {
					f = m as Factory;
				}
			}
		}
		return f;
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
    				SetTask("deposit", NearestFactory());
    			}
    			else {
    				SetTask("none", position);
    			}
    		}
    		else if (!Move()) {
				mass += (targetObject as MassDeposit).Mine(maxMass-mass);
				deposit = NearestFactory();
    			task = "mine-deposit";
    			targetPosition = NextTo(deposit.position);
    		}
    	}
    	else if (task == "mine-deposit") {
			if (deposit == null) {
				SetTask("none", position);
			}
    		else if (!Move()) {
				(deposit as Factory).DepositMass(mass);
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
				(targetObject as Factory).DepositMass(mass);
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
				if (!manager.SpendFood(foodRate*Time.deltaTime)) {
					//Kill();
				}
				lastTick++;
			}
        }
    }
}
