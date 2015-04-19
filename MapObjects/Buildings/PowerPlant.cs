using UnityEngine;
using System.Collections;

public class PowerPlant : Building {
	
	//Inspector fields
	public int massPerTick, powerPerTick;
	
	//Private fields
	private int massRate, powerRate;
	private float lastTick;
	
	//Public properties
	public int MassRate {
		get { return massRate; }
		private set { massRate = value; }
	}
	public int PowerRate {
		get { return powerRate; }
		private set { powerRate = value; }
	}
	
	private void Awake() {
        PowerPlantInit();
    }
    
	private void PowerPlantInit() {
		BuildingInit();
		powerRate = powerPerTick;
		massRate = massPerTick;
    	tag = "PowerPlant";
    	lastTick = Time.time;
    }
    
    private void Update() {
		if (on) {
			if (Time.time > lastTick + 1) {
				if (manager.SpendMass(massRate) > 0) {
					manager.AddFood(powerRate);
				}
				lastTick++;
			}
		}
    }
}
