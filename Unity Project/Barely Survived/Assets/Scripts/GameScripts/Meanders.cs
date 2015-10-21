using UnityEngine;
using System.Collections;

public class Meanders : MonoBehaviour {

	public RoundRoom currentRoom;
	public float speed = 2.0f;

	private Vector3 destination{
        get {
            return currentRoom.getAbsoluteSpot(relativeDestination);
        }
    }

    private Vector2 relativeDestination;
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
        if (state != State.STANDING) {
            Move ();
        }
	}
	
	bool IsAtDestination ()
	{
		return (transform.position - destination).magnitude < 0.2f;
	}
	
	void ChooseMeanderDestination ()
	{
        relativeDestination = currentRoom.getRandomSpot();
        heading = (destination - transform.position).normalized;
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
        var pathLeft = destination - transform.position;
		if (pathLeft.magnitude < 0.1f)
			return;
        transform.LookAt(transform.position + heading,currentRoom.transform.up);
		velocity = heading * speed;
		transform.position += Time.deltaTime * velocity;
        transform.position = currentRoom.onTheGround(transform.position);
	}
	
	public enum State
	{
		MEANDERING,
		STANDING,
		GOING_TO_DOOR
	}
}
