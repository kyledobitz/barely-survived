using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHealthBar : MonoBehaviour {

    private Room room;
    public GameObject statusBar;
    public SpriteRenderer[] renderers;

	// Use this for initialization
	void Start () {
        setBarEnabled(false);
		room = GetComponentInParent<Room>();
        renderers = GetComponentsInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if(room.health <= 0){
            setBarEnabled(false);
            return;
        }
		if(100f - room.health > 1){
            setBarEnabled(true);
            var scale = statusBar.transform.localScale;
            var healthPercent = room.health/100f;
            statusBar.transform.localScale = new Vector3(healthPercent,scale.y,scale.z);
        }else{
            setBarEnabled(false);
        }
	}

    void setBarEnabled(bool enabled){
        foreach(SpriteRenderer renderer in renderers){
            renderer.enabled = enabled;
        }
    }
}
