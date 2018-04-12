using UnityEngine;

public class InteractableWithDomovoi : MonoBehaviour {

    private DomovoiController _domovoiController;

    [SerializeField] private bool _debug = false;

    private void Awake()
    {
        _domovoiController = GameObject.Find(ObjectReferences.domovoi).GetComponent<DomovoiController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_debug) Debug.Log("Magnitude: " + collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude > 4)
        {
            _domovoiController.Target(gameObject);
            if (_debug) Debug.Log("Magnitude hit");
        }
    }
}
