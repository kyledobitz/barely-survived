using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenRoom : MonoBehaviour {
    public float foodGrowth = 0f;
    public float foodGrowthRate = 10f;
    public List<GameObject> gardeners;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        foodGrowth = (float) gardeners.Count * foodGrowthRate;
    }
}
