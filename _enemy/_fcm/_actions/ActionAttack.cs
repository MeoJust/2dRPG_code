using UnityEngine;

public class ActionAttack : FCMAction
{
    EnemyBrain _enemyBrain;

    [Header("Config")]
    [SerializeField] float _attackCooldown = 1f;
    [SerializeField] float _damage = 10f;

    float _timer;


    void Awake()
    {
        _enemyBrain = GetComponent<EnemyBrain>();
    }

    public override void Act()
    {
        Attack();
    }

    void Attack()
    {
        if (_enemyBrain.Player == null) return;

        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            IDamageable player = _enemyBrain.Player.GetComponent<IDamageable>();
            player.TakeDamage(_damage);
            _timer = _attackCooldown;
        }
    }
}
