using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TestGUI : MonoBehaviour {
    
    public GameObject workerPrefab, factoryPrefab;
    
    private MapObject selected;
    
    private void Awake() {
        selected = null;
    }
    
    private void Update() {
    	int mouse = -1;
    	if (Input.GetMouseButtonDown(0)) {
    		mouse = 0;
    	}
    	else if (Input.GetMouseButtonDown(1)) {
    		mouse = 1;
    	}
    	if (mouse >= 0) {
			RaycastHit hit;
			Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000);
			if (hit.transform != null) {
				Vector2 mousePos = hit.point;
				MapObject hitObject = hit.transform.GetComponent<MapObject>();
				if (hit.transform.tag == "Ground") {
					if (mouse == 0) {
						selected = null;
					}
					else if (mouse == 1 && selected != null) {
						if (selected.Tag == "Worker") {
							if (Input.GetKey(KeyCode.LeftControl)) {
								(selected as Worker).Build(factoryPrefab, mousePos);
							}
							else {
								(selected as Worker).SetTask("move", mousePos);
							}
						}
						else if (selected.Tag == "Factory") {
							if (Input.GetKey(KeyCode.LeftControl)) {
								(selected as Factory).SpawnUnit(workerPrefab);
							}
							else {
								(selected as Factory).Spawn = mousePos;
							}
						}
					}
				}
				else if (hit.transform.tag == "MapObject") {
					if (mouse == 0) {
						selected = hitObject;
					}
					else if (mouse == 1) {
						if (selected.Tag == "Worker") {
							if (hitObject.Tag == "Factory") {
								(selected as Worker).SetTask("deposit", hitObject);
							}
							else if (hitObject.Tag == "MassDeposit") {
								(selected as Worker).SetTask("mine", hitObject);
							}
						}
					}
				}
			}
		}
    }
}
