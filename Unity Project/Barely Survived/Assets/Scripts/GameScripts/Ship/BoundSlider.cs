using Mono.Xml.Xsl;
using System.Collections;
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
        _text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		_slider.value = (float) _shipMetrics.GetType().GetProperty(property).GetValue(_shipMetrics,null);;
        _text.text = _slider.value.ToString();
	}
}
