using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> livingPeople;
    public List<GardenRoom> gardenRooms;
    public ShipMetrics shipMetrics;

	// Use this for initialization
	void Start () {
	    livingPeople = new List<GameObject>(GameObject.FindGameObjectsWithTag("Person"));
        gardenRooms = new List<GardenRoom>(FindObjectsOfType<GardenRoom>());
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
