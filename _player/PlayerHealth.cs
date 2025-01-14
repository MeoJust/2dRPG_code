using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] PlayerStatsSO _stats;

    //TEMP
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.H))
        // {
        //     TakeDamage(1);
        //     Debug.Log("Player health: " + _stats.Health);
        // }

        if (_stats.Health <= 0)
        {
            DieMfc();
        }
    }

    public void TakeDamage(float amount)
    {
        if (_stats.Health <= 0) return;

        _stats.Health -= amount;

        DamageManager.Instance.ShowDamage(amount, transform);

        if (_stats.Health <= 0)
        {
            DieMfc();
        }
    }

    public void RestoreHealth(float amount)
    {
        _stats.Health += amount;
        if (_stats.Health > _stats.MaxHealth)
        {
            _stats.Health = _stats.MaxHealth;
        }
    }

    public bool CanRestoreHealth()
    {
        return _stats.Health > 0 && _stats.Health < _stats.MaxHealth;
    }

    void DieMfc()
    {
        Debug.Log("Player is dead");

        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.color = Color.gray;
        }
    }
}
