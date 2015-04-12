using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Factory : Building {
    
    //Inspector fields
    public GameObject[] unitPrefabs;
    
    //Private fields
    
    //Public properties
    
    private override void Awake() {
        BuildingInit();
    }
    
    private void Start() {
        
    }
    
    private void Update() {
        
    }
}
