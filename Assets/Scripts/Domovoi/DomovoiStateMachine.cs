using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DomovoiStateMachine : MonoBehaviour {

    private enum _eStates { Walk, Idle }
    private _eStates _state = _eStates.Walk;
    private NavMeshAgent _agent;

    [SerializeField] private Vector3 _goal;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        StateMachine();
    }

    private void StateMachine()
    {
        switch (_state) {
            case _eStates.Walk:
                _agent.destination = _goal;
                break;
            case _eStates.Idle:

                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(_goal, 1);
    }
}
