using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TestGUI : MonoBehaviour {
    
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
				if (hit.transform.tag == "Ground") {
					if (mouse == 0) {
						selected = null;
					}
					else if (mouse == 1 && selected != null) {
						if (selected.Tag == "Worker") {
							(selected as Worker).SetTask("move", mousePos);
						}
						else if (selected.Tag == "Factory") {
							(selected as Factory).Spawn = mousePos;
						}
					}
				}
				else if (hit.transform.tag == "MapObject") {
					Debug.Log("MapObject");
					if (mouse == 0) {
						selected = hit.transform.GetComponent<MapObject>();
					}
					else if (mouse == 1) {
						if (selected.Tag == "Worker") {
							(selected as Worker).SetTask("move", hit.transform.GetComponent<MapObject>());
						}
					}
				}
			}
		}
    }
}
