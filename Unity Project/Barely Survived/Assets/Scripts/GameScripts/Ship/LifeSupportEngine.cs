using UnityEngine;
using System.Collections;

public class LifeSupportEngine : MonoBehaviour {

    public float lifeSupport;
    public float lifeSupportRate;
    public float startingLifeSupport = 100f;
	public float o2LossRate;
    public float medRaidRate;

    private GameManager gameManager;

	// Use this for initialization
	void Start () {
		lifeSupport = startingLifeSupport;
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        var lifeSupportLossRate = o2LossRate + medRaidRate;
        var lifeSupportProduction = 0f;
        foreach(LifeSupportRoom room in gameManager.lifeSupportRooms) {
            lifeSupportProduction += room.lifeSupportProduction;
        }
        lifeSupportRate = lifeSupportProduction - lifeSupportLossRate;
        lifeSupport += lifeSupportRate * Time.deltaTime;

	}
}
