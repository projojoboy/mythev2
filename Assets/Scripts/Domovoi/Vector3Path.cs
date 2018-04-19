using UnityEngine;

public class Vector3Path : MonoBehaviour
{
    [SerializeField] private Vector3[] _pathArray;

    public Vector3 GetRandomTargetPos() { return _pathArray[Random.Range(0, _pathArray.Length)]; }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < _pathArray.Length; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(_pathArray[i], 0.3f);
        }
    }
}
