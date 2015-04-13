using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MassDeposit : Resource {
    
    private void Awake() {
        MassDepositInit();
    }
    
	private void MassDepositInit() {
		ResourceInit();
    	tag = "MassDeposit";
    }
    
	public int Mine(int amount) {
    	if (current > amount) {
    		current -= amount;
    		return amount;
    	}
    	else {
			int c = current;
    		current = 0;
    		return c;
    	}
    }
    
    private void Start() {
        
    }
    
    private void Update() {
        
    }
}
