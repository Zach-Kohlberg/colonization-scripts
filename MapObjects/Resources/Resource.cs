using UnityEngine;
using System.Collections;

public class Resource : MapObject {
	
	//Inspector fields
	public int maxResource, initialResource;
	
	//Private fields
	protected int current, max;
	
	//Public properties
	public int Max {
		get { return max; }
		private set { max = value; }
	}
	public int Current {
		get { return current; }
		private set { current = value; }
	}
    
    //Base init method
    protected void ResourceInit() {
    	current = Mathf.Min(initialResource,maxResource);
    	max = maxResource;
    	
		MapObjectInit();
    }
}
