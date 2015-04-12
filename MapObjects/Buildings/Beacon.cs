using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Beacon : Building {
	
	//Inspector fields
	public float beaconRadius, powerPerTick;
	
	//Private fields
	private float radius, powerRate;
	
	//Public properties
	public float Radius {
		get { return radius; }
		private set { radius = value; }
	}
	
	public float PowerRate {
		get { return powerRate; }
		private set { powerRate = value; }
	}
	
	private void Awake() {
		BuildingInit();
        BeaconInit();
    }
    
    private void BeaconInit() {
    	radius = beaconRadius;
    	powerRate = powerPerTick;
    }
    
    private void Start() {
        
    }
    
    private void Update() {
        
    }
}
