using UnityEngine;
using System.Collections;

public class Beacon : Building {
	
	//Inspector fields
	public float beaconRadius;
	public int powerPerTick;
	
	//Private fields
	private float radius;
	private int powerRate;
	private float lastTick;
	
	//Public properties
	public float Radius {
		get { return radius; }
		private set { radius = value; }
	}
	public int PowerRate {
		get { return powerRate; }
		private set { powerRate = value; }
	}
	
	private void Awake() {
        BeaconInit();
    }
    
	private void BeaconInit() {
		BuildingInit();
    	radius = beaconRadius;
    	powerRate = powerPerTick;
    	tag = "Beacon";
    	lastTick = Time.time;
    }
    
    private void Update() {
		if (on) {
			if (Time.time > lastTick + 1) {
				if (manager.SpendMass(powerRate) == 0) {
					//**Turn off beacon
				}
				lastTick++;
			}
        }
    }
}
