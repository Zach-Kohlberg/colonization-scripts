using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Factory : Building {
    
    //Inspector fields
    public GameObject[] unitPrefabs;
    
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
    	spawn = position;
    }
    
    private void Start() {
        
    }
    
    private void Update() {
        
    }
}
