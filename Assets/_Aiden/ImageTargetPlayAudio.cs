using UnityEngine;
using System.Collections;

namespace Vuforia{
	
public class ImageTargetPlayAudio : MonoBehaviour,ITrackableEventHandler
	{
		private TrackableBehaviour mTrackableBehaviour;

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
				// Play audio when target is found
				Debug.Log("Play Music");
				GetComponent<AudioSource>().Play();
			}
			else
			{
				// Stop audio when target is lost
				Debug.Log("Stop Music");
				GetComponent<AudioSource>().Stop();
			}
		}   
	}
}