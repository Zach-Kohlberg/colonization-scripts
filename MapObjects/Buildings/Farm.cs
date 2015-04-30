using UnityEngine;
using System.Collections;

public class Farm : Building {
    
	//Public properties
	public float MassRate {
		get { return manager.Stat(tag+"MassRate"); }
	}
	public float FoodRate {
		get { return manager.Stat(tag+"FoodRate"); }
    }
    
	private void Awake() {
        FarmInit();
    }
    
	private void FarmInit() {
		BuildingInit();
    	tag = "Farm";
    }
    
    private void Update() {
		if (on) {
			if (manager.SpendMass(MassRate*Time.deltaTime)) {
				manager.AddFood(FoodRate*Time.deltaTime);
			}
		}
    }
}
