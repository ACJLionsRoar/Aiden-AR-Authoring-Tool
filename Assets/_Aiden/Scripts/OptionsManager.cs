using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsManager : MonoBehaviour {

	public Slider mergeSlider,occlusionSlider,rotationSlider,zoomSlider,transferSlider;

	// Use this for initialization
	void Start () {
		mergeSlider.value = PlayerPreferenceManager.getMerge();
		occlusionSlider.value = PlayerPreferenceManager.getOcclusion ();
		rotationSlider.value = PlayerPreferenceManager.getRotation ();
		zoomSlider.value = PlayerPreferenceManager.getZoom ();
		transferSlider.value = PlayerPreferenceManager.getTransfer ();
	}
	
	public void saveOptions()
	{
		PlayerPreferenceManager.setMerge (mergeSlider.value);
		PlayerPreferenceManager.setOcclusion (occlusionSlider.value);
		PlayerPreferenceManager.setRotation (rotationSlider.value);
		PlayerPreferenceManager.setTransfer (transferSlider.value);
		PlayerPreferenceManager.setZoom (zoomSlider.value);
	}

	public void complementButton(string name)
	{
		if (name == "ZOOM") {
			if (zoomSlider.value == 1) {
				rotationSlider.value = 0;
			} else {
				rotationSlider.value = 1;
			}
		} else if (name == "ROTATION") {
			if (rotationSlider.value == 1) {
				zoomSlider.value = 0;
			} else {
				zoomSlider.value = 1;
			}
		}
	}
}
