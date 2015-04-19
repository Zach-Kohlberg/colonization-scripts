using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UISelected : MonoBehaviour {

    public Text /*nameTextBox, typeTextBox, */ taskTextBox;
    private MapObject selectedMapObject;//the MO that is current selected.
    private Unit selectedUnit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void UISelectedUpdate () {
        if (gameObject.activeInHierarchy)
        {
            if (selectedUnit != null)
            {
                taskTextBox.text = "Currently: " + selectedUnit.Task;
            }
        }
	}

    public void Selected(MapObject mo)
    {
        selectedMapObject = mo;
        //nameTextBox.text = mo.name;
        //typeTextBox.text = mo.Tag;
        selectedUnit = mo.GetComponent<Unit>();
    }

    public MapObject GetSelected()
    {
        return selectedMapObject;
    }
}
