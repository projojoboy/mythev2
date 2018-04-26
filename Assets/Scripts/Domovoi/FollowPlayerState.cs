using UnityEngine;
using UnityEngine.AI;

public class FollowPlayerState : State
{
    private NavMeshAgent _agent;

    [SerializeField] private float _playerRange;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public override void StateEnter()
    {
        _agent.Resume();
    }

    public override bool Reason()
    {
        if (ReachedPlayerDestination())
        {
            DomovoiStateMachine.Instance.ChangeState(DomovoiStateMachine._eStates.KillPlayer);
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
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) <= _playerRange) return true;
        return false;
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(Player.Instance.transform.position, _playerRange);
    }*/
}
