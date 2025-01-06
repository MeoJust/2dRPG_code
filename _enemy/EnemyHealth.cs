using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    EnemyBrain _brain;
    EnemySelector _selector;

    [Header("Config")]
    [SerializeField] float _health;

    public static event Action OnEnemyDeadEvent;

    public float CurrentHealth { get; private set; }

    void Awake() {
        _brain = GetComponent<EnemyBrain>();
        _selector = GetComponent<EnemySelector>();
    }

    void Start() {
        CurrentHealth = _health;
    }

    public void TakeDamage(float amount) {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            _brain.enabled = false;

            SpriteRenderer[] visuals = gameObject.GetComponentsInChildren<SpriteRenderer>();
            foreach (var visual in visuals)
            {
                visual.color = Color.gray;
                _selector.OnNoSelectionCallback();
                gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
                OnEnemyDeadEvent?.Invoke();
            }
        }
        else
        {
            DamageManager.Instance.ShowDamage(amount, transform);
        }
    }
}
