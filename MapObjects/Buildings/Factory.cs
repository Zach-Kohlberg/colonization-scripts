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
    	spawn = position + new Vector3(1,0,0);
    }
    
    public void DepositMass(int amount) {
    	//**Send mass to game manager
    }
    
    public void SpawnUnit(GameObject unit) {
    	//**Ask game manager about cost for unit, pay cost
    	Unit u = (Instantiate(unit) as GameObject).GetComponent<Unit>();
    	u.position = position;
    	u.SetTask("move", spawn);
    }
}
