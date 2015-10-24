using Mono.Xml.Xsl;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Slider))]
public class BoundSlider : MonoBehaviour {
    public string property;
    private ShipMetrics _shipMetrics;
    private Slider _slider;
    private Text _text;

	// Use this for initialization
	void Start () {
		_shipMetrics = FindObjectOfType<ShipMetrics>();
        _slider = GetComponent<Slider>();
        List<Text> texts = new List<Text>(GetComponentsInChildren<Text>());
        _text = texts.Find(text => text.name == "Number");
	}
	
	// Update is called once per frame
	void Update () {
		_slider.value = (float) _shipMetrics.GetType().GetProperty(property).GetValue(_shipMetrics,null);;
        _text.text = _slider.value.ToString("F0");
	}
}
