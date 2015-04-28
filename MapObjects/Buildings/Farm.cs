using UnityEngine;
using System.Collections;

public class Farm : Building {
    
    //Public properties for inspector
	public float massPerSec, foodPerSec;
    
    //Private fields
	private float massRate, foodRate;
    
	//Public properties
	public float MassRate {
		get { return massRate; }
		private set { massRate = value; }
	}
	public float FoodRate {
    	get { return foodRate; }
    	private set { foodRate = value; }
    }
    
	private void Awake() {
        FarmInit();
    }
    
	private void FarmInit() {
		BuildingInit();
		foodRate = foodPerSec;
		massRate = massPerSec;
    	tag = "Farm";
    }
    
    private void Update() {
		if (on) {
			if (manager.SpendMass(massRate*Time.deltaTime)) {
				manager.AddFood(foodRate*Time.deltaTime);
			}
		}
    }
}
