namespace VRTK.Examples
{
    using UnityEngine;

    public class Flashlight_OnOff : VRTK_InteractableObject
    {
        private bool isActive = true;

        [SerializeField] GameObject Flashlight;
        [SerializeField] Texture Active;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            ToggleFlash();
        }

        private void ToggleFlash()
        {
            if (isActive == false)
            {
                Flashlight.SetActive(true);
                isActive = true;
            }
            else if (isActive == true)
            {
                Flashlight.SetActive(false);
                isActive = false;
            }
        }
    }
}