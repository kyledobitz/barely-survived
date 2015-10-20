using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

    public Collider currentRoom;

	// Use this for initialization
	void Start () {
        currentRoom = GetComponentInChildren<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Vector2 getRandomSpot(){
        Vector3 min = transform.worldToLocalMatrix.MultiplyPoint3x4(currentRoom.bounds.min);
        Vector3 max = transform.worldToLocalMatrix.MultiplyPoint3x4(currentRoom.bounds.max);

        var minX = min.x;
        var minZ = min.z;
        var maxX = max.x;
        var maxZ = max.z;
        Debug.Log(string.Format("min and max: ({0},{1}) ({2},{3})",minX,maxX,minZ,maxZ));
        return new Vector2 (Random.Range (minX, maxX), Random.Range (minZ, maxZ));
    }

    public Vector3 getAbsoluteSpot(Vector2 relativeSpot){
		return transform.localToWorldMatrix.MultiplyPoint3x4(
        	new Vector3(relativeSpot.x,0,relativeSpot.y)
        );
    }
}
