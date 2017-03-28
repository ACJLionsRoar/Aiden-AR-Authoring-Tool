using UnityEngine;
using System.Collections;

namespace Vuforia{

	public class AidenObject : MonoBehaviour,ITrackableEventHandler
	{
		private TrackableBehaviour mTrackableBehaviour;
		int numberOfChildrenDelivered;

		void Start()
		{
			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
		}

		public void OnTrackableStateChanged(
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
				newStatus == TrackableBehaviour.Status.TRACKED ||
				newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				//Target is found
				//Pass the one and only child of imageTarget
				foreach (Transform child in transform) {
					if (numberOfChildrenDelivered < 1) {
						numberOfChildrenDelivered++;
						//GestureDetector.setObjectDetected (child.gameObject);
						// Debug.Log(child.gameObject);
					}
				}
			}
			else
			{
				//Target is lost
				//Set the objectDetected null
				GestureDetector.setObjectDetectedNull();
			}
		}   
	}
}
