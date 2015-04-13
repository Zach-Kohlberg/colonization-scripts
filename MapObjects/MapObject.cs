using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MapObject : MonoBehaviour {
	
	//Static fields
	protected static readonly string[] resources = {"MassDeposit"}, units = {"Worker"}, buildings = {"Factory", "Beacon", "PowerPlant", "Farm"};
	
	//Private fields
	new protected string tag;
	
	//Public properties
	public string Tag {
		get { return tag; }
		private set { tag = value; }
	}
	
	//Public properties allow easier access/modification of this object's location
	public float x {
		get { return transform.position.x; }
		set { transform.position = new Vector3(value, transform.position.y, transform.position.z); }
	}
	public float y {
		get { return transform.position.y; }
		set { transform.position = new Vector3(transform.position.x, value, transform.position.z); }
	}
	public float z {
		get { return transform.position.z; }
		set { transform.position = new Vector3(transform.position.x, transform.position.y, value); }
	}
	public Vector3 position {
		get { return transform.position; }
		set { transform.position = value; }
	}
	
	//Public method making it easy to determine which type of object this is, in case that matters at some point
	public string TagType() {
		foreach (string s in resources) {
			if (s == tag) {
				return "Resource";
			}
		}
		foreach (string s in units) {
			if (s == tag) {
				return "Unit";
			}
		}
		foreach (string s in buildings) {
			if (s == tag) {
				return "Building";
			}
		}
		return "none";
	}
}
