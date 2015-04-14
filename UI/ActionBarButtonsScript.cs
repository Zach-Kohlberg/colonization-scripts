using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionBarButtonsScript : MonoBehaviour {

    public Text actionbarHoverText;
    public string actionBarTextInfo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ActionBarMouseIn()
    {
        actionbarHoverText.text = actionBarTextInfo;
    }

    public void ActionBarMouseOut()
    {
        actionbarHoverText.text = " ";
    }
}
