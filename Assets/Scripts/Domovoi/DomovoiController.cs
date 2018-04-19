using UnityEngine;

public class DomovoiController : MonoBehaviour
{
    private static DomovoiController _instance;
    public static DomovoiController Instance
    {
        get { return _instance; }
    }

    [SerializeField] private bool _debug = false;
    [SerializeField] private float _hearingRange;

    private void Awake()
    {
        if (_instance == null) _instance = this;
    }

    public void Target(GameObject target)
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= _hearingRange)
        {
            if (_debug) Debug.Log("Changed Domovoi target to: " + target);
            GetComponent<SeekState>().SetTargetPos(target.transform.position);
            return;
        }
        if (_debug) Debug.Log("The Domovoi couldn't hear this object: " + target);
    }

    public void FollowPlayer()
    {
        DomovoiStateMachine.Instance.ChangeState(DomovoiStateMachine._eStates.FollowPlayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _hearingRange);
    }
}
