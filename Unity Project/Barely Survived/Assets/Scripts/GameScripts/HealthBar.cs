using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    private PersonHealth personHealth;
    public GameObject statusBar;
    public SpriteRenderer[] renderers;

	// Use this for initialization
	void Start () {
        setBarEnabled(false);
		personHealth = GetComponentInParent<PersonHealth>();
        renderers = GetComponentsInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if(personHealth.health <= 0){
            setBarEnabled(false);
            return;
        }
		if(personHealth.maxHealth - personHealth.health > 1){
            setBarEnabled(true);
            var scale = statusBar.transform.localScale;
            var healthPercent = personHealth.health/personHealth.maxHealth;
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
