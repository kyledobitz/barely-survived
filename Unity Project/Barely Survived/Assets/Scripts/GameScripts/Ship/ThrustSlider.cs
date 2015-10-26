using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrustSlider : MonoBehaviour {

    private Slider _slider;
    private Text _text;
    private ShipMetrics _shipMetrics;

	// Use this for initialization
	void Start () {
		_slider = GetComponent<Slider>();
        _text = GetComponentInChildren<Text>();
        List<Text> texts = new List<Text>(GetComponentsInChildren<Text>());
        _text = texts.Find(text => text.name == "Setting");
        _slider.onValueChanged.AddListener(SetThrust);
        _shipMetrics = FindObjectOfType<ShipMetrics>();
	}
	
	// Update is called once per frame
	void Update () {
		_text.text = _shipMetrics.thrustSetting.ToString();
        _slider.value = (float) _shipMetrics.thrustSetting;
	}

    void SetThrust(float thrust){
        _shipMetrics.thrustSetting = (FuelEngine.ThrustSetting) thrust;
        _shipMetrics.thrustSetting.ToString();
    }
}
