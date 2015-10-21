using UnityEngine;
using System.Collections;

public class Sprite : MonoBehaviour {

    public Camera currentCamera;
	// Use this for initialization
	void Start () {
		if(currentCamera == null){
            currentCamera = FindObjectOfType<Camera>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = currentCamera.transform.rotation;
	}
}
