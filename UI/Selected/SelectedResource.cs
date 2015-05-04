using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectedResource : UISelected {

    public Text resourceAmountText; 

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
                resourceAmountText.text = ((int) GetSelected().GetComponent<Resource>().Current).ToString() + " / " + GetSelected().GetComponent<Resource>().Max.ToString();
            }

        }
	}
}
