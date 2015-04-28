using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {
	
	public float foodStart, powerStart, massStart;
	
	private float food, power, mass;
	private int workerBuildLevel, workerGatherLevel;
	private List<MapObject> mapObjectList;
	
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
	public int WorkerGathererLevel {
		get { return workerGatherLevel; }
		set { workerGatherLevel = value; }
	}
	public int WorkerBuildLevel {
		get { return workerBuildLevel; }
		set { workerBuildLevel = value; }
	}
	
	private void ManagerInit() {
		food = foodStart;
		mass = massStart;
		power = powerStart;
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
	
	//Return the cost to create a specific unit or building
	public int GetCost(string tag) {
		return 100;
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

	public void addMapObject(Unit m) {
		mapObjectList.Add(m);
	}
	
	public void removeMapObject(MapObject m) {
		mapObjectList.Remove(m);
	}
}
