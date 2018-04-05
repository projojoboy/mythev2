using UnityEngine;

public class DomovoiController : MonoBehaviour {

    public float _seeingRange;

    private DomovoiStateMachine _domovoiStateMachine;

    [SerializeField] private Vector3[] _pathArray;
    [SerializeField] private bool _debug = false;
    [SerializeField] private bool _drawGizmos = false;
    [SerializeField] private float _hearingRange;

    private void Awake()
    {
        _domovoiStateMachine = GetComponent<DomovoiStateMachine>();
    }

    public void Target(GameObject target)
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= _hearingRange)
        {
            if (_debug) Debug.Log("Changed Domovoi target to: " + target);
            _domovoiStateMachine.target = target;
            return;
        }
        if (_debug) Debug.Log("The Domovoi couldn't hear this object: " + target);
    }

    public void NextRandomTarget()
    {
        _domovoiStateMachine.target = null;
        _domovoiStateMachine.goal = GetRandomTarget();
        if (_debug) Debug.Log("Domovoi is moving towards: " + _domovoiStateMachine.goal);
    }

    private Vector3 GetRandomTarget () { return _pathArray[Random.Range(0, _pathArray.Length)]; }

    private void OnDrawGizmos()
    {
        if (!_drawGizmos) return;

        _domovoiStateMachine = gameObject.GetComponent<DomovoiStateMachine>();

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_domovoiStateMachine.goal, 0.3f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _hearingRange);

        for (int i = 0; i < _pathArray.Length; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(_pathArray[i], 0.2f);
        }
    }
}
