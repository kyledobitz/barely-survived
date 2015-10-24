using System.Collections;
using UnityEngine;

[RequireComponent (typeof (FoodEngine),typeof (FuelEngine),typeof (LifeSupportEngine))]
public class ShipMetrics : MonoBehaviour {

	public FoodEngine foodEngine;
    public FuelEngine fuelEngine;
    public LifeSupportEngine lifeSupportEngine;

    public FuelEngine.ThrustSetting thrustSetting{
        get{ return fuelEngine.thrustSetting; }
        set{ fuelEngine.thrustSetting = value; }
    }
    public float fuel{ get{ return fuelEngine.fuel; } }
    public float food{ get{ return foodEngine.food; } }
    public float lifeSupport{ get{ return lifeSupportEngine.lifeSupport; } }

	// Use this for initialization
	void Start () {
        foodEngine = GetComponent<FoodEngine>();
        fuelEngine = GetComponent<FuelEngine>();
        lifeSupportEngine = GetComponent<LifeSupportEngine>();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
