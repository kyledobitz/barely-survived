using UnityEngine;
using System.Collections;

public class FuelEngine : MonoBehaviour {

    public float fuel;
    public float startingFuel = 100f;
    public ThrustSetting thrustSetting;

	// Use this for initialization
	void Start () {
	    thrustSetting = ThrustSetting.MED;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public enum ThrustSetting{
        DRIFT,
        LOW,
        MED,
        HIGH,
        WARP
    }
}
