using Mono.Xml.Xsl;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class BoundRate : MonoBehaviour {
    public string property;
    private ShipMetrics _shipMetrics;
    private Text _text;

	// Use this for initialization
	void Start () {
		_shipMetrics = FindObjectOfType<ShipMetrics>();
        _text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        float rate = (float) _shipMetrics.GetType().GetProperty(property).GetValue(_shipMetrics,null);
        bool negative = rate < 0f;

        if(negative) {
            _text.color = Color.red;
            _text.text = "- " + Mathf.Abs(rate).ToString("F0");
        }
        else {
            _text.color = Color.green;
            _text.text = "+ " + Mathf.Abs(rate).ToString("F0");
        }
	}
}
