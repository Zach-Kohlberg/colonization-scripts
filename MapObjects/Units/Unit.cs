using UnityEngine;
using System.Collections;

public class Unit : MapObject {
    
    //Private fields
	protected float health;
	protected MapObject targetObject;
	protected Vector2 targetPosition;
	protected string task;
    
    //Public properties
    public float Speed {
		get { return manager.Stat(tag+"Speed"); }
	}
	public float Health {
		get { return health; }
		private set { health = value; }
	}
	public float MaxHealth {
		get { return manager.Stat(tag+"MaxHealth"); }
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
        MapObjectInit();
    	health = MaxHealth;
    	
    	targetObject = null;
    	targetPosition = new Vector2(x,y);
		task = "none";
		
		
    }
    
    //Methods for directing units
    public void SetTask(string t, MapObject tO) {
    	task = t;
    	targetObject = tO;
		targetPosition = NextTo(targetObject.position);
		TaskSet();
    }
	public void SetTask(string t, Vector2 tP) {
    	task = t;
    	targetObject = null;
    	targetPosition = tP;
    	TaskSet();
    }
    
    //Method for getting a point next to another map object
    protected Vector2 NextTo(Vector3 v) {
		Vector2 pos = v - position;
		return (Vector2)position + Vector2.ClampMagnitude(pos,pos.magnitude-0.5f);
    }
    
    //Unit-specific reaction to being given a task
    protected virtual void TaskSet() {
    	//Do nothing, this is a generic unit
    }
}
