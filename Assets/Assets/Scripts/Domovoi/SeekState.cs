using UnityEngine;
using UnityEngine.AI;

public class SeekState : State
{
    [SerializeField] private Vector3 targetPos;
    private NavMeshAgent _agent;
    [SerializeField] private float _targetRange = 5f;
    [SerializeField] private Vector3Path _pathComponent;

    [SerializeField]
    private float stateTimer = 10f;
    private float timer;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public override bool Reason()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            DomovoiStateMachine.Instance.ChangeState(DomovoiStateMachine._eStates.Break);
            return false;
        }
        return true;
    }

    public override void StateEnter()
    {
        //base.StateEnter();
        timer = stateTimer;
    }

    public override void StateUpdate()
    {
        // Change nav mesh agent destination
        if (targetPos != null) _agent.destination = targetPos;
        // Get a next random target to follow after you reach the target destination
        if (ReachedTargetDestination())
        {
            NextRandomTarget();
        }
    }

    private bool ReachedTargetDestination()
    {
        if (Vector3.Distance(transform.position, targetPos) <= _targetRange) return true;
        return false;
    }

    public void NextRandomTarget()
    {
        targetPos = _pathComponent.GetRandomTargetPos();
    }

    public void SetTargetPos(Vector3 newTargetPos) { targetPos = newTargetPos; }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetPos, 0.3f);
    }
}
