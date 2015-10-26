using UnityEngine;
using UnityEngine.UI;

public class Assigner : MonoBehaviour {

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
        _button.onClick.AddListener(Assigned);

    }

    // Update is called once per frame
    void Update () {

        var pos = target.transform.position + offset;
        Vector3 screenPos = _camera.WorldToScreenPoint(pos);
        _rectTransform.position = screenPos;
    }

    void Assigned(){
        Room room = target.GetComponent<Room>();
        room.Assign(_gameManager.selected);
        _gameManager.selected = null;
    }
}
