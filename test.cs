using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	//manager man = ;
	// Use this for initialization
	void Start () {
		manager man = new manager();
		Debug.Log (man.Food);
		man.Food = 12;
		Debug.Log (man.Food);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
