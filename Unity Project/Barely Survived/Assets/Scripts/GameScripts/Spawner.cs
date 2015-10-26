using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject gardenerPrefab;
    public int gardenerCount;
    public GameObject scientistPrefab;
    public int scientistCount;
    public GameObject engineerPrefab;
    public int engineerCount;
    public GameObject captainPrefab;
    public int captainCount;
    public GameObject soldierPrefab;
    public int soldierCount;

    public GameObject gardenPrefab;
    public int extraGardens = 0;
    public GameObject lifeSupportPrefab;
    public int extraLifeSupport = 0;
    public GameObject enginesPrefab;
    public int extraEngines = 0;

    public float roomWidth = 10f;

    private GameObject _gameplay;
    public List<Room> _rooms;

    public GameObject asteroidPrefab;
    public float lastAsteroidTime;
    public float asteroidPeriod = 3f;

    void Update(){
    }

    void Awake(){
        _gameplay = GameObject.FindGameObjectWithTag("Gameplay");
        GenerateRooms();
        _rooms = new List<Room>(FindObjectsOfType<Room>());
        GenerateCrew();
    }

    void GenerateCrew(){
        InstanciatePeople(captainCount, captainPrefab);
        InstanciatePeople(gardenerCount, gardenerPrefab);
        InstanciatePeople(scientistCount, scientistPrefab);
        InstanciatePeople(engineerCount, engineerPrefab);
        InstanciatePeople(soldierCount, soldierPrefab);
    }

    void InstanciatePeople(int peopleCount, GameObject personPrefab){
        for (int i = 0; i < peopleCount; i++){
            Room randomRoom = _rooms[Random.Range(0, _rooms.Count)];
            Vector3 spot = randomRoom.getAbsoluteSpot(randomRoom.getRandomSpot());
            GameObject person = (GameObject) Instantiate(personPrefab);
            person.transform.SetParent(_gameplay.transform);
            person.transform.position = spot;
            randomRoom.Assign(person);
        }
    }

    void GenerateRooms(){
        InstanciateRooms(extraGardens, 0, gardenPrefab);
        InstanciateRooms(extraLifeSupport, 1, lifeSupportPrefab);
        InstanciateRooms(extraEngines, 2, enginesPrefab);
    }

    void InstanciateRooms(int numberExtra, int spotsFromBridge, GameObject prefab){
        List<Vector3> spots = GetRoomSpots(numberExtra, spotsFromBridge);
        foreach(Vector3 spot in spots){
            GameObject room = (GameObject) Instantiate(prefab);
            room.transform.SetParent(_gameplay.transform);
            room.transform.position = spot;
        }
    }

    List<Vector3> GetRoomSpots(int number, int spotsFromBridge){
        float xPos = - roomWidth * (float) spotsFromBridge;
        float yPos = 0f;
        List<Vector3> roomSpots = new List<Vector3>();
        for(int i = 0; i < number; i++){
            float zPos;
            int roundDown = i/2;
            if(i % 2 == 1){ //If odd go positive z
                zPos = (roundDown + 1) * roomWidth;
            }else{ // If even go negative z
                zPos = - (roundDown + 1) * roomWidth;
            }
            roomSpots.Add(new Vector3(xPos,yPos,zPos));
        }
        return roomSpots;
    }
}
