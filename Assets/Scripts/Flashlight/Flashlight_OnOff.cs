using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight_OnOff : MonoBehaviour {
	private SteamVR_Controller.Device device;
	public Light Flashlight;
	//public AudioSource audioSource;

	//public AudioClip soundOn;
	//public AudioClip soundOff;

	private bool isActive;


	void Start () {
		isActive = true;	
	}
	

	void Update () {
		if (device.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger )){
			Debug.Log ("Up");
			if (isActive == false) {
				Flashlight.enabled = true;
				isActive = true;

				//audioSource.PlayOneShot (soundOn);
			} else if (isActive == true) {
				Flashlight.enabled = true;
				isActive = false;

				//audioSource.PlayOneShot (soundOff);
			}
		}
	}
}