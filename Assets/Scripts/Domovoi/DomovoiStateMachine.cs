using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DomovoiStateMachine : MonoBehaviour
{

    private enum _eStates { Walk, Idle }
    private _eStates _state = _eStates.Walk;
    private NavMeshAgent _agent;

    [SerializeField] private Vector3 _goal;
    [SerializeField] private GameObject _target = null;

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
        switch (_state)
        {
            case _eStates.Walk:
                if (_target == null) _agent.destination = _goal;
                else _agent.destination = _target.transform.position;
                break;
            case _eStates.Idle:

                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_goal, 0.2f);
    }

    public void Target(GameObject target)
    {
        _target = target;
    }
}
