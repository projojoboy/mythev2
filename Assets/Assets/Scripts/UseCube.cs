namespace VRTK.Examples
{
    using UnityEngine;

    public class UseCube : VRTK_InteractableObject
    {

        [SerializeField] private GameObject bol; 

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            SpawnBol();
        }

        private void SpawnBol()
        {
            Instantiate(bol, transform.position, transform.rotation);
        }
    }
}
