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
}
