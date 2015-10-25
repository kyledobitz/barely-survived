using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenRoom : MonoBehaviour {
    public float foodGrowth = 0f;
    public float foodGrowthRate = 10f;

    private Room _room;

	// Use this for initialization
	void Start () {
	    _room = GetComponent<Room>();
	}
	
	// Update is called once per frame
	void Update () {
        foodGrowth = (float) _room.members.Count * foodGrowthRate;
    }
}
