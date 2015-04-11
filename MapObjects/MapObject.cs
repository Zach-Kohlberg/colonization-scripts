using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MapObject : MonoBehaviour {
	
	//Public properties allow easier access/modification of this object's location
	public float x {
		get { return transform.position.x; }
		set { transform.position = new Vector3(value, transform.position.y, transform.position.z); }
	}
	public float y {
		get { return transform.position.y; }
		set { transform.position = new Vector3(transform.position.x, value, transform.position.z); }
	}
	public float z {
		get { return transform.position.z; }
		set { transform.position = new Vector3(transform.position.x, transform.position.y, value); }
	}
	public Vector3 position {
		get { return transform.position; }
		set { transform.position = value; }
	}
    
    private void Awake() {
        
    }
    
    private void Start() {
        
    }
    
    private void Update() {
        
    }
}
