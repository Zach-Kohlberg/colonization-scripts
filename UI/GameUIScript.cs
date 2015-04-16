using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameUIScript : MonoBehaviour {

    public float panSpeed = 2f;
    public Text selectedObjectName, header_Resource1Text, header_Resource2Text, header_Resource3Text;
    private Camera cam;
    private MapObject selected = null, selected_last = null, infin;//the most recently selected object
    public GameObject selectedPanel, actionBar, selected_worker, selected_building, selected_resource, action_worker, action_Factory;
    private List<GameObject> selectedMapObjectPanels, selectedActionBar;


    private bool workerMovement = false;

    void Awake()
    {
        cam = Camera.main;
    }


	// Use this for initialization
	void Start () {
        actionBar.SetActive(false);
        selectedPanel.SetActive(false);
        selectedMapObjectPanels = new List<GameObject>();
        selectedActionBar = new List<GameObject>();
        selectedMapObjectPanels.Add(selected_worker); selectedMapObjectPanels.Add(selected_building); selectedMapObjectPanels.Add(selected_resource);
        selectedActionBar.Add(action_worker); selectedActionBar.Add(action_Factory);
	}
	
	// Update is called once per frame
	void Update () {

        CameraMovement();
        ActionButtons();
        PlayerActions();
	}

    //this should occur before anything/everything in the update
    private void ActionButtons()
    {
        //so if the workermovement button has been clicked. Will come back and change this after testing
        if (workerMovement)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000);
                if (hit.transform != null)
                {
                    MapObject hitObject = hit.transform.GetComponent<MapObject>();
                    
                    if (hit.transform.CompareTag("Ground"))
                    {
                        Vector2 mousePos = hit.point;
                        (selected_last as Worker).SetTask("move", mousePos);
                    }

                    else if (hitObject.Tag == "Factory")
                    {
                        (selected_last as Worker).SetTask("deposit", hitObject);
                    }
                    else if (hitObject.Tag == "MassDeposit")
                    {
                        (selected_last as Worker).SetTask("mine", hitObject);
                    }
                    
                    workerMovement = false;
                    
                }
                
            }
        }
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
            //Debug.Log(hit.transform.name);
			if (hit.transform != null) {
				Vector2 mousePos = hit.point;
				MapObject hitObject = hit.transform.GetComponent<MapObject>();
                
				if (hit.transform.tag == "Ground") {
					if (mouse == 0) {
                        if (selected != null)
                        {
                            selected_last = selected;
                            selected = infin;
                        }
                        
                        
                        //update the selected panel
                        //SelectedPanelUpdate();
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
					//Debug.Log("MapObject");
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
        actionBar.SetActive(false);
        selectedPanel.SetActive(false);

        //make sure all panels are off.
        foreach (GameObject g in selectedMapObjectPanels)
        {
            g.SetActive(false);
        }

        //turn all actionbars off
        foreach (GameObject g in selectedActionBar)
        {
            g.SetActive(false);
        }

        if (s != null)
        {
            //change the name of the selected object.
            //selectedObjectName.text = s.name;
            //change the image of the selected object.

            //the image can/will be found on the object itself. 
            //so this will be selectedObjectImage.sprite = s.GetImage

            //change the data displayed for the selected object.





            

            Debug.Log(s.Tag);
            switch (s.Tag)
            {
                case "Worker": selected_worker.SetActive(true); selected_worker.GetComponent<SelectedWorker>().Selected(s); action_worker.SetActive(true); actionBar.SetActive(true);  break;
                case "Factory": selected_building.SetActive(true); selected_building.GetComponent<SelectedBuilding>().Selected(s); action_Factory.SetActive(true); actionBar.SetActive(true);  break;
                case "MassDeposit": selected_resource.SetActive(true); selected_resource.GetComponent<SelectedResource>().Selected(s); break;
            }

            selectedPanel.SetActive(true);

            
        }

        
    }

    public void WorkerAction()
    {
        Debug.Log("The current selected object is: " + selected_last.Tag);
        workerMovement = true;
//        + " and the last selected object is: " + selected_last);
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
