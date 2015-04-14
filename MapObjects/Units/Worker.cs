using UnityEngine;
using System.Collections;

public class Worker : Unit {
    
	//Inspector fields
	public int unitCapacity, foodPerTick;
	
	//Private fields
	private int mass, maxMass, foodRate;
	private Factory deposit;
	private GameObject buildingPrefab;
	private float lastAte;
	
	//Public properties
	public int Mass {
		get { return mass; }
		private set { mass = value; }
	}
	public int MaxMass {
		get { return maxMass; }
		private set { maxMass = value; }
	}
	public int FoodRate {
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
    	foodRate = foodPerTick;
    	tag = "Worker";
    	deposit = null;
    	buildingPrefab = null;
    	lastAte = Time.time;
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
			Debug.Log(m.Tag);
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
    		if ((targetObject as MassDeposit).Current == 0) {
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
    		if (!Move()) {
				(deposit as Factory).DepositMass(mass);
				task = "mine";
				targetPosition = NextTo(targetObject.position);
    		}
    	}
    	else if (task == "deposit") {
			if (!Move()) {
				(targetObject as Factory).DepositMass(mass);
				SetTask("none", position);
    		}
    	}
    	else if (task == "build") {
    		if (!MoveNextTo()) {
    			//**Ensure that we can build this, check with game manager and subtract cost of the building
    			Building b = (Instantiate(buildingPrefab) as GameObject).GetComponent<Building>();
    			b.position = targetPosition;
    		}
    	}
    }
    
    
    
    private void Update() {
    	if (on) {
        	PerformTask();
        }
        if (Time.time > lastAte + 1) {
        	//Eat food from game manager or die
        	lastAte++;
        }
    }
}
