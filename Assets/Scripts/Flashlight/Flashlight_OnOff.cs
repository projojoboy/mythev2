using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Flashlight_OnOff : MonoBehaviour {
	public Light Flashlight;
	//public AudioSource audioSource;

	//public AudioClip soundOn;
	//public AudioClip soundOff;
	private bool isActive;
	public Texture Active;



	void Start () {
		
		isActive = true;
	}
	void OnOff (object sender, ClickedEventArgs e){
		if (isActive == false) {
			//audioSource.PlayOneShot(soundOff);
			Flashlight.enabled = true;
			isActive = true;

			//audioSource.PlayOneShot (soundOn);
		} else if (isActive == true) {
			Flashlight.enabled = true;
			isActive = false;
		}
				
   
    
	}
}   
