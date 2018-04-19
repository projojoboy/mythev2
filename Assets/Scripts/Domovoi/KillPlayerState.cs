using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class KillPlayerState : State
{
    public UnityEvent _activateOnDeath;

    private NavMeshAgent _agent;
    private float stateTimer = 5f;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (_activateOnDeath == null) _activateOnDeath = new UnityEvent();
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
            Debug.Log("GAME OVER!");
            _activateOnDeath.Invoke();
            return false;
        }
        return true;
    }

    public override void StateUpdate()
    {
        // Break animation
    }
}
