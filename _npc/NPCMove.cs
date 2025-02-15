using UnityEngine;

public class NPCMove : MonoBehaviour
{
    Waypoint _waypoint;

    [Header("Config")]
    [SerializeField] float _moveSpeed;

    Vector3 _previousPosition;
    int _currentWaypointIndex;

    void Awake()
    {
        _waypoint = GetComponent<Waypoint>();
    }

    void Update(){
        Vector3 nextPos = _waypoint.GetPosition(_currentWaypointIndex);
        UpdateMoveValues(nextPos);

        transform.position = Vector3.MoveTowards(transform.position, nextPos, _moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, nextPos) < .2f){
            _previousPosition = nextPos;
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoint.Points.Length;
        }
    }


    void UpdateMoveValues(Vector3 nextPosition)
    {
        Vector2 dir = Vector2.zero;

        if(_previousPosition.x < nextPosition.x) dir = new Vector2(1, 0);
        else if(_previousPosition.x > nextPosition.x) dir = new Vector2(-1, 0);
        else if(_previousPosition.y < nextPosition.y) dir = new Vector2(0, 1);
        else if(_previousPosition.y > nextPosition.y) dir = new Vector2(0, -1);

        _previousPosition = nextPosition;
        
    }
}

