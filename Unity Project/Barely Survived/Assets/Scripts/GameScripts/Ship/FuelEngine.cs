using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelEngine : MonoBehaviour {

    public float fuel;
    public float fuelRate;
    public float startingFuel = 100f;
    public ThrustSetting thrustSetting;

    Dictionary <ThrustSetting,float> burnCostMap = new Dictionary<ThrustSetting,float>(){
        { ThrustSetting.DRIFT, 0f },
        { ThrustSetting.LOW, 1.0f },
        { ThrustSetting.MED, 2.0f },
        { ThrustSetting.HIGH, 4.0f },
        { ThrustSetting.WARP, 10.0f },
    };

	// Use this for initialization
	void Start () {
        fuel = startingFuel;
	    thrustSetting = ThrustSetting.MED;
        fuelRate = - burnCostMap[thrustSetting];
	}
	
	// Update is called once per frame
	void Update () {
        fuelRate = - burnCostMap[thrustSetting];
        fuel += fuelRate*Time.deltaTime/2f;
	}

    public enum ThrustSetting{
        DRIFT,
        LOW,
        MED,
        HIGH,
        WARP
    }
}
