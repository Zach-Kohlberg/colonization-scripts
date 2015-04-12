using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Unit : MapObject {
    
    //Inspector fields
    public float unitSpeed, maxUnitHealth;
    
    //Private fields
    protected float speed, health, maxHealth;
    
    //Public properties
    public float Speed {
    	get { return speed; }
    	private set { speed = value; }
	}
	public float Health {
		get { return health; }
		private set { health = value; }
	}
	public float MaxHealth {
		get { return maxHealth; }
		private set { maxHealth = value; }
	}
    
    //Base init method
    protected void UnitInit() {
    	speed = unitSpeed;
    	maxHealth = maxUnitHealth;
    	health = maxHealth;
    }
}
