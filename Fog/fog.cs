using UnityEngine;
using System.Collections;

public class fog : MonoBehaviour {
	Material mat;
	// Use this for initialization
	void Start () {
		mat = gameObject.GetComponent<Renderer> ().material;
		mat.SetVector("_test", new Vector4(0, 0, 1, 1));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
