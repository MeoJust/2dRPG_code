using UnityEngine;

public class ActionPatrol : FCMAction
{

    [SerializeField] float _speed;

    Waypoint _waypoint;
    int _pointIndex;
    Vector3 _nextPosition;

    void Awake()
    {
        _waypoint = GetComponent<Waypoint>();
    }
    public override void Act()
    {
        FollowPath();
    }

    void FollowPath()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetCurrentPosition(), _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, GetCurrentPosition()) <= 0.1f)
        {
            UpdateNextPosition();
        }
    }

    void UpdateNextPosition()
    {
        _pointIndex++;

        if (_pointIndex > _waypoint.Points.Length - 1)
        {
            _pointIndex = 0;
        }
    }

    Vector3 GetCurrentPosition()
    {
        return _waypoint.GetPosition(_pointIndex);
    }
}
