using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWithDomovoi : MonoBehaviour {

    [SerializeField] private DomovoiStateMachine _domovoi;
    [SerializeField] private bool _debug = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (_debug) Debug.Log("Magnitude: " + collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude > 4)
        {
            _domovoi.Target(gameObject);
            if (_debug) Debug.Log("Magnitude hit");
        }
    }
}
