using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Selector : MonoBehaviour {

    public GameObject target;
    public Vector3 offset = Vector3.zero;

    private Camera _camera;
    private RectTransform _rectTransform;
    private GameManager _gameManager;
    private Button _button;

	// Use this for initialization
	void Start () {
        _camera = FindObjectOfType<Camera>();
		_rectTransform = GetComponent<RectTransform>();
        _gameManager = FindObjectOfType<GameManager>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Selected);
	}
	
	// Update is called once per frame
	void Update () {
        var pos = target.transform.position + offset;
        Vector3 screenPos = _camera.WorldToScreenPoint(pos);
		_rectTransform.position = screenPos;
	}

    void Selected(){
		_gameManager.selected = target;
    }

    void Assigned(){

    }
}
