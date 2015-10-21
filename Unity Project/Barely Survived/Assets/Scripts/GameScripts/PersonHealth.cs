using UnityEngine;
using System.Collections;

public class PersonHealth : MonoBehaviour {

    public float maxHealth = 100f;
    public float health;

	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
//		health += - Time.deltaTime*10;
	}
}
