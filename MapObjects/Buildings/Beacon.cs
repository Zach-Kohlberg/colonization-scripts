using UnityEngine;
using System.Collections;

public class Beacon : Building {
	
	//Public properties
	public float Radius {
		get { return manager.Stat(tag+"Radius"); }
	}
	new public float PowerRate {
		get { return (On)?manager.Stat(tag+"PowerRate"):0; }
	}
	
	private void Awake() {
        BeaconInit();
    }
    
	private void BeaconInit() {
		BuildingInit();
    	tag = "Beacon";
    }
    
    private void Update() {
		if (On) {
			if (!manager.SpendMass(-PowerRate*Time.deltaTime)) {
				//**Turn off beacon
			}
        }
    }
}
