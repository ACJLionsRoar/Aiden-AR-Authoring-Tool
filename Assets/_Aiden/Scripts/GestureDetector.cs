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
		if (Input.touchCount == 2 && PlayerPreferenceManager.getZoom () == 1) {//Check if total touches are 2
			detectZoom();
		}

		else if(Input.touchCount==2 && PlayerPreferenceManager.getRotation()==1)
		{
			detectRotation ();
		}

		else if(PlayerPreferenceManager.getTransfer()==1) {
			detectTransfer ();
		}
			
	}
		
	void detectZoom()
	{
		//Zoom In and Zoom Out Code
		Touch firstTouch = Input.GetTouch (0);//Take the first touch
		Touch secondTouch = Input.GetTouch (1);//Take the second touch

		Vector2 firstTouchPrevPos = firstTouch.position - (firstTouch.deltaPosition * 5);//Delta postion=Change in position
		Vector2 secondTouchPrevPos = secondTouch.position - (secondTouch.deltaPosition * 5);

		float prevTouchMagnitude = (firstTouchPrevPos - secondTouchPrevPos).magnitude;//Find magnitude difference of previous touches
		float currentTouchMagnitude = (firstTouch.position - secondTouch.position).magnitude;//Find magnitude difference of currentTouch
		float magnitudeDifference = prevTouchMagnitude - currentTouchMagnitude;//Find difference to detect pinch-in or pinch-out

		if (magnitudeDifference > 1) {
			//Pinch In-Zoom Decrease
			if (test.transform.localScale.x >= 0.05) {
				test.transform.localScale -= new Vector3 (zoomSpeed, zoomSpeed, zoomSpeed);//Decrease Size
			}
		} else {
			//Pinch Out-Zoom Increase
			if (test.transform.localScale.x <= 3) {
				test.transform.localScale += new Vector3 (zoomSpeed, zoomSpeed, zoomSpeed);//Increase size
			}
		}
	}

	void detectRotation()
	{
		//Rotation gesture
		if (!isRotating) {
			Vector2 startVector = Input.GetTouch (1).position - Input.GetTouch (0).position;
			isRotating = startVector.sqrMagnitude > minDistanceBetweenFingers * minDistanceBetweenFingers;
		} else {
			Vector2 currentVector = Input.GetTouch (1).position - Input.GetTouch (0).position;
		}
	}

	void detectTransfer()
	{
		//Transfer Gesture
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = 10;//Distance from camera to screen,Camera at -10 and screen at 0
		test.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
	}
}
