using UnityEngine;
using System.Collections;

public class SelectDisplay : MonoBehaviour {
	private bool on = false;
	public GameObject SelectIcon;
	public int speed;

	private void Awake() {
		SelectIcon.transform.GetChild(0).GetComponent<MeshRenderer> ().enabled = false;
	}

	public void ToggleDisplay() {
		on = !on;

		if (on) 
			SelectIcon.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
		
		else 
			SelectIcon.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
	}

	private void RotateIcon() {
		SelectIcon.transform.Rotate (new Vector3(0,0,SelectIcon.transform.rotation.z + 10) * Time.deltaTime * speed);
	}

	private void Update() {
		if (on)
			RotateIcon ();

		//For testing purposes only

		if (Input.GetKeyDown (KeyCode.K))
			ToggleDisplay ();

		//SelectIcon.transform.localScale = transform.localScale;


		//End testing
	}
}
