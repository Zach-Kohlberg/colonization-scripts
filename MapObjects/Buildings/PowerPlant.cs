using UnityEngine;
using System.Collections;

public class PowerPlant : Building {
	
	//Public properties
	public float MassRate {
		get { return manager.Stat(tag+"MassRate"); }
	}
	public float PowerRate {
		get { return manager.Stat(tag+"PowerRate"); }
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
			if (manager.SpendMass(MassRate*Time.deltaTime)) {
				manager.AddFood(PowerRate*Time.deltaTime);
			}
		}
    }
}
