using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Base : Building {
	
	//Inspector fields
	public float beaconRadius;
	public int powerPerTick, foodPerTick;
	
	//Private fields
	private Vector2 spawn;
	private float radius;
	private int powerRate, foodRate;
	
	//Public properties
	public Vector2 Spawn {
		get { return spawn; }
		set { spawn = value; }
	}
	public float Radius {
		get { return radius; }
		private set { radius = value; }
	}
	public int PowerRate {
		get { return powerRate; }
		private set { powerRate = value; }
	}
	public int FoodRate {
		get { return foodRate; }
		private set { foodRate = value; }
	}
	new public bool On {
		get { return on; }
		private set { on = value; }
	}
	
	private void Awake() {
		BaseInit();
	}
	
	private void BaseInit() {
		BuildingInit();
		radius = beaconRadius;
		powerRate = powerPerTick;
		foodRate = foodPerTick;
		tag = "Base";
		spawn = position + new Vector3(1,0,0);
	}
	
	public override void Kill() {
		//Do nothing, the base cannot be killed
	}
	
	public void DepositMass(int amount) {
		manager.AddMass(amount);
	}
	
	public void SpawnUnit(GameObject unit) {
		Unit u = (Instantiate(unit) as GameObject).GetComponent<Unit>();
		if (manager.SpendMass(manager.GetCost(u.Tag)) != 0) {
			u.position = position;
			u.SetTask("move", spawn);
		}
		else {
			Destroy(u.gameObject);
		}
	}
	
	private void Update() {
		//**Tell fog of war to go away within a certain radius
		if (manager.SpendFood(foodRate) == 0 || manager.SpendPower(powerRate) == 0) {
			//**You lose the game
		}
	}
}
