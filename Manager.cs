using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {
	
	//Structs for the inspector
	[Serializable]
	public struct Property {
		public string key;
		public float value;
	}
	[Serializable]
	public struct Prefab {
		public string key;
		public GameObject value;
	}
	
	//Initial resources
	public float initMass, initFood, initPower;
	//Initial stats
	public Property[] initStats;
	//Prefab list
	public Prefab[] initPrefabs;
	//Cost list
	public Property[] initCosts;
	
	//Resources
	private float food, power, mass;
	private int points;
	//Add objects in the game
	private List<MapObject> mapObjectList;
	//Map object stats
	private Dictionary<string, float> stats;
	//Map object prefabs
	private Dictionary<string, GameObject> prefabs;
	//Unit and building costs
	private Dictionary<string, float> costs;
	
	//Public properties
	public float Food {
		get { return food; }
		set { food = value; }
	}
	public float Mass {
		get { return mass; }
		set { mass = value; }
	}
	public float Power {
		get { return power; }
		set { power = value; }
	}
	public int Points {
		get { return points; }
		set { points = value; }
	}

    private void Awake() {
        ManagerInit();
    }

	private void ManagerInit() {
		food = initFood;
		mass = initMass;
		power = initPower;
		mapObjectList = new List<MapObject>();
		stats = new Dictionary<string, float>();
		foreach (Property p in initStats) {
			stats.Add(p.key, p.value);
		}
		prefabs = new Dictionary<string, GameObject>();
		foreach (Prefab p in initPrefabs) {
			prefabs.Add(p.key, p.value);
		}
		costs = new Dictionary<string, float>();
        Debug.LogWarning("ManagerInit");
		foreach (Property c in initCosts) {
			costs.Add(c.key, c.value);
            Debug.LogWarning(c.key + " and " + c.value);
		}
	}
	
	//Returns a list of all objects containing a given tag
	public List<MapObject> FilterType(string type) {
		List<MapObject> l = new List<MapObject>();
		foreach (MapObject m in mapObjectList) {
			if (m.Type == type) {
				l.Add(m);
			}
		}
		return l;
	}
	public List<MapObject> FilterTag(string tag) {
		List<MapObject> l = new List<MapObject>();
		foreach (MapObject m in mapObjectList) {
			if (m.Tag == tag) {
				l.Add(m);
			}
		}
		return l;
	}
	
	//Enable/disable stuff based on proximity to active beacons
	public void FogCheck() {
		foreach (MapObject m in FilterType("Unit")) {
			//Disable
			foreach (MapObject b in FilterTag("Beacon")) {
				if (b.On && Vector2.Distance(m.position, b.position) <= (b as Beacon).Radius) {
					//Enable
					break;
				}
			}
			foreach (MapObject b in FilterTag("Base")) {
				if (b.On && Vector2.Distance(m.position, b.position) <= (b as Base).Radius) {
					//Enable
					break;
				}
			}
		}
		foreach (MapObject m in FilterType("Building")) {
			if (m.Tag != "Base" && m.Tag != "Beacon") {
				//Disable
				foreach (MapObject b in FilterTag("Beacon")) {
					if (b.On && Vector2.Distance(m.position, b.position) <= (b as Beacon).Radius) {
						//Enable
						break;
					}
				}
				foreach (MapObject b in FilterTag("Base")) {
					if (b.On && Vector2.Distance(m.position, b.position) <= (b as Base).Radius) {
						//Enable
						break;
					}
				}
			}
		}
	}
	
	//Return the cost to create a specific unit or building
	public float GetCost(string tag) {
		if (costs.ContainsKey(tag)) {
            Debug.LogWarning(costs[tag]);
			return costs[tag];
		}
		else {
            Debug.LogWarning("Could not Find a cost for the building: " + tag);
			return Int32.MaxValue;
		}
	}
	
	//Return a prefab for the map object that we're building
	public GameObject GetPrefab(string tag) {
		if (prefabs.ContainsKey(tag)) {
			return prefabs[tag];
		}
		else {
			return null;
		}
	}
	
	//Return the total rate of production - consumption for a resource
	public float GetTotalRate(string n) {
		float r = 0;
		foreach (MapObject m in mapObjectList) {
			float rate = 0;
			switch (n) {
				case "Mass":
					rate = m.MassRate;
					break;
				case "Food":
					rate = m.FoodRate;
					break;
				case "Power":
					rate = m.PowerRate;
                    break;
			}
			if (rate < 9999) {
				r += rate;
			}
		}
		return r;
    }
    
    public void AddMass(float n) {
		mass += n;
	}
	
	public void AddFood(float n) {
		food += n;
	}
	
	public void AddPower(float n) {
		power += n;
	}
	
	public void AddPoints(int n) {
		points += n;
	}
	
	public bool SpendMass(float n) {
		if (mass >= n) {
			mass -= n;
			return true;
		}
		return false;
	}
	
	public bool SpendFood(float n) {
		if (food >= n) {
			food -= n;
			return true;
		}
		return false;
	}
	
	public bool SpendPower(float n) {
		if (power >= n) {
			power -= n;
			return true;
		}
		return false;
	}
	
	public float Stat(string key) {
		if (stats.ContainsKey(key)) {
			return stats[key];
		}
		else {
			return 0;
		}
	}

	public void AddMapObject(MapObject m) {
		mapObjectList.Add(m);
	}
	
	public void RemoveMapObject(MapObject m) {
		mapObjectList.Remove(m);
	}
}
