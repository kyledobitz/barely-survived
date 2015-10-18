using UnityEngine;
using System.Collections;

public class Meanders : MonoBehaviour {

	public Collider currentRoom;

	public float speed = 2.0f;

	private Vector3 destination;
	private Vector3 velocity;
	private Vector3 heading;

	public float standVsMeanderPercent=0.5f;
	public float minDelayTime=1.0f;
	public float maxDelayTime=2.0f;
	private float nextDecisionTime;
	private State state = State.STANDING;

	// Use this for initialization
	void Start () {
		nextDecisionTime = Time.time;	
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
		case State.STANDING:
			if (Time.time > nextDecisionTime) {
				nextDecisionTime = getNextDecisionTime ();
				state = DecideNextState ();
			}
			velocity = Vector3.zero;
			break;
		case State.MEANDERING:
			if (Time.time > nextDecisionTime || IsAtDestination ()) {
				nextDecisionTime = getNextDecisionTime ();
				state = DecideNextState ();
			}
			break;
		}
	}
	
	bool IsAtDestination ()
	{
		return (transform.position - destination).magnitude < 0.2f;
	}
	
	void ChooseMeanderDestination ()
	{
		var minX = currentRoom.bounds.min.x;
		var minZ = currentRoom.bounds.min.z;
		var maxX = currentRoom.bounds.max.x;
		var maxZ = currentRoom.bounds.max.z;
		destination = new Vector3 (Random.Range (minX, maxX), transform.position.y, Random.Range (minZ, maxZ));
	}
		
	float getNextDecisionTime ()
	{
		return Time.time + Random.Range (minDelayTime, maxDelayTime);
	}

	State DecideNextState ()
	{
		if (Random.value < standVsMeanderPercent) {
			return State.STANDING;
		} else {
			ChooseMeanderDestination ();
			return State.MEANDERING;
		}
	}
	
	void Move ()
	{
		if ((transform.position - destination).magnitude < 0.1f) 
			return;
		heading = (destination - transform.position).normalized;
		transform.forward = heading;
		velocity = heading * speed;
		transform.position += Time.deltaTime * velocity;
	}
	
	public enum State
	{
		MEANDERING,
		STANDING,
		GOING_TO_DOOR
	}
}
