using UnityEngine;

public class AssignerBinder : MonoBehaviour   {

    public GameObject assignerPrefab;
    private GameObject _assigner;
    private GameObject _gui;

    void Awake () {
        _gui = GameObject.FindGameObjectWithTag("GUI");
        _assigner = (GameObject) Instantiate(assignerPrefab);
        _assigner.GetComponent<Assigner>().target = GetComponent<Room>().gameObject;
        _assigner.transform.SetParent(_gui.transform);
        _assigner.transform.SetAsFirstSibling();
    }

    void Update () {

    }
}
