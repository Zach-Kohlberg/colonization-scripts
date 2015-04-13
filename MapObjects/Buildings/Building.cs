using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Building : MapObject {
    
    //Inspector fields
    
    //Private fields
	protected bool on;
	
	//Public Properties
	public bool On { 
    	get { return on; }
    	set { on = value; }
	}
    
    //Base init method
    protected void BuildingInit() {
		on = false;
		z = 0;
    }
}
