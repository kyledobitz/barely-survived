using UnityEngine;
using System.Collections;

public class FoodEngine : MonoBehaviour {

    public float food;
    public float startingFood = 100f;
    
    public float personConsumptionRate = 1f;

    private GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		var peopleAte = (float) gameManager.livingPeople.Count * personConsumptionRate;
        var gardensGrew = 0f;
        foreach(GardenRoom garden in gameManager.gardenRooms) {
            gardensGrew += garden.foodGrowth;
        }
        food += (gardensGrew - peopleAte) * Time.deltaTime;
	}
}
