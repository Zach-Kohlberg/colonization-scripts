using UnityEngine;
using System.Collections;

public class Beacon : Building {
	
	//Public properties
	public float Radius {
		get { return manager.Stat(tag+"Radius"); }
	}
	public float PowerRate {
		get { return manager.Stat(tag+"PowerRate"); }
	}
	
	private void Awake() {
        BeaconInit();
    }
    
	private void BeaconInit() {
		BuildingInit();
    	tag = "Beacon";
    }
    
    private void Update() {
		if (on) {
			if (!manager.SpendMass(PowerRate*Time.deltaTime)) {
				//**Turn off beacon
			}
        }
    }
}
