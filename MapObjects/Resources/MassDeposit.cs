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
    
    private void Start() {
        
    }
    
    private void Update() {
        
    }
}
