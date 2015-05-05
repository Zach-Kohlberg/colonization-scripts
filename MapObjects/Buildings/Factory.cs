using UnityEngine;
using System.Collections;

public class Factory : Building {
    
    //Inspector fields
    
    //Private fields
    private Vector2 spawn;
    
    //Public properties
    public Vector2 Spawn {
    	get { return spawn; }
    	set { spawn = value; }
    }
    
    private void Awake() {
    	FactoryInit();
    }
    
	private void FactoryInit() {
		BuildingInit();
    	tag = "Factory";
    	spawn = position + new Vector3(4,0,0);
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
}
