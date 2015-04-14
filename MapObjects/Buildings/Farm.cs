using UnityEngine;
using System.Collections;

public class Farm : Building {
    
    //Public properties for inspector
	public int massPerTick, foodPerTick;
    
    //Private fields
	private int massRate, foodRate;
    
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
    }
    
    private void Update() {
		//**Take mass from game manager if possible
		//**If given mass, generate food for the game manager
    }
}
