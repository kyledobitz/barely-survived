using UnityEngine;
using System.Collections;

[RequireComponent (typeof (FuelEngine))]
public class ThrustParticles : MonoBehaviour {
    private ParticleSystem _thrustParticleSystem;
    private FuelEngine _fuelEngine;

	// Use this for initialization
	void Start () {
//		_thrustParticleSystem = GameObject.FindGameObjectWithTag("ThrustParticleSystem").GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
