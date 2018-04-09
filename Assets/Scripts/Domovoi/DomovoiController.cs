using UnityEngine;

public class DomovoiController : MonoBehaviour {

    public float _seeingRange;

    private static DomovoiController _instance;
    public static DomovoiController Instance
    {
        get { return _instance; }
    }

    [SerializeField] private Vector3[] _pathArray;
    [SerializeField] private bool _debug = false;
    [SerializeField] private bool _drawGizmos = false;
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
            DomovoiStateMachine.Instance.targetPos = target.transform.position;
            return;
        }
        if (_debug) Debug.Log("The Domovoi couldn't hear this object: " + target);
    }

    public void NextRandomTarget()
    {
        DomovoiStateMachine.Instance.targetPos = GetRandomTargetPos();
        if (_debug) Debug.Log("Domovoi is moving towards: " + DomovoiStateMachine.Instance.targetPos);
    }

    private Vector3 GetRandomTargetPos() { return _pathArray[Random.Range(0, _pathArray.Length)]; }

    private void OnDrawGizmos()
    {
        if (!_drawGizmos) return;

        Gizmos.color = Color.red;
        if (Application.isPlaying) Gizmos.DrawSphere(DomovoiStateMachine.Instance.targetPos, 0.3f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _hearingRange);

        for (int i = 0; i < _pathArray.Length; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(_pathArray[i], 0.2f);
        }
    }
}
