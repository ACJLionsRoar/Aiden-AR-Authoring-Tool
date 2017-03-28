using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GestureDetector : MonoBehaviour {

	public Text testText;
	static GameObject objectDetected;
	bool isRotating;
	Vector2 startVector;
	float minDistanceBetweenFingers,minAngle;

	float zoomSpeed=0.05f;
	
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
			if (objectDetected != null) {
				if (objectDetected.transform.localScale.x >= 0.05) {
					objectDetected.transform.localScale -= new Vector3 (zoomSpeed, zoomSpeed, zoomSpeed);//Decrease Size
				} else {
					//Pinch Out-Zoom Increase
					if (objectDetected.transform.localScale.x <= 3) {
						objectDetected.transform.localScale += new Vector3 (zoomSpeed, zoomSpeed, zoomSpeed);//Increase size
					}
				}
			}
		}
	}

	void detectRotation()
	{
		if (objectDetected != null) {
			//Rotation gesture
			if (!isRotating) {
				Vector2 startVector = Input.GetTouch (1).position - Input.GetTouch (0).position;
				isRotating = startVector.sqrMagnitude > minDistanceBetweenFingers * minDistanceBetweenFingers;
			} else {
				Vector2 currentVector = Input.GetTouch (1).position - Input.GetTouch (0).position;
			}
		}
	}

	void detectTransfer()
	{
		if(objectDetected!=null)
		{
			//Transfer Gesture
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = 10;//Distance from camera to screen,Camera at -10 and screen at 0
			objectDetected.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
		}
	}

	public static void setObjectDetected(GameObject _objectDetected)
	{
		objectDetected = _objectDetected;
	}

	public static void setObjectDetectedNull()
	{
		objectDetected = null;
	}
}
