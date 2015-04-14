using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameUIScript : MonoBehaviour {

    public float panSpeed = 2f;
    public Text selectedObjectName, header_Resource1Text, header_Resource2Text, header_Resource3Text;
    private Camera cam;
    private MapObject selected = null;//the most recently selected object


    void Awake()
    {
        cam = Camera.main;
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        CameraMovement();
        PlayerActions();
	}

    private void PlayerActions()
    {
        //come back and change this later.
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
                        //update the selected panel
                        SelectedPanelUpdate();
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
						selected = hitObject;
                        //update the selected panel
                        SelectedPanelUpdate(hitObject);
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

    private void CameraMovement()
    {
        float x = Input.GetAxis("Horizontal"), y = Input.GetAxis("Vertical"); Vector3 forward = Camera.main.transform.position;
        cam.transform.position += new Vector3(x, y, 0) * panSpeed;
    }

    /// <summary>
    /// called from inside the GameUIScript when an object is selected.
    /// </summary>
    /// <param name="s">The most recently selected object</param>
    private void SelectedPanelUpdate(MapObject s = null)
    {
        if (s != null)
        {
            //change the name of the selected object.
            selectedObjectName.text = s.name;
            //change the image of the selected object.

            //the image can/will be found on the object itself. 
            //so this will be selectedObjectImage.sprite = s.GetImage

            //change the data displayed for the selected object.
        }
        
    }


    /// <summary>
    /// Accept information about the resources and display it to the player. Called from the manager.
    /// </summary>
    /// <param name="R1">Resource 1 amount</param>
    /// <param name="R2">Resource 2 amount</param>
    /// <param name="R3">Resource 3 amount</param>
    public void UpdateResources(int R1 = 9999, int R2 = 9999, int R3 = 9999)
    {
        header_Resource1Text.text = R1.ToString();
        header_Resource2Text.text = R2.ToString();
        header_Resource3Text.text = R3.ToString();
    }
}
