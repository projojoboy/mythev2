using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight_2 : MonoBehaviour {
    private bool isActive;
    public Light Flashlight;
    // Use this for initialization
    void Start () {
        isActive = true;
	}

    // Update is called once per frame
    public void OnOff()
    {
        if (isActive == false)
        {
            Flashlight.enabled = true;
            isActive = true;

            //audioSource.PlayOneShot (soundOn);
        }
        else if (isActive == true)
        {
            Flashlight.enabled = true;
            isActive = false;
        }
    }
}
