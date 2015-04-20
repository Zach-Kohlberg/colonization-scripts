using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class manager : MonoBehaviour {



	private int food = 100, power = 0, mass = 0, beacons =0, factories =0, farms =0, workers =0, workerBuildLevel = 1, workerGatherLevel = 1;
	private List<GameObject> workersList, beaconsList, factoriesList, farmsList;

	public void addMass(int n) {
		Mass = Mass + n;
	}

	public int spendMass(int n) {
		if (Mass >= n) {
			Mass = Mass - n;
			return n;
		}
		else {
			return 0;
		}
	}

	
	//Return the cost to create a specific unit or building
	public int GetCost(string obj) {
		return 100;
	}
	
	public void AddMass(int n) {
		mass += n;
	}
	
	public void AddFood(int n) {
		food += n;
	}
	
	public void AddPower(int n) {
		power += n;
	}
	
	public int SpendMass(int n) {
		if (mass >= n) {
			mass -= n;
			return n;
		}
		else {
			return 0;
		}
	}
	
	public int SpendFood(int n) {
		if (food >= n) {
			food -= n;
			return n;
		}
		else {
			return 0;
		}
	}
	
	public int SpendPower(int n) {
		if (power >= n) {
			power -= n;
			return n;
		}
		else {
			return 0;
		}
	}

	public int Food {
		get { return food; }
		set { food = value; }
	}

	public int Mass {
		get { return mass; }
		set { mass = value; }
	}

	public int Beacons {
		get { return beacons; }
		set { beacons = value; }
	}

	public int Factories {
		get { return factories; }
		set { factories = value; }
	}

	public int Farms {
		get { return farms; }
		set { farms = value; }
	}

	public int Power {
		get { return power; }
		set { power = value; }
	}

	public int Workers {
		get { return workers; }
		set { workers = value; }
	}

	public int WorkerGathererLevel {
		get { return workerGatherLevel; }
		set { workerGatherLevel = value; }
	}

	public int WorkerBuildLevel {
		get { return workerBuildLevel; }
		set { workerBuildLevel = value; }
	}

	public void addWorker(GameObject worker) {
		workersList [Workers] = worker;
		Workers = Workers + 1;
	}
	public void addBeacon(GameObject beacon) {
		beaconsList [Beacons] = beacon;
		Beacons = Beacons + 1;
	}
	public void addFactory(GameObject factory) {
		factoriesList [Factories] = factory;
		Factories = Factories + 1;
	}
	public void addFarm(GameObject farm) {
		farmsList [Farms] = farm;
		Farms = Farms + 1;
	}
}
