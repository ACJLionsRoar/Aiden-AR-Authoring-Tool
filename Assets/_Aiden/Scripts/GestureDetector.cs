using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GestureDetector : MonoBehaviour {

	public GameObject test;
	public Text testText;
	bool isRotating;
	Vector2 startVector;
	float minDistanceBetweenFingers,minAngle;


	float zoomSpeed=0.05f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 2) {


			//Zoom In and Zoom Out Code
			Touch firstTouch = Input.GetTouch (0);
			Touch secondTouch = Input.GetTouch (1);

			Vector2 firstTouchPrevPos = firstTouch.position - (firstTouch.deltaPosition*5);
			Vector2 secondTouchPrevPos = secondTouch.position - (secondTouch.deltaPosition*5);

			float prevTouchMagnitude = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
			float currentTouchMagnitude = (firstTouch.position - secondTouch.position).magnitude;
			float magnitudeDifference = prevTouchMagnitude - currentTouchMagnitude;

			if (magnitudeDifference > 0) {
				//Pinch In-Zoom Decrease
				if (test.transform.localScale.x >= 0.05) {
					test.transform.localScale -= new Vector3 (zoomSpeed, zoomSpeed, zoomSpeed);
				}
			} else {
				//Pinch Out-Zoom Increase
				if (test.transform.localScale.x <= 3) {
					test.transform.localScale += new Vector3 (zoomSpeed, zoomSpeed, zoomSpeed);
				}
			}
				
		}
			
	}
}
