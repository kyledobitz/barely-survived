using UnityEngine;

public class Repairs : MonoBehaviour {

    private Meanders meanders;
    public float repairRate = 10f;
    void Start(){
        meanders = GetComponent<Meanders>();
    }

    void Update(){
        if(meanders.currentRoom.health < 100f){
            meanders.currentRoom.health += repairRate * Time.deltaTime;
        }
    }
}
