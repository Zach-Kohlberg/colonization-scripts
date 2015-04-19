using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionBarButtonsScript : MonoBehaviour {

    public Text actionbarHoverText, costText;
    public string actionBarTextInfo;
    public GameObject buildingPrefab;
    public bool building = false;
    private Manager manager;

    private int cost = 0;

    void Awake()
    {
        if (GameObject.Find("Manager") != null)
        {
            manager = GameObject.Find("Manager").GetComponent<Manager>();
        }
    }

	// Use this for initialization
	void Start () {
        if (building)
        {
            Debug.Log("building prefab is not null");
            cost = manager.GetCost(buildingPrefab.GetComponent<MapObject>().Tag);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (building)
        {
            if (manager.getMass() < cost)
            {
                gameObject.GetComponent<Button>().interactable = false;
            }
            else
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        }
	}

    public void ActionBarMouseIn()
    {
        Debug.Log("Hovering");
        actionbarHoverText.text = actionBarTextInfo;
        if (buildingPrefab != null)
        {
            costText.text = "Cost\n" + cost.ToString();
        }
    }

    public void ActionBarMouseOut()
    {
        actionbarHoverText.text = " ";
        costText.text = " ";
    }
}
