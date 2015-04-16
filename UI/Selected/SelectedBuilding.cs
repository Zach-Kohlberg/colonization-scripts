using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectedBuilding : UISelected {

    public Text resourceProduction, resourceConsumption;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UISelectedUpdate();

        if (gameObject.activeInHierarchy)
        {
            if (GetSelected() != null)
            {
                
                //buildings currently have nothing. will need/require an update.
            }

        }
	}
}
