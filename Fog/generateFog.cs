using UnityEngine;
using System.Collections;

public class generateFog : MonoBehaviour {
	public int x,y,z,l,w;
	public GameObject fogPiece;
	Vector3 position; 
	// Use this for initialization
	void Start () {
		position = new Vector3 (x, y, z);
		for (int t = 0; t < l; t++) {
			for(int o = 0; o < w; o++){
				GameObject a = Instantiate(fogPiece,new Vector3(position.x+t,position.y+o,position.z), Quaternion.Euler(-90,0,0)) as GameObject;
				//a.transform.rotation = new Quaternion(270,0,0,1);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
