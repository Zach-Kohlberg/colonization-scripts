using UnityEngine;
using System.Collections;

public class MapObject : MonoBehaviour {
	
	//Static fields
	protected static readonly string[] resources = {"MassDeposit"}, units = {"Worker"}, buildings = {"Base", "Factory", "Beacon", "PowerPlant", "Farm"};
	
	//Private fields
	new protected string tag;
	protected bool on;
	protected Manager manager;
	
	//Public properties
	public string Tag {
		get { return tag; }
		private set { tag = value; }
	}
	public bool On {
		get { return on; }
		set { on = value; }
	}
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
	
	//Base init method for map objects
	protected void MapObjectInit() {
		on = true;
		z = 0;
		manager = GameObject.Find("Manager").GetComponent<Manager>();
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
	
	//Destroy this map object and inform the manager
	public virtual void Kill() {
		//**Inform the manager that I'm dead
		Destroy(gameObject);
	}
}
