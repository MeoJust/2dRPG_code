using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    EnemyBrain _brain;
    EnemySelector _selector;
    EnemyLoot _enemyLoot;

    [Header("Config")]
    [SerializeField] float _health;

    public static event Action OnEnemyDeadEvent;

    public float CurrentHealth { get; private set; }

    void Awake() {
        _brain = GetComponent<EnemyBrain>();
        _selector = GetComponent<EnemySelector>();
        _enemyLoot = GetComponent<EnemyLoot>();
    }

    void Start() {
        CurrentHealth = _health;
    }

    public void TakeDamage(float amount) {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            DisableEnemy();
        }
        else
        {
            DamageManager.Instance.ShowDamage(amount, transform);
        }
    }

    void DisableEnemy() {
        _brain.enabled = false;

        SpriteRenderer[] visuals = gameObject.GetComponentsInChildren<SpriteRenderer>();
        foreach (var visual in visuals)
        {
            visual.color = Color.gray;
            _selector.OnNoSelectionCallback();
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            OnEnemyDeadEvent?.Invoke();
            GameManager.Instance.AddPlayerExp(_enemyLoot.ExpDrop);
        }
    }
}
