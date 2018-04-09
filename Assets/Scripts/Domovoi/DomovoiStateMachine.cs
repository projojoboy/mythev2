using UnityEngine;
using UnityEngine.AI;

public class DomovoiStateMachine : MonoBehaviour
{
    public Vector3 targetPos;

    private enum _eStates { Walk, Idle, Break }
    private NavMeshAgent _agent;

    private static DomovoiStateMachine _instance;
    public static DomovoiStateMachine Instance
    {
        get { return _instance; }
    }

    [SerializeField] private _eStates _state = _eStates.Walk;
    [SerializeField] private bool _debug = false;
    [SerializeField] private float _targetRange = 5f;
    [SerializeField] private float _breakTime = 5f;
    [SerializeField] private float _waitForBreakTime = 10f;

    private void Awake()
    {
        if (_instance == null) _instance = this;

        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        DomovoiController.Instance.NextRandomTarget();

        InvokeRepeating("StateMachine", 0f, 1f);
    }

    private void StateMachine()
    {
        switch (_state)
        {
            case _eStates.Walk:
                Walk();
                if (!IsInvoking("BreakStart")) Invoke("BreakStart", _waitForBreakTime);
                break;
            case _eStates.Idle:
                // Change nav mesh agent destination to itself
                _agent.destination = gameObject.transform.position;
                break;
            case _eStates.Break:
                if (!IsInvoking("BreakEnd")) Invoke("BreakEnd", _breakTime);
                break;
        }
    }

    private bool ReachedTargetDestination()
    {
        if (Vector3.Distance(transform.position, targetPos) <= _targetRange) return true;
        return false;
    }

    private void BreakStart()
    {
        if (_debug) Debug.Log("Domovoi is taking a break");
        _agent.Stop();
        _state = _eStates.Break;
    }

    private void BreakEnd()
    {
        _state = _eStates.Walk;
        _agent.Resume();
    }

    private void Walk()
    {
        // Change nav mesh agent destination
        if (targetPos != null) _agent.destination = targetPos;
        // Get a next random target to follow after you reach the target destination
        if (ReachedTargetDestination())
        {
            DomovoiController.Instance.NextRandomTarget();
        }
    }
}
