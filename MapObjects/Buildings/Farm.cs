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
		BuildingInit();
        FarmInit();
    }
    
    private void FarmInit() {
    	foodRate = foodPerTick;
    }
    
    private void Start() {
        
    }
    
    private void Update() {
        
    }
}
