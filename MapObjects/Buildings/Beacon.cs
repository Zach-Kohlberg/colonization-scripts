using UnityEngine;
using System.Collections;

public class Beacon : Building {
	
	//Inspector fields
	public float beaconRadius;
	public float powerPerSec;
	
	//Private fields
	private float radius;
	private float powerRate;
	
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
        BeaconInit();
    }
    
	private void BeaconInit() {
		BuildingInit();
    	radius = beaconRadius;
    	powerRate = powerPerSec;
    	tag = "Beacon";
    }
    
    private void Update() {
		if (on) {
			if (!manager.SpendMass(powerRate*Time.deltaTime)) {
				//**Turn off beacon
			}
        }
    }
}
