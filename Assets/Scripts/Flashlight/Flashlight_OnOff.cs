namespace VRTK.Examples
{
    using UnityEngine;


    public class Flashlight_OnOff : VRTK_InteractableObject {
	    public Light Flashlight;
	    //public AudioSource audioSource;

	    //public AudioClip soundOn;
	    //public AudioClip soundOff;
	    private bool isActive = true;
	    public Texture Active;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
	        base.StartUsing(usingObject);

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
}