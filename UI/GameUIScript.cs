using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameUIScript : MonoBehaviour {

    public string[] gameTags;//the tags that our objects use.
    public float panSpeed = 2f;//how quickly should the camera move?
    public Text selectedObjectNameType, header_Resource1Text, header_Resource2Text, header_Resource3Text;
    public Image selectedImage;
    public GameObject selectedPanel, actionBar, selected_worker, selected_Beacon, selected_Factory, selected_Farm, selected_PowerPlant, selected_ResourceDeposit, action_worker, action_Beacon, action_Factory, action_Farm, action_Powerplant;
    
    private List<GameObject> selectedMapObjectPanels, selectedActionBar;
    private Manager manager = null;
    private bool workerMovement = false, uiClick = false;//this determines whether or not the person is clicking the Ui or the actual ground.

    
    private Camera cam;
    private MapObject selected = null;//the most recently selected object
    
    private Dictionary<string, Sprite> selectedImages;
    private bool insideUI = false, clickedUIActionButton = false;//is the player inside the UI? Did the player click a UI Action Button?
    private MapObject currentMO;//the mo the player is currently entranced with.

    void Awake()
    {
        cam = Camera.main;
        if (GameObject.Find("Manager") != null)
        {
            manager = GameObject.Find("Manager").GetComponent<Manager>();
        }
    }


	// Use this for initialization
	void Start () {
        LoadSelectedSprites();

        Debug.Log("Selected Images has a size of: " + selectedImages.Count);

        actionBar.SetActive(false);
        selectedPanel.SetActive(false);
        selectedMapObjectPanels = new List<GameObject>();
        selectedActionBar = new List<GameObject>();
        selectedMapObjectPanels.Add(selected_worker); selectedMapObjectPanels.Add(selected_Beacon); selectedMapObjectPanels.Add(selected_Factory); selectedMapObjectPanels.Add(selected_Farm); selectedMapObjectPanels.Add(selected_PowerPlant); selectedMapObjectPanels.Add(selected_ResourceDeposit);
        selectedActionBar.Add(action_Beacon); selectedActionBar.Add(action_Factory); selectedActionBar.Add(action_Farm); selectedActionBar.Add(action_Powerplant); selectedActionBar.Add(action_worker);  
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (manager != null)
        {
            header_Resource1Text.text = "Mass: " + manager.getMass();
            header_Resource2Text.text = "Food: " + manager.getFood();
            
            //header_Resource3Text.text = "Eneger: " + manager.get
        }
        CameraMovement();
        PlayerInteractions();
        //ActionButtons();
        //PlayerActions();
	}


    /// <summary>
    /// This will capture everything that the player does. Such as clicking on objects and what not.
    /// </summary>
    private void PlayerInteractions()
    {
        

        //if the player is not inside the UI, and has not clicked a UI button
        if (!insideUI && !clickedUIActionButton)
        {
            int mouseClick = -1;
            if (Input.GetMouseButton(0))
            {
                mouseClick = 0;
            }
            else if (Input.GetMouseButton(1))
            {
                mouseClick = 1;
            }

            //if the mouse was clicked
            if (mouseClick > -1)
            {
                RaycastHit hit;
                Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000);

                //determine if an acceptable object was clicked on.
                if (hit.transform != null)
                {
                    //get a reference to the hit object
                    MapObject hitObject = hit.transform.GetComponent<MapObject>();
                    if (hitObject != null)
                    {
                        # region //if the ground was hit
                        if (hitObject.CompareTag("Ground"))
                        {
                            //if it was a left click, keep/make it null
                            if (mouseClick == 0)
                            {
                                currentMO = null;
                                //update the panel and actionbar.
                                SelectedPanelUpdate();
                            }
                            // if it was a right click, determine what was going on.
                            else if (mouseClick == 1 && currentMO != null)
                            {
                                if (currentMO.Tag == "Worker" || currentMO.Tag == "Factory")
                                {
                                    //get the location/position of the click
                                    Vector2 position = hit.point;

                                    if (currentMO.Tag == "Worker")
                                    {
                                        //tell the worker where to move to.
                                        currentMO.GetComponent<Worker>().SetTask("move", position);
                                    }

                                    else if (currentMO.Tag == "Factory")
                                    {
                                        //set the spawn position of the factory
                                        currentMO.GetComponent<Factory>().Spawn = position;
                                    }
                                }

                            }
                            

                        }
                        #endregion
                        #region MassDeposit Clicked
                        else if (hitObject.Tag == "MassDeposit")
                        {

                        }
                        #endregion
                    }
                    
                }
            }

        }
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
                        (selected as Worker).SetTask("move", mousePos);
                    }

                    else if (hitObject.Tag == "Factory")
                    {
                        (selected as Worker).SetTask("deposit", hitObject);
                    }
                    else if (hitObject.Tag == "MassDeposit")
                    {
                        (selected as Worker).SetTask("mine", hitObject);
                    }
                    
                    workerMovement = false;
                    
                }
                
            }
        }
    }

    private void PlayerActions()
    {
        if (!uiClick)
        {
            //come back and change this later.
            int mouse = -1;
            if (Input.GetMouseButtonDown(0))
            {
                mouse = 0;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                mouse = 1;
            }

            if (mouse >= 0)
            {
                RaycastHit hit;
                Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000);
                //Debug.Log(hit.transform.name);
                if (hit.transform != null)
                {
                    Vector2 mousePos = hit.point;
                    MapObject hitObject = hit.transform.GetComponent<MapObject>();

                    if (hit.transform.tag == "Ground")
                    {
                        if (mouse == 0)
                        {
                            if (selected != null)
                            {
                                //selected_last = selected;
                                //selected = infin;
                            }


                            //update the selected panel
                            //SelectedPanelUpdate();
                        }
                        else if (mouse == 1 && selected != null)
                        {
                            if (selected.Tag == "Worker")
                            {
                                (selected as Worker).SetTask("move", mousePos);
                            }
                            else if (selected.Tag == "Factory")
                            {
                                (selected as Factory).Spawn = mousePos;
                            }
                        }
                    }
                    else if (hit.transform.tag == "MapObject")
                    {
                        //Debug.Log("MapObject");
                        if (mouse == 0)
                        {
                            selected = hitObject;
                            //update the selected panel
                            SelectedPanelUpdate(hitObject);
                        }
                        else if (mouse == 1)
                        {
                            if (selected.Tag == "Worker")
                            {
                                if (hitObject.Tag == "Factory")
                                {
                                    (selected as Worker).SetTask("deposit", hitObject);
                                }
                                else if (hitObject.Tag == "MassDeposit")
                                {
                                    (selected as Worker).SetTask("mine", hitObject);
                                }
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
    private void SelectedPanelUpdate(MapObject mo = null)
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

        if (mo != null)
        {
            //change the name of the selected object.
            //selectedObjectName.text = s.name;
            //change the image of the selected object.

            //the image can/will be found on the object itself. 
            //so this will be selectedObjectImage.sprite = s.GetImage

            //change the data displayed for the selected object.





            

            Debug.Log(mo.Tag);
            switch (mo.Tag)
            {
                case "Beacon": selected_Beacon.SetActive(true); selected_Beacon.GetComponent<SelectedBuilding>().Selected(mo); action_Beacon.SetActive(true); actionBar.SetActive(true); break;
                case "Factory": selected_Factory.SetActive(true); selected_Factory.GetComponent<SelectedBuilding>().Selected(mo); action_Factory.SetActive(true); actionBar.SetActive(true); break;
                case "Farm": selected_Farm.SetActive(true); selected_Farm.GetComponent<SelectedBuilding>().Selected(mo); action_Farm.SetActive(true); actionBar.SetActive(true); break;
                case "MassDeposit": selected_ResourceDeposit.SetActive(true); selected_ResourceDeposit.GetComponent<SelectedResource>().Selected(mo); break;
                case "PowerPlant": selected_PowerPlant.SetActive(true); selected_PowerPlant.GetComponent<SelectedBuilding>().Selected(mo); action_Powerplant.SetActive(true); actionBar.SetActive(true); break;
                case "Worker": selected_worker.SetActive(true); selected_worker.GetComponent<SelectedWorker>().Selected(mo); action_worker.SetActive(true); actionBar.SetActive(true);  break;
                
                
            }
            selectedObjectNameType.text = mo.Tag;
            selectedImage.sprite = selectedImages[mo.Tag];
            selectedPanel.SetActive(true);
            

            
        }

        
    }

    public void WorkerAction()
    {
        Debug.Log("The current selected object is: " + selected.Tag);
        workerMovement = true;
        uiClick = true;
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


    /// <summary>
    /// determine whether or not the user's mouse is inside the UI.
    /// </summary>
    public void InsideUI(bool inside)
    {
        //uiClick = inside;
        insideUI = inside;
    }

    public void ActionBarSelection()
    {
       
    }


    /// <summary>
    /// Load all sprites into the dictionary. Should be called at startup
    /// </summary>
    private void LoadSelectedSprites()
    {
        selectedImages = new Dictionary<string, Sprite>();
        
        //foreach (string s in UnityEditorInternal.InternalEditorUtility.tags)//apparently, this can only be used in the editor.
        foreach(string s in gameTags)
        {

            Sprite p = null;
            try
            {
                //Debug.Log("Trying to load the sprite for: " + s);
                p = Resources.Load<Sprite>("Images/" + s);
                //Debug.Log(p);
            }
            catch
            {
                //Debug.LogWarning("Could not load an image for: " + s);
            }
            if (p != null)
            {
                selectedImages.Add(s, p);
            }

        }
    }
}
