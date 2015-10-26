using UnityEngine;

public class SelectorBinder : MonoBehaviour  {
    public GameObject selectorPrefab;
    private GameObject _selector;
    private GameObject _gui;

    void Awake () {
        _gui = GameObject.FindGameObjectWithTag("GUI");
        _selector = (GameObject) Instantiate(selectorPrefab);
        _selector.GetComponent<Selector>().target = GetComponent<Meanders>().gameObject;
        _selector.transform.SetParent(_gui.transform);
        _selector.transform.SetAsFirstSibling();
    }

    void Update () {

    }
}
