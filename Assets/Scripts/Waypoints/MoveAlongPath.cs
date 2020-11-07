using UnityEngine;

public class MoveAlongPath : MonoBehaviour
{
    [SerializeField] private WaypointPath _waypointPath = default;

    [Space]
    [SerializeField] private Rigidbody2D _rigidbody2D = default;
    
    [Space]
    [SerializeField] private MoveAlongPathBehaviour _moveAlongPathBehaviour = default;
    [SerializeField] private float _speed = default;

    private enum MoveAlongPathBehaviour
    {
        Loop,
        PingPong,
        Hold
    }
    
    private int _currentWaypointId = 0;
    private int _direction = 1;
    
    protected void Update()
    {
        UpdateWaypointId();

        _rigidbody2D.MovePosition(GetPointOnPath());
    }

    private Vector3 GetPointOnPath()
    {
        return Vector3.MoveTowards(transform.position, _waypointPath.waypoints[_currentWaypointId].position,
            _speed * Time.deltaTime);
    }

    private void UpdateWaypointId()
    {
        var distance = Vector3.Distance(transform.position, _waypointPath.waypoints[_currentWaypointId].position);

        // Close to target point
        if (!Mathf.Approximately(distance, 0.0f)) return;

        if (_currentWaypointId == 0 && _moveAlongPathBehaviour == MoveAlongPathBehaviour.PingPong)
        {
            _direction = 1;
            _currentWaypointId += _direction;
            return;
        }
        
        // Last waypoint
        if (_currentWaypointId == _waypointPath.waypoints.Length - 1)
        {
            switch (_moveAlongPathBehaviour)
            {
                case MoveAlongPathBehaviour.Loop:
                    _currentWaypointId = 0;
                    break;
                case MoveAlongPathBehaviour.PingPong:
                    _direction = -_direction;
                    _currentWaypointId += _direction;
                    break;
                case MoveAlongPathBehaviour.Hold:
                    _direction = 0;
                    break;
            }
        }
        else
        {
            _currentWaypointId += _direction;
        }
    }
}
