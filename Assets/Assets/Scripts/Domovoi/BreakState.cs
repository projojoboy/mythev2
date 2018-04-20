using UnityEngine;
using UnityEngine.AI;

public class BreakState : State
{
    private NavMeshAgent _agent;
    private float stateTimer = 5f;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public override void StateEnter()
    {
        _agent.Stop();
    }

    public override bool Reason()
    {
        stateTimer -= Time.deltaTime;
        if (stateTimer <= 0)
        {
            DomovoiStateMachine.Instance.ChangeState(DomovoiStateMachine._eStates.SeekPlayer);
            return false;
        }
        return true;
    }

    public override void StateUpdate()
    {
        // Break animation
    }

    public override void StateLeave()
    {
        _agent.Resume();
    }
}
