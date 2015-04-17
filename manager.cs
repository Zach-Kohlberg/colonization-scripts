using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {
	private int food = 0, mass = 0, power = 0, beacons =0, factories =0, farms =0, workers =0, workerBuildLevel = 1, workerGatherLevel = 1;
	private List<GameObject> workersList, beaconsList, factoriesList, farmsList;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//Return the cost to create a specific building
	public int GetCost(string building) {
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
	//getters
	public int getFood() {
		return food;
	}

	public int getMass() {
		return mass;
	}

	public int getBeacons() {
		return beacons;
	}

	public int getFactories() {
		return factories;
	}

	public int getFarms() {
		return farms;
	}

	public int getWorkers() {
		return workers;
	}

	public int getWorkerGatherLevel() {
		return workerGatherLevel;
	}

	public int getWorkerBuildLeve() {
		return workerBuildLevel;
	}
	//setters
	public void setFood(int food) {
		this.food = food;
	}
	public void setMass(int mass) {
		this.mass = mass;
	}
	public void setBeacons(int beacons) {
		this.beacons = beacons;
	}
	public void setFactories(int factories) {
		this.factories = factories;
	}
	public void setFarms(int farms) {
		this.farms = farms;
	}
	public void setWorkers(int workers) {
		this.workers = workers;
	}
	public void setWorkerBuildLevel(int workerBuildLevel) {
		this.workerBuildLevel = workerBuildLevel;
	}
	public void setWorkerGatherLevel(int workerGatherLevel) {
		this.workerGatherLevel = workerGatherLevel;
	}
	//adders
	public void addWorker(GameObject worker) {
		workersList [workers] = worker;
		setWorkers (getWorkers ()+ 1);
	}
	public void addBeacon(GameObject beacon) {
		beaconsList [beacons] = beacon;
		setBeacons (getBeacons ()+ 1);
	}
	public void addFactory(GameObject factory) {
		factoriesList [factories] = factory;
		setFactories (getFactories ()+ 1);
	}
	public void addFarm(GameObject farm) {
		farmsList [farms] = farm;
		setFarms (getFarms ()+ 1);
	}
}
