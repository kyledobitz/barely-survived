using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    public List<GameObject> members;
    public float radius;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
    }

    public Vector2 getRandomSpot(){
        return Random.insideUnitCircle * radius;
    }

    public Vector3 getAbsoluteSpot(Vector2 relativeSpot){
        return transform.localToWorldMatrix.MultiplyPoint3x4(
        new Vector3(relativeSpot.x,0,relativeSpot.y)
        );
    }

    public Vector3 onTheGround(Vector3 absoluteSpot){
        var localVector = transform.worldToLocalMatrix.MultiplyPoint3x4(absoluteSpot);
        return transform.localToWorldMatrix.MultiplyPoint3x4(
        new Vector3(localVector.x,0,localVector.z)
        );
    }

    public void Assign(GameObject assignee){
        Meanders meanderer = assignee.GetComponent<Meanders>();
        meanderer.currentRoom = this;
        members.Add(assignee);
    }
}
