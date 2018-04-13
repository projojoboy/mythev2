namespace VRTK.Examples
{
    using UnityEngine;

    public class Flashlight_OnOff : VRTK_InteractableObject
    {

        public GameObject Flashlight;
        //public AudioSource audioSource;

        //public AudioClip soundOn;
        //public AudioClip soundOff;
        private bool isActive = true;
        public Texture Active;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            ToggleFlash();
        }

        private void ToggleFlash()
        {
            if (isActive == false)
            {
                //audioSource.PlayOneShot(soundOff);
                Flashlight.SetActive(true);
                isActive = true;

                //audioSource.PlayOneShot (soundOn);
            }
            else if (isActive == true)
            {
                Flashlight.SetActive(false);
                isActive = false;
            }
        }
    }
}