using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Worker : Unit {
    
	//Inspector fields
	public float unitCapacity;
	
	//Private fields
	private float mass, maxMass;
	
	//Public properties
	public float Mass {
		get { return mass; }
		private set { mass = value; }
	}
	public float MaxMass {
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
    
    private void PerformTask() {
    	if (task == "move") {
    		if (!Move()) {
    			task = "none";
    		}
    	}
    }
    
    private void Update() {
        PerformTask();
    }
}
