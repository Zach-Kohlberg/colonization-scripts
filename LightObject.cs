using UnityEngine;
using System.Collections;

public class LightObject : MonoBehaviour {
	bool large = false;
	SphereCollider lightSphere;
	Transform lightScale;
	public float maxBounds, lowerBounds;
	// Use this for initialization
	void Start() {
		lightSphere = GetComponent<SphereCollider> ();
		lightScale = gameObject.transform;

	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.F)) 
			ShrinkLight ();
		else if (Input.GetKeyDown (KeyCode.G))
			GrowLight ();
	}

	public void GrowLight() {
		if (!large) {
			for (float i = lowerBounds; i < maxBounds; i++) {
				//lightSphere.radius += i/2;
				lightScale.localScale = new Vector3 (lightScale.localScale.x + .01f, lightScale.localScale.y + .01f, lightScale.localScale.z);
			}
			large = true;
/*
			Color col = GetComponent<Renderer>().material.color;
			col.a = 0;
			gameObject.GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color,col, Time.deltaTime *);
*/
		}

	}

	public void ShrinkLight() {
		if (large) {
			for (float i = maxBounds; i > lowerBounds; i--) {
				//lightSphere.radius -= i/2;
				lightScale.localScale = new Vector3 (lightScale.localScale.x - .01f, lightScale.localScale.y - .01f, lightScale.localScale.z );
			}
			large = false;
		}
	}
}
