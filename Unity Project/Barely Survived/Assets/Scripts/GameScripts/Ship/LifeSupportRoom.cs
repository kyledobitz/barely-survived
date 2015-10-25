using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSupportRoom : MonoBehaviour {
    public float lifeSupportProduction = 0f;
    public float lifeSupportProductionRate = 10f;
    public float medsConsumptionRate = 1f;

    private Room _room;
    private GameManager _gameManager;

	// Use this for initialization
	void Start () {
        _gameManager = FindObjectOfType<GameManager>();
        _room = GetComponent<Room>();
	}
	
	// Update is called once per frame
	void Update () {
        float medsConsumption = (float) _gameManager.livingPeople.Count * medsConsumptionRate;
        lifeSupportProduction = (float) _room.members.Count *lifeSupportProductionRate - medsConsumption;
	}
}
