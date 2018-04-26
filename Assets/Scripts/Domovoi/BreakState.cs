using UnityEngine;
using UnityEngine.AI;

public class BreakState : State
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private float stateTimer = 5f;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    public override void StateEnter()
    {
        _agent.Stop();
        _animator.Play("Idle");
        stateTimer = 5f;
    }

    public override bool Reason()
    {
        stateTimer -= Time.deltaTime;
        if (stateTimer <= 0)
        {
            _agent.Resume();
            DomovoiStateMachine.Instance.ChangeState(DomovoiStateMachine._eStates.SeekPlayer);
            return false;
        }
        return true;
    }

    public override void StateUpdate()
    {
        
    }
}
