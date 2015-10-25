using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSupportRoom : MonoBehaviour {
    public float lifeSupportProduction = 0f;
    public float lifeSupportProductionRate = 10f;
    public List<GameObject> lifeSupporters;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        lifeSupportProduction = (float) lifeSupporters.Count * lifeSupportProductionRate;
	}
}
