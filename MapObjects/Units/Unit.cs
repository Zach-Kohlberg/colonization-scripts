using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Unit : MapObject {
    
    //Inspector fields
    public float unitSpeed, unitMaxHealth;
    
    //Private fields
	protected float speed, health, maxHealth;
	protected MapObject targetObject;
	protected Vector2 targetPosition;
	protected string task;
    
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
	public MapObject TargetObject {
		get { return targetObject; }
		private set { targetObject = value; }
	}
	public Vector2 TargetPosition {
		get { return targetPosition; }
		private set { targetPosition = value; }
	}
	public string Task {
		get { return task; }
		private set { task = value; }
	}
    
    //Base init method
    protected void UnitInit() {
    	speed = unitSpeed;
    	
    	maxHealth = unitMaxHealth;
    	health = maxHealth;
    	
    	targetObject = null;
    	targetPosition = new Vector2(x,y);
		task = "none";
		z = 0;
    }
    
    //Methods for directing units
    public void SetTask(string t, MapObject tO) {
    	task = t;
    	targetObject = tO;
		Vector2 pos = targetObject.position - position;
		targetPosition = (Vector2)position + Vector2.ClampMagnitude(pos,pos.magnitude-0.5f);
    }
	public void SetTask(string t, Vector2 tP) {
    	task = t;
    	targetObject = null;
    	targetPosition = tP;
    }
}
