using UnityEngine;

public class DecisionAttackRange : FCMDecision
{
    [Header("Config")]
    [SerializeField] float _attackRange = 10f;
    [SerializeField] LayerMask _playerLayer;

    EnemyBrain _enemy;

    void Awake()
    {
        _enemy = GetComponent<EnemyBrain>();
    }

    public override bool Decide()
    {
        return IsPlayerInAttackRange();
    }

    bool IsPlayerInAttackRange()
    {
        if (_enemy.Player == null) return false;

        Collider2D playerCollider = Physics2D.OverlapCircle(_enemy.transform.position, _attackRange, _playerLayer);
        if (playerCollider != null)
        {
            return true;
        }

        return false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}
