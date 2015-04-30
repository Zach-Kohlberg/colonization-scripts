using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectedWorker : UISelected {

    public Text health, foodConsume, carry;
    private Worker myWorker;

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
                myWorker = GetSelected().GetComponent<Worker>();
                if (myWorker != null)
                {
                    health.text = myWorker.Health.ToString()/* + " health"*/;
                    foodConsume.text = myWorker.FoodRate.ToString()/* + " food/s"*/;
                    carry.text = (int) myWorker.Mass + " / " + (int) myWorker.MaxMass;
                }
            }
            
        }
        
	}
}
