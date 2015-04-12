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
        UnitInit();
        WorkerInit();
    }
    
    private void WorkerInit() {
    	mass = 0;
    	maxMass = unitCapacity;
    }
    
    private void Start() {
        
    }
    
    private void Update() {
        
    }
}
