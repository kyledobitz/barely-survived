using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSupportRoom : MonoBehaviour {
    public float lifeSupportProduction = 0f;
    public float lifeSupportProductionRate = 10f;
    private Room _room;

	// Use this for initialization
	void Start () {
        _room = GetComponent<Room>();
	}
	
	// Update is called once per frame
	void Update () {
        lifeSupportProduction = (float) _room.members.Count * lifeSupportProductionRate;
	}
}
