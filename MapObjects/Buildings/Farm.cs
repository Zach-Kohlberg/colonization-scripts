using UnityEngine;
using System.Collections;

public class Farm : Building {
    
    //Public properties for inspector
	public int massPerTick, foodPerTick;
    
    //Private fields
	private int massRate, foodRate;
	private float lastTick;
    
	//Public properties
	public int MassRate {
		get { return massRate; }
		private set { massRate = value; }
	}
	public int FoodRate {
    	get { return foodRate; }
    	private set { foodRate = value; }
    }
    
	private void Awake() {
        FarmInit();
    }
    
	private void FarmInit() {
		BuildingInit();
		foodRate = foodPerTick;
		massRate = massPerTick;
    	tag = "Farm";
    	lastTick = Time.time;
    }
    
    private void Update() {
		if (on) {
			if (Time.time > lastTick + 1) {
				if (manager.SpendMass(massRate) > 0) {
					manager.AddFood(foodRate);
				}
				lastTick++;
			}
		}
    }
}
