using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionBarButtonsScript : MonoBehaviour {

    public Text costText;
    public string mapobjectTag, actionBarTextInfo;
    //public GameObject buildingPrefab;
    public bool building = false, worker = false, cancelButton = false, points = false;
    public HoverTextScript hts;
    private Manager manager;

    private float cost = 0;

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
            cost = manager.GetCost(mapobjectTag);
        }
        if (worker)
        {
            Debug.Log("worker is not null");
            cost = manager.GetCost(mapobjectTag);
        }
        if (points)
        {
            Debug.Log("victory is not null");
            cost = 100;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (building || worker)
        {
            if (manager.Mass < cost)
            {
                gameObject.GetComponent<Button>().interactable = false;
            }
            else
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        }

        if (points)
        {
            if (manager.Mass < cost)
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
        hts.Text_Set(actionBarTextInfo);
        if (cost != 0)
        {
            costText.text = "Cost\n" + cost.ToString();
        }
    }

    public void ActionBarMouseOut()
    {
        if (gameObject.GetComponent<Button>().interactable || cancelButton)
        {
            hts.Text_Clear();
            costText.text = " ";
        }
       
        
    }

    /// <summary>
    /// Return the hovertext
    /// </summary>
    /// <returns></returns>
    public string ClickedHoverText()
    {
        return actionBarTextInfo;
    }
}
