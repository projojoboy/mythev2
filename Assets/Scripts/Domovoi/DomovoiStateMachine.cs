using UnityEngine;
using UnityEngine.AI;

public class DomovoiStateMachine : MonoBehaviour
{
    public GameObject target = null;
    public Vector3 goal;

    private enum _eStates { Walk, Idle }
    private NavMeshAgent _agent;
    private DomovoiController _domovoiController;
    private bool _targetReached = false;
    private float _targetReachedTimer;

    [SerializeField] private _eStates _state = _eStates.Walk;
    [SerializeField] private float _goalRange = 5f;
    [SerializeField] private float _targetReachedTime;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _domovoiController = GetComponent<DomovoiController>();

        _targetReachedTimer = _targetReachedTime * Time.deltaTime;

        InvokeRepeating("StateMachine", 0f, 1f);
    }

    private void Start()
    {
        _domovoiController.NextRandomTarget();
    }

    private void StateMachine()
    {
        switch (_state)
        {
            case _eStates.Walk:
                // Check if player is within range
                _domovoiController.Target(GameObject.Find(ObjectReferences.player));
                // Change nav mesh agent destination
                if (target == null) _agent.destination = goal;
                else _agent.destination = target.transform.position;
                // Get a next random target to follow after you reach the target destination
                if (Vector3.Distance(transform.position, goal) <= _goalRange && target == null) _domovoiController.NextRandomTarget();
                // Set target to null after the Domovoi reached the target destination and waited for some time
                if (target != null)
                {
                    if (Vector3.Distance(transform.position, target.transform.position) <= _goalRange && !_targetReached)
                    {
                        _targetReached = true;
                    }
                    if (_targetReached)
                    {
                        if (_targetReachedTimer > 0f)
                        {
                            // Timer counting down
                            _targetReachedTimer--;
                        }
                        else
                        {
                            // After the timer is done
                            target = null;
                            _targetReachedTimer = _targetReachedTime * Time.deltaTime;
                            _targetReached = false;
                        }
                    }
                }
                // Check if the domovoi needs to take a break
                if (Mathf.Floor(Random.Range(0, 10)) == 1) {
                    _state = _eStates.Idle;
                }
                break;
            case _eStates.Idle:
                // Change nav mesh agent destination to itself
                _agent.destination = gameObject.transform.position;

                if (Mathf.Floor(Random.Range(0, 5)) == 1)
                {
                    _state = _eStates.Walk;
                }
                break;
        }
    }
}
