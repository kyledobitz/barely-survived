using UnityEngine;
using System.Collections;

[RequireComponent (typeof (FoodEngine),typeof (FuelEngine),typeof (LifeSupportEngine))]
public class ShipMetrics : MonoBehaviour {

	public FoodEngine foodEngine;
    public FuelEngine fuelEngine;
    public LifeSupportEngine lifeSupportEngine;

    public float food{ get{ return foodEngine.food; } }
    public float fuel{ get{ return fuelEngine.fuel; } }
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
