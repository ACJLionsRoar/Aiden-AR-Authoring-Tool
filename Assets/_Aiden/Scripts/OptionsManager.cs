using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsManager : MonoBehaviour {

	Slider mergeSlider,occlusionSlider,rotationSlider,zoomSlider,transferSlider;

	// Use this for initialization
	void Start () {
		mergeSlider.value = 1;//To be changed
		occlusionSlider.value = 1;//To be changed
		rotationSlider.value = 1;//To be changed
		zoomSlider.value = 1;//To be changed
		transferSlider.value = 1;//To be changed
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
