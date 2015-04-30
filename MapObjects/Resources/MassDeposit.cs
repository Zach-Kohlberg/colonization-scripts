using UnityEngine;
using System.Collections;

public class MassDeposit : Resource {
    
    private void Awake() {
        MassDepositInit();
    }
    
	private void MassDepositInit() {
		ResourceInit();
    	tag = "MassDeposit";
    }
    
	public float Mine(float amount) {
    	if (current > amount) {
    		current -= amount;
    		return amount;
    	}
    	else {
			float c = current;
    		current = 0;
    		return c;
    	}
    }
}
