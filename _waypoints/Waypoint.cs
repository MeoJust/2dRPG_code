using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] Vector3[] _points;

    public Vector3[] Points => _points;
    public Vector3 EntityPos { get; set; }

    bool _isGameStarted = false;

    void Start()
    {
        EntityPos = transform.position;
        _isGameStarted = true;
    }

    public Vector3 GetPosition(int index)
    {
        return EntityPos + _points[index];
    }

    void OnDrawGizmos()
    {
        if (!_isGameStarted && transform.hasChanged)
        {
            EntityPos = transform.position;
        }
    }
}
