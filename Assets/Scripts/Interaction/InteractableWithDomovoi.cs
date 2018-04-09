using UnityEngine;

public class InteractableWithDomovoi : MonoBehaviour {

    [SerializeField] private bool _debug = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (_debug) Debug.Log("Magnitude: " + collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude > 4)
        {
            DomovoiController.Instance.Target(gameObject);
            if (_debug) Debug.Log("Magnitude hit");
        }
    }
}
