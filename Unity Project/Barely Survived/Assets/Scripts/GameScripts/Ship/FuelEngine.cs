using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelEngine : MonoBehaviour {

    public float fuel;
    public float fuelRate;
    public float distanceTraveled;
    public float speed;
    public float startingFuel = 1000f;
    public ThrustSetting thrustSetting;
    public float mediumCompletionTime = 600f;
    private float _totalDistance = 1000f;
    private float _referenceStartingFuel = 1000f;
    private float _mediumReferenceSpeed;
    private float _mediumReferenceFuelRate;

    Dictionary <ThrustSetting,float> burnCostMap = new Dictionary<ThrustSetting,float>(){
        { ThrustSetting.DRIFT, 0f },
        { ThrustSetting.LOW, 1.0f },
        { ThrustSetting.MED, 2.0f },
        { ThrustSetting.HIGH, 4.0f },
        { ThrustSetting.WARP, 10.0f },
    };
    Dictionary <ThrustSetting,float> speedMap = new Dictionary<ThrustSetting,float>(){
        { ThrustSetting.DRIFT, 1.0f },
        { ThrustSetting.LOW, 3.0f },
        { ThrustSetting.MED, 5.0f },
        { ThrustSetting.HIGH, 8.0f },
        { ThrustSetting.WARP, 10.0f },
    };

	// Use this for initialization
	void Start () {
        distanceTraveled = 0f;
        _totalDistance = 1000f;
        _mediumReferenceSpeed = _totalDistance/mediumCompletionTime;
        _mediumReferenceFuelRate = _referenceStartingFuel/mediumCompletionTime;

        fuel = startingFuel;
	    thrustSetting = ThrustSetting.MED;

        fuelRate = - burnCostMap[thrustSetting];
        speed = speedMap[thrustSetting];
	}
	
	// Update is called once per frame
	void Update () {
        float fuelRateRelativeToMedium = burnCostMap[thrustSetting] / burnCostMap[ThrustSetting.MED];
        fuelRate = - fuelRateRelativeToMedium * _mediumReferenceFuelRate;
        fuel += fuelRate * Time.deltaTime;

        float speedRelativeToMedium = speedMap[thrustSetting] / speedMap[ThrustSetting.MED];
        speed = speedRelativeToMedium * _mediumReferenceSpeed;
        distanceTraveled += speed * Time.deltaTime;
	}

    public enum ThrustSetting{
        DRIFT,
        LOW,
        MED,
        HIGH,
        WARP
    }
}
