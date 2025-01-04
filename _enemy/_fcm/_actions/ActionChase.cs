using UnityEngine;

public class ActionChase : FCMAction
{
    [Header("Config")]
    [SerializeField] float _speed = 5f;

    EnemyBrain _enemy;

    void Awake()
    {
        _enemy = GetComponent<EnemyBrain>();
    }

    public override void Act()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {
        if (_enemy.Player == null) return;

        Vector2 dirToPlayer = _enemy.Player.position - transform.position;
        if (dirToPlayer.magnitude >= 1.5f)
        {
            transform.Translate(dirToPlayer.normalized * (_speed * Time.deltaTime));
        }
    }
}
