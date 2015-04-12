using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PowerPlant : Building {
	
	//Inspector fields
	public float powerPerTick;
	
	//Private fields
	private float powerRate;
	
	//Public properties
	public float PowerRate {
		get { return powerRate; }
		private set { powerRate = value; }
	}
	
	private void Awake() {
		BuildingInit();
        PowerPlantInit();
    }
    
    private void PowerPlantInit() {
    	powerRate = powerPerTick;
    }
    
    private void Start() {
        
    }
    
    private void Update() {
        
    }
}
