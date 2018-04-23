using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class DomovoiStateMachine : MonoBehaviour
{
    public enum _eStates { SeekPlayer, Idle, Break, FollowPlayer, KillPlayer }
    private NavMeshAgent _agent;

    private static DomovoiStateMachine _instance;
    public static DomovoiStateMachine Instance
    {
        get { return _instance; }
    }

    [SerializeField] private bool _debug = false;

    [SerializeField] State currentState;
    State seekState;
    State breakState;
    State followPlayerState;
    State killPlayerState;

    private void Awake()
    {
        if (_instance == null) _instance = this;

        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        seekState = GetComponent<SeekState>();
        breakState = GetComponent<BreakState>();
        followPlayerState = GetComponent<FollowPlayerState>();
        killPlayerState = GetComponent<KillPlayerState>();

        ChangeState(_eStates.SeekPlayer);
    }

    private IEnumerator StateMachine()
    {
        currentState.StateEnter();

        while (currentState.Reason())
        {
            currentState.StateUpdate();
            yield return null;
        }

        currentState.StateLeave();
    }

    public void ChangeState(_eStates newState)
    {
        switch (newState)
        {
            case _eStates.SeekPlayer:
                currentState = seekState;
                break;
            case _eStates.Break:
                currentState = breakState;
                break;
            case _eStates.FollowPlayer:
                currentState = followPlayerState;
                break;
            case _eStates.KillPlayer:
                currentState = killPlayerState;
                break;
        }
        StartCoroutine(StateMachine());
    }

    public State GetState() { return currentState; }
}