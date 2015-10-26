using Mono.Xml.Xsl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public ShipMetrics shipMetrics;
    public List<GameObject> livingPeople;
    public List<GardenRoom> gardenRooms;
    public List<LifeSupportRoom> lifeSupportRooms;

    public List<Assigner> assigners;
    public List<Selector> selectors;

    public GameObject selected;

    private GameObject _gameplay;
    private GameObject _logo;
    private GameObject _credits;

    public Phase phase = Phase.LOGO;
    public float logoTime = 2.0f;
    private float _logoEndTime;
    public float creditsTime = 2.0f;
    private float _creditsEndTime;

	// Use this for initialization
	void Start () {
        shipMetrics = GetComponentInChildren<ShipMetrics>();
        livingPeople = new List<GameObject>(GameObject.FindGameObjectsWithTag("Person"));
        gardenRooms = new List<GardenRoom>(FindObjectsOfType<GardenRoom>());
        lifeSupportRooms = new List<LifeSupportRoom>(FindObjectsOfType<LifeSupportRoom>());

        assigners = new List<Assigner>(FindObjectsOfType<Assigner>());
        selectors = new List<Selector>(FindObjectsOfType<Selector>());
        
        _gameplay = GameObject.FindGameObjectWithTag("Gameplay");
        _logo = GameObject.FindGameObjectWithTag("Logo");
        _credits = GameObject.FindGameObjectWithTag("Credits");

        _logoEndTime = Time.time + logoTime;
        Debug.Log("logoEndTime: " + _logoEndTime);
	}
    public void CheckPhaseTransitions(){
        switch (phase){
            case Phase.LOGO :
				AkSoundEngine.SetState("music_state", "start_menu");
                Debug.Log("logoEndTime: " + _logoEndTime);
                if (Time.time > _logoEndTime && Input.anyKeyDown) {
                    phase = Phase.BUILD;
                }
            break;
            case Phase.BUILD :
				AkSoundEngine.SetState("music_state", "normal");
                phase = Phase.PLAY;
            break;
            case Phase.PLAY :
				AkSoundEngine.SetState("music_state", "normal");
                if(livingPeople.Count < 1){
                    phase = Phase.CREDITS;
                    _creditsEndTime = Time.time + creditsTime;
                }
            break;
            case Phase.CREDITS :
            if (Time.time > _logoEndTime && Input.anyKeyDown) {
                phase = Phase.BUILD;
                _logo.SetActive (false);
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                    Application.Quit();
                #endif
            }
            break;
        }
    }

    public void ImplementPhase(){
        _logo.SetActive(phase == Phase.LOGO);
        _gameplay.SetActive(phase == Phase.PLAY);
        if(phase == Phase.PLAY) {
            TrimDeadPeople();
            ManageSelectorVisibility();
        }
        _credits.SetActive(phase == Phase.CREDITS);
    }

	// Update is called once per frame
	void Update () {
        CheckPhaseTransitions();
        ImplementPhase();
        if (Input.GetMouseButtonDown(1)) //Cancel selection with right click
            selected = null;
	}

    void TrimDeadPeople(){
        livingPeople.RemoveAll (item => item == null);
        livingPeople.RemoveAll (person =>
            person.GetComponentInChildren<PersonHealth>().health < 0
        );
    }

    void ManageSelectorVisibility(){
        foreach (Assigner assigner in assigners)
            assigner.gameObject.SetActive(selected != null);

        foreach (Selector selector in selectors) {
            bool visible = selected == null || selector.target == selected;
            selector.gameObject.SetActive(visible);
        }
    }

    public enum Phase
    {
        LOGO,
        BUILD,
        PLAY,
        CREDITS
    }
}
