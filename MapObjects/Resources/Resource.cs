using UnityEngine;
using System.Collections;

public class Resource : MapObject {
	
	//Inspector fields
	public float maxResource, initialResource;
	
	//Private fields
	protected float current, max;
	
	//Public properties
	public float Max {
		get { return max; }
		private set { max = value; }
	}
	public float Current {
		get { return current; }
		private set { current = value; }
	}
    
    //Base init method
    protected void ResourceInit() {
        MapObjectInit();
    	current = Mathf.Min(initialResource,maxResource);
    	max = maxResource;
    	
		
    }
}
