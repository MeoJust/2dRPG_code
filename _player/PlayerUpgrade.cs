using System;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    public static event Action OnPlayerUpgradeEvent;

    [Header("Config")]
    [SerializeField] PlayerStatsSO _stats;

    [Header("Settings")]
    [SerializeField] UpgradeSettings[] _settings;

    void UpgradePlayer(int index) {
        _stats.BaseDamage += _settings[index].DamageUpgrade;
        _stats.TotalDmg += _settings[index].DamageUpgrade;
        _stats.MaxHealth += _settings[index].HealthUpgrade;
        _stats.Health = _stats.MaxHealth;

        _stats.MaxMana += _settings[index].ManaUpgrade;
        _stats.Mana = _stats.MaxMana;

        _stats.CritChance += _settings[index].CritChanceUpgrade;
        _stats.CritDmg += _settings[index].CritDamageUpgrade;
    }

    void OnEnable() {
        AttributeBTN.OnAtributeSelectedEvent += AttributeCallback;
    }

    void OnDisable() {
        AttributeBTN.OnAtributeSelectedEvent -= AttributeCallback;
    }

    void AttributeCallback(AttributeType type) {
        if (_stats.AtributePoints == 0) return;

        switch (type)
        {
            case AttributeType.Strenght:
                UpgradePlayer(0);
                _stats.Strenght++;
                break;
            case AttributeType.Dexterity:
                UpgradePlayer(1);
                _stats.Dexterity++;
                break;
            case AttributeType.Intelligence:
                UpgradePlayer(2);
                _stats.Intelligence++;
                break;
        }

        _stats.AtributePoints--;
        OnPlayerUpgradeEvent?.Invoke();
    }
}

[Serializable]
public class UpgradeSettings
{
    public string Name;

    [Header("Values")]
    public float DamageUpgrade;
    public float HealthUpgrade;
    public float ManaUpgrade;
    public float CritChanceUpgrade;
    public float CritDamageUpgrade;
}
