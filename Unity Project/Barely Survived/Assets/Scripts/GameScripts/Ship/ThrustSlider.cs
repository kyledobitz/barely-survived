using System.Collections;
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
    }
}
