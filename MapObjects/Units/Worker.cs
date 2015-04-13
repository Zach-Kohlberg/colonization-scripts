using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Worker : Unit {
    
	//Inspector fields
	public int unitCapacity;
	
	//Private fields
	private int mass, maxMass;
	private Factory deposit;
	
	//Public properties
	public int Mass {
		get { return mass; }
		private set { mass = value; }
	}
	public int MaxMass {
		get { return maxMass; }
		private set { maxMass = value; }
	}
    
    private void Awake() {
        WorkerInit();
    }
    
	private void WorkerInit() {
		UnitInit();
    	mass = 0;
    	maxMass = unitCapacity;
    	tag = "Worker";
    	deposit = null;
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
    	if (task == "mine") {
    		deposit = NearestFactory();
    	}
    	else {
    		deposit = null;
    	}
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
    			task = "mine-deposit";
    			targetPosition = NextTo(deposit);
    		}
    	}
    	else if (task == "mine-deposit") {
    		if (!Move()) {
				(deposit as Factory).DepositMass(mass);
				task = "mine";
				targetPosition = NextTo(targetObject);
    		}
    	}
    	else if (task == "deposit") {
			if (!Move()) {
				(targetObject as Factory).DepositMass(mass);
				SetTask("none", position);
    		}
    	}
    }
    
    private void Update() {
        PerformTask();
    }
}
