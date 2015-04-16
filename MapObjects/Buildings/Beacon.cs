using UnityEngine;
using System.Collections;

public class Beacon : Building {
	
	//Inspector fields
	public float beaconRadius;
	public int powerPerTick;
	
	//Private fields
	private float radius;
	private int powerRate;
	
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
    }
    
    private void Update() {
		if (on) {
			//**Take power from game manager if possible
        	//**If given power, tell fog of war to go away within a certain radius
        }
    }
}
