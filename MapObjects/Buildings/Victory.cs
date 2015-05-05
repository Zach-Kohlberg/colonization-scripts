using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Victory : Building {
    
	//Inspector fields
	
	//Private fields
	
	//Public properties
	
	private void Awake() {
		VictoryInit();
	}
	
	private void VictoryInit() {
		BuildingInit();
		tag = "Victory";
	}
	
	public void BuyPoints() {
		if (On && manager.SpendMass(100)) {
			manager.AddPoints(100);
		}
	}
}
