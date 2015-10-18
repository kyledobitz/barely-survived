using UnityEngine;
using System.Collections;

public class RotatingFrame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public float period = 30.0F;
	public Vector3 axis = Vector3.up + Vector3.right;
	void Update() {
		float angle = 360 * Time.deltaTime / period;
		transform.rotation = transform.rotation * Quaternion.AngleAxis (angle, axis);
	}
}