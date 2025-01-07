using UnityEngine;

public enum AttributeType
{
    Strenght,
    Dexterity,
    Intelligence
}

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStatsSO : ScriptableObject
{
    [Header("Exp")]
    public int Level;
    public float CurrentExp;
    public float NextLevelExp;
    public float InitialNextLevelExp;
    [Range(1f, 100f)] public float ExpMultiplier;

    [Header("Health")]
    public float Health;
    public float MaxHealth;

    [Header("Mana")]
    public float Mana;
    public float MaxMana;

    [Header("Attack")]
    public float BaseDamage;
    public float CritChance;
    public float CritDmg;

    [Header("Attributes")]
    public int Strenght;
    public int Dexterity;
    public int Intelligence;
    public int AtributePoints;

    [HideInInspector]public float TotalExp;
    [HideInInspector]public float TotalDmg;

    public void ResetPlayer()
    {
        Health = MaxHealth;
        Mana = MaxMana;
        Level = 1;
        CurrentExp = 0;
        NextLevelExp = InitialNextLevelExp;
        TotalExp = 0;
        BaseDamage = 1;
        CritChance = 10;
        CritDmg = 50;
        Strenght = 1;
        Dexterity = 1;
        Intelligence = 1;
        AtributePoints = 0;
    } 
}
