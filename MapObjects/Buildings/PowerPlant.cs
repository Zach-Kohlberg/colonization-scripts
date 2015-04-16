using UnityEngine;
using System.Collections;

public class PowerPlant : Building {
	
	//Inspector fields
	public int massPerTick, powerPerTick;
	
	//Private fields
	private int massRate, powerRate;
	
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
    }
    
    private void Update() {
		if (on) {
			//**Take mass from game manager if possible
			//**If given mass, generate power for the game manager
		}
    }
}
