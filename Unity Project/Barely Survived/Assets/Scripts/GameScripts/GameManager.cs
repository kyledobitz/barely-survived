using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> livingPeople;
    public List<GardenRoom> gardenRooms;
    public List<LifeSupportRoom> lifeSupportRooms;
    public ShipMetrics shipMetrics;
    public GameObject selected;

	// Use this for initialization
	void Start () {
	    livingPeople = new List<GameObject>(GameObject.FindGameObjectsWithTag("Person"));
        gardenRooms = new List<GardenRoom>(FindObjectsOfType<GardenRoom>());
        lifeSupportRooms = new List<LifeSupportRoom>(FindObjectsOfType<LifeSupportRoom>());
        shipMetrics = GetComponentInChildren<ShipMetrics>();
	}

	// Update is called once per frame
	void Update () {
        TrimDeadPeople();
	}

    void TrimDeadPeople(){
        livingPeople.RemoveAll (item => item == null);
        livingPeople.RemoveAll (person =>
            person.GetComponentInChildren<PersonHealth>().health < 0
        );
    }
}
