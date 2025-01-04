using UnityEngine;

public class DecisionDetectPlayer : FCMDecision
{
    [Header("Config")]
    [SerializeField] float _range = 10f;
    [SerializeField] LayerMask _playerLayer;

    EnemyBrain _enemy;

    void Awake()
    {
        _enemy = GetComponent<EnemyBrain>();
    }

    public override bool Decide()
    {
        return DetectPlayer();
    }

    bool DetectPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(_enemy.transform.position, _range, _playerLayer);
        if (playerCollider != null)
        {
            _enemy.Player = playerCollider.transform;
            return true;
        }

        _enemy.Player = null;
        return false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}

