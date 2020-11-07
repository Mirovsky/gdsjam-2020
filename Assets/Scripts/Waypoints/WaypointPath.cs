using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class WaypointPath : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints = default;
    [SerializeField] private bool _loop = default;

    public Transform[] waypoints => _waypoints;
    
#if UNITY_EDITOR
    protected void OnDrawGizmos()
    {
        if (_waypoints == null)
        {
            return;
        }
        
        for (var i = 0; i < _waypoints.Length - 1; i++)
        {
            Handles.DrawWireDisc(_waypoints[i].position, Vector3.forward, 0.5f);
            Handles.DrawLine(_waypoints[i].position, _waypoints[i + 1].position);
        }
        Handles.DrawWireDisc(_waypoints[_waypoints.Length - 1].position, Vector3.forward, 0.5f);

        if (_loop)
        {
            Handles.DrawLine(_waypoints[_waypoints.Length - 1].position, _waypoints[0].position);
        }
    }
#endif
}
