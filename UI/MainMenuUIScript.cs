using UnityEngine;
using System.Collections;

public class MainMenuUIScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// called by the play button on the main screen.
    /// </summary>
    public void Play()
    {
        Application.LoadLevel(1);
    }
}
