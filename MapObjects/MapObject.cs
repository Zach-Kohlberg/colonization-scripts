using UnityEngine;
using System.Collections;

public class MapObject : MonoBehaviour {
	
	//Static fields
	protected static readonly string[] resources = {"MassDeposit"}, units = {"Worker"}, buildings = {"Base", "Factory", "Beacon", "PowerPlant", "Farm"};
	
	//Private fields
	new protected string tag;
	protected bool on;
	protected Manager manager;
	protected SelectDisplay display;
	
	//Public properties
	public string Tag {
		get { return tag; }
		private set { tag = value; }
	}
	public string Type {
		get { return TagType(tag); }
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
	public float MassRate {
		get {
			switch (tag) {
				case "Farm": return (this as Farm).MassRate;
				case "PowerPlant": return (this as PowerPlant).MassRate;
				default: return 10000;
			}
		}
	}
	public float FoodRate {
		get {
			switch (tag) {
				case "Base": return (this as Base).FoodRate;
				case "Farm": return (this as Farm).FoodRate;
				case "Worker": return (this as Worker).FoodRate;
                default: return 10000;
            }
        }
    }
    public float PowerRate {
		get {
			switch (tag) {
				case "Base": return (this as Base).PowerRate;
				case "Beacon": return (this as Beacon).PowerRate;
				case "PowerPlant": return (this as PowerPlant).PowerRate;
                default: return 10000;
            }
        }
    }
    public SelectDisplay Display {
		get { return display; }
	}
	
	//Base init method for map objects
	protected void MapObjectInit() {
		on = true;
		z = 0;
		manager = GameObject.Find("Manager").GetComponent<Manager>();
		manager.AddMapObject(this);
		display = GetComponentInChildren<SelectDisplay>();
	}
	
	public static string TagType(string t) {
		foreach (string s in resources) {
			if (s == t) {
				return "Resource";
			}
		}
		foreach (string s in units) {
			if (s == t) {
				return "Unit";
			}
		}
		foreach (string s in buildings) {
			if (s == t) {
				return "Building";
			}
		}
		return "None";
	}
    
	//Destroy this map object and inform the manager
	public virtual void Kill() {
		manager.RemoveMapObject(this);
		Destroy(gameObject);
	}
}
