using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField] private bool _debug;

    void OnTriggerEnter(Collider col)
    {
        if (col == null) return;

        if (col.gameObject.name == Player.Instance.name)
        {
            DomovoiController.Instance.FollowPlayer();
            if (_debug) Debug.Log("Domovoi has vision on the player");
        }
    }
}
