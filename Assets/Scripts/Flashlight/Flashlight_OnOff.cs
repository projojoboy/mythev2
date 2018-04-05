using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Flashlight_OnOff : MonoBehaviour {
    /*private SteamVR_Controller.Device device;
	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }*/
    private SteamVR_TrackedController device;
    public Light Flashlight;
    //public AudioSource audioSource;

    //public AudioClip soundOn;
    //public AudioClip soundOff;

    private bool isActive;


    void Start() {
        device = GetComponent<SteamVR_TrackedController>();
        isActive = true;
        //device.TriggerClicked += OnOff;
    }
    public void OnOff() {
        if (isActive == false) {
            Flashlight.enabled = true;
            isActive = true;

            //audioSource.PlayOneShot (soundOn);
        } else if (isActive == true) {
            Flashlight.enabled = false;
            isActive = false;
        }
    }
}

	/*void Update () {
		if (device.GetHairTrigger()){
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
}*/