using UnityEngine;
using System.Collections;

public class GeneralSettings : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
				Screen.sleepTimeout = SleepTimeout.NeverSleep;
		}
	
		// Update is called once per frame
		void Update ()
		{
#if UNITY_ANDROID
				if (Input.GetKeyDown (KeyCode.Escape)) {
						Application.Quit ();
				}
#endif
		}
}
