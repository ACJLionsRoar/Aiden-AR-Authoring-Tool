using UnityEngine;
using UnityEngine.UI;
using System.Collections;


	public class GestureDetector : MonoBehaviour {

		public Text testText;
		AidenObject[] objectsDetected;
		bool isRotating;
		Vector2 startVector;
		float minDistanceBetweenFingers,minAngle,zoomSpeed,rotGestureWidth,rotAngleMinimum;

		[SerializeField]
		public float transferSensitivity;

		void Start()
		{
			minDistanceBetweenFingers = 10;
			minAngle = 10;
			objectsDetected = FindObjectsOfType<AidenObject> ();
			rotAngleMinimum = 2;
		}
		
		// Update is called once per frame
		void Update () {
			
			if (Input.touchCount == 2 && PlayerPreferenceManager.getZoom () == 1) {
				//Check if total touches are 2 and check the options
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

			foreach (AidenObject child in objectsDetected) {
				zoomSpeed = child.transform.localScale.x / 20;
				if (magnitudeDifference > 1) {
					//Pinch In-Zoom Decrease
					if (objectsDetected != null) {
							
						if (child.transform.localScale.x >= (child.transform.localScale.x / 3)) {
							if (child.isActive) {
								child.transform.localScale -= new Vector3 (zoomSpeed, zoomSpeed, zoomSpeed);//Decrease Size
							}
						}
					}
				}
				else
				{
					//Pinch Out-Zoom Increase
					if (child.transform.localScale.x <= (child.transform.localScale.x * 3)) {
						if (child.isActive) {
							child.transform.localScale += new Vector3 (zoomSpeed, zoomSpeed, zoomSpeed);//Increase size
						}
					}
				}
			}
		}

		void detectRotation()
		{
			if (!isRotating) {
				startVector = Input.GetTouch (1).position - Input.GetTouch (0).position;
				isRotating = startVector.sqrMagnitude > rotGestureWidth * rotGestureWidth;
			} 
			else {
					Vector2 currVector = Input.GetTouch (1).position - Input.GetTouch (0).position;
					float angleOffset = Vector2.Angle (startVector, currVector);
					Vector3 LR = Vector3.Cross (startVector, currVector);

					if (angleOffset > rotAngleMinimum) {
						if (LR.z > 0) {
							// Anticlockwise turn equal to angleOffset.
							testText.text="ANTI";
						} else if (LR.z < 0) {
							// Clockwise turn equal to angleOffset.
							testText.text="CLOCK";
						}
					} 
					else {
						isRotating = false;
					}
				}
		}

		void detectTransfer()
		{
			if (objectsDetected != null) {
				//Transfer Gesture
				Vector3 mousePosition = Input.mousePosition * transferSensitivity;
				mousePosition.z = 10;//Distance from camera to screen,Camera at -10 and screen at 0
				foreach (AidenObject child in objectsDetected) {
					child.transform.position = Camera.main.ScreenToWorldPoint (mousePosition);
					child.transform.position = new Vector3 (child.transform.position.x, child.transform.position.y,5);
				}
			}
		}

		public static void setObjectDetected(GameObject _objectDetected)
		{
			//objectDetected = _objectDetected;
		}

		public static void setObjectDetectedNull()
		{
			//objectDetected = null;
		}
	}
