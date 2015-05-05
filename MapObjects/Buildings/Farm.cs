using UnityEngine;
using System.Collections;

public class Farm : Building {
    
	//Public properties
	new public float MassRate {
		get { return (On)?manager.Stat(tag+"MassRate"):0; }
	}
	new public float FoodRate {
		get { return (On)?manager.Stat(tag+"FoodRate"):0; }
    }
    
	private void Awake() {
        FarmInit();
    }
    
	private void FarmInit() {
		BuildingInit();
    	tag = "Farm";
    }
    
    private void Update() {
		if (On) {
			if (manager.SpendMass(-MassRate*Time.deltaTime)) {
				manager.AddFood(FoodRate*Time.deltaTime);
			}
		}
    }
}
