﻿using Mono.Xml.Xsl;
using System.Collections;
using UnityEngine;

public class PersonHealth : MonoBehaviour {

    public float maxHealth = 100f;
    public float health;
    public float corpseThickness = 0.2f;
    public float lifeSupportEffectRate = 5f;
    private LifeSupportEngine _lifeSupportEngine;

	// Use this for initialization
	void Start () {
		health = maxHealth;
        _lifeSupportEngine = FindObjectOfType<LifeSupportEngine>();
	}
	
	// Update is called once per frame
	void Update () {
        ApplyLifeSupportLevel();
        if(health <= 0){
            LeaveCorpse();
			AkSoundEngine.PostEvent("Test", gameObject);
        }
        if(health > maxHealth) {
            health = maxHealth;
        }
	}

    void ApplyLifeSupportLevel(){
        float healthPercentage = 100f * health / maxHealth;
        float supportVsHealthDiff = _lifeSupportEngine.lifeSupport - healthPercentage;
        if(_lifeSupportEngine.lifeSupport < healthPercentage){
            health -= lifeSupportEffectRate * Time.deltaTime;
        }else {
            health += lifeSupportEffectRate * Time.deltaTime;
        }

    }

    void LeaveCorpse(){
        var mesh = transform.Find("Mesh");
        mesh.LookAt(mesh.transform.position - mesh.transform.up, mesh.transform.position + mesh.transform.forward);
        mesh.localPosition = new Vector3(mesh.localPosition.x,corpseThickness,mesh.localPosition.z);
        mesh.SetParent(transform.parent);
        Destroy(gameObject);
    }

}
