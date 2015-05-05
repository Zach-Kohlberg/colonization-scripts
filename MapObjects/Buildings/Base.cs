using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Base : Building {
	
	//Private fields
	private LightObject light;
	private Vector2 spawn;
	
	//Public properties
	public Vector2 Spawn {
		get { return spawn; }
		set { spawn = value; }
	}
	public float Radius {
		get { return manager.Stat(tag+"Radius"); }
	}
	new public float PowerRate {
		get { return (On)?manager.Stat(tag+"PowerRate"):0; }
	}
	new public float FoodRate {
		get { return (On)?manager.Stat(tag+"FoodRate"):0; }
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
		light = GetComponentInChildren<LightObject>();
		tag = "Base";
		spawn = position + new Vector3(1,0,0);
	}
	
	public override void Kill() {
		//Do nothing, the base cannot be killed
	}
	
	public void DepositMass(float amount) {
		manager.AddMass(amount);
	}
	
	public void SpawnUnit(GameObject unit) {
		Unit u = (Instantiate(unit) as GameObject).GetComponent<Unit>();
		if (manager.SpendMass(manager.GetCost(u.Tag))) {
			u.position = position;
			u.SetTask("move", spawn);
		}
		else {
			Destroy(u.gameObject);
		}
	}
	
	private void Update() {
		if (!manager.SpendFood(-FoodRate*Time.deltaTime) || !manager.SpendPower(-PowerRate*Time.deltaTime)) {
			manager.GameOver = true;
		}
	}
}
