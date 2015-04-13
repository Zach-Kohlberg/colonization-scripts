using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Farm : Building {
    
    //Public properties for inspector
    public float foodPerTick;
    
    //Private fields
    private float foodRate;
    
    //Public properties
    public float FoodRate {
    	get { return foodRate; }
    	private set { foodRate = value; }
    }
    
	private void Awake() {
        FarmInit();
    }
    
	private void FarmInit() {
		BuildingInit();
    	foodRate = foodPerTick;
    	tag = "Farm";
    }
    
    private void Start() {
        
    }
    
    private void Update() {
        
    }
}
