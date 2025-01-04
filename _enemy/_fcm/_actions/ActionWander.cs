using UnityEngine;

public class ActionWander : FCMAction
{
    [SerializeField] float _speed = 1f;
    [SerializeField] float _wanderTime = 3f;
    [SerializeField] Vector2 _moveRange;

    Vector3 _movePosition;
    float _timer;

    void Start()
    {
        GetNewDestination();
    }

    public override void Act()
    {
        _timer -= Time.deltaTime;
        Vector3 moveDir = (_movePosition - transform.position).normalized;
        Vector3 movement = moveDir * _speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, _movePosition) >= 0.5f)
        {
            transform.Translate(movement);

        }

        if (_timer <= 0)
        {
            GetNewDestination();
            _timer = _wanderTime;
        }
    }

    void GetNewDestination()
    {
        float randomX = Random.Range(-_moveRange.x, _moveRange.x);
        float randomY = Random.Range(-_moveRange.y, _moveRange.y);
        _movePosition = transform.position + new Vector3(randomX, randomY);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, _moveRange * 2f);
        Gizmos.DrawLine(transform.position, _movePosition);
    }
}
