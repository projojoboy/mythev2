using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class KillPlayerState : State
{
    public UnityEvent _activateOnDeath;

    private Animator _animator;
    private NavMeshAgent _agent;
    private float stateTimer = 5f;

    [SerializeField] private float _killRange = 4f;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        if (_activateOnDeath == null) _activateOnDeath = new UnityEvent();
    }

    public override void StateEnter()
    {
        _agent.speed = 0;
        _animator.Play("Attack");
        stateTimer = 5f;
    }

    public override bool Reason()
    {
        stateTimer -= Time.deltaTime;
        if (stateTimer <= 0)
        {
            if (ReachedPlayerDestination())
            {
                _activateOnDeath.Invoke();
            }
            else
            {
                DomovoiStateMachine.Instance.ChangeState(DomovoiStateMachine._eStates.SeekPlayer);
            }
            return false;
        }
        return true;
    }

    public override void StateUpdate()
    {
        _agent.destination = Player.Instance.transform.position;
    }

    private bool ReachedPlayerDestination()
    {
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) <= _killRange) return true;
        return false;
    }
}
