using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class OverviewUIScript : MonoBehaviour {

    private Manager manager;
    public Text workers, beacons, factories, farms, powerplants;


	// Use this for initialization
	void Start () {
        if (GameObject.Find("Manager") != null)
        {
            manager = GameObject.Find("Manager").GetComponent<Manager>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}


    /// <summary>
    /// Update the UI for the overview.
    /// </summary>
    public void OverviewUpdate(){
        if (manager != null)
        {
            workers.text = manager.FilterTag("Worker").Count.ToString();
            beacons.text = manager.FilterTag("Beacon").Count.ToString();
            factories.text = manager.FilterTag("Factory").Count.ToString();
            farms.text = manager.FilterTag("Farm").Count.ToString();
            powerplants.text = manager.FilterTag("PowerPlant").Count.ToString();
        }
        
    }
}
