using UnityEngine;

public class Asteroid : MonoBehaviour{

    public Vector3 destination;
    public Vector3 velocity;
    public float speed = 10f;
    public Room targetRoom;
    public Spawner _spawner;
    public float damage = 75f;

    void Start(){
        _spawner = FindObjectOfType<Spawner>();
        targetRoom = _spawner._rooms[Random.Range(0, _spawner._rooms.Count)];
        destination = targetRoom.transform.position;
        transform.position = targetRoom.transform.up*50f + targetRoom.transform.position;
    }

    void Update(){
        if(IsAtDestination()) {
            targetRoom.AsteroidImpact(damage);
            Destroy(gameObject);
        }
        else
            Move();
    }

    bool IsAtDestination ()
    {
        return (transform.position - destination).magnitude < 5f;
    }

    void Move ()
    {
        var pathLeft = destination - transform.position;
        if (pathLeft.magnitude < 0.1f)
            return;
        velocity = pathLeft.normalized * speed;
        transform.position += Time.deltaTime * velocity;
    }
}
