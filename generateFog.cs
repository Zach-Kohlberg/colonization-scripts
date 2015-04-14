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
				Instantiate(fogPiece,new Vector3(position.x+t,position.y,position.z+o), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
