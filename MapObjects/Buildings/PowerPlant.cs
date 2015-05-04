using UnityEngine;
using System.Collections;

public class PowerPlant : Building {
	
	//Public properties
	new public float MassRate {
		get { return (On)?manager.Stat(tag+"MassRate"):0; }
	}
	new public float PowerRate {
		get { return (On)?manager.Stat(tag+"PowerRate"):0; }
	}
	
	private void Awake() {
        PowerPlantInit();
    }
    
	private void PowerPlantInit() {
		BuildingInit();
    	tag = "PowerPlant";
    }
    
    private void Update() {
		if (on) {
			if (manager.SpendMass(-MassRate*Time.deltaTime)) {
				manager.AddFood(PowerRate*Time.deltaTime);
			}
		}
    }
}
