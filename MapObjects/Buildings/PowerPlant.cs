using UnityEngine;
using System.Collections;

public class PowerPlant : Building {
	
	//Inspector fields
	public float massPerSec, powerPerSec;
	
	//Private fields
	private float massRate, powerRate;
	
	//Public properties
	public float MassRate {
		get { return massRate; }
		private set { massRate = value; }
	}
	public float PowerRate {
		get { return powerRate; }
		private set { powerRate = value; }
	}
	
	private void Awake() {
        PowerPlantInit();
    }
    
	private void PowerPlantInit() {
		BuildingInit();
		powerRate = powerPerSec;
		massRate = massPerSec;
    	tag = "PowerPlant";
    }
    
    private void Update() {
		if (on) {
			if (manager.SpendMass(massRate*Time.deltaTime)) {
				manager.AddFood(powerRate*Time.deltaTime);
			}
		}
    }
}
