using UnityEngine;
using System.Collections;

public class PersonHealth : MonoBehaviour {

    public float maxHealth = 100f;
    public float health;
    public float corpseThickness = 0.2f;

	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		health += - Time.deltaTime * 10;
        if(health <= 0){
            LeaveCorpse();
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
