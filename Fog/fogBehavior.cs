using UnityEngine;
using System.Collections;

public class fogBehavior : MonoBehaviour {
	public GameObject fogCloud;
	//place this on the game object that is a parent of the fog.
	//disables fog when light is touching it, and disables fog while light is not on
	//light must SHRINK its radius in order for exit to trigger and EXPAND to trigger enter

	void OnTriggerEnter(Collider col) {
		if (col.tag.Equals ("Light")) {
			Debug.Log("Triggering off");
			fogCloud.SetActive (false);
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.tag.Equals ("Light")) {
			Debug.Log("Triggering on");
			fogCloud.SetActive (true);
		}
	}
}
