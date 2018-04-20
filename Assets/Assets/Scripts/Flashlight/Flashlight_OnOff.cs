namespace VRTK.Examples
{
    using UnityEngine;

    public class Flashlight_OnOff : VRTK_InteractableObject
    {
        private bool isActive = true;

        private Renderer ren;
        private AudioSource audioS;

        [SerializeField] GameObject Flashlight;
        [SerializeField] Texture active, notActive;
        [SerializeField] AudioClip click;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            ToggleFlash();
            ren = GetComponent<Renderer>();
            audioS = GetComponent<AudioSource>();
            audioS.clip = click;
        }

        private void ToggleFlash()
        {
            if (isActive == false)
            {
                Flashlight.SetActive(true);
                isActive = true;
                ren.material.mainTexture = active;
                audioS.Play();
            }
            else if (isActive == true)
            {
                Flashlight.SetActive(false);
                isActive = false;
                ren.material.mainTexture = notActive;
                audioS.Play();
            }
        }
    }
}