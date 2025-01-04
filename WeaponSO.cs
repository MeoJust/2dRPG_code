using UnityEngine;

public enum WeaponType
{
    Magic,
    Melee
}

[CreateAssetMenu(fileName = "WeaponSO", menuName = "ScriptableObjects/Weapon")]
public class WeaponSO : ScriptableObject
{
    [Header("General")]
    public Sprite Icon;
    public WeaponType WeaponType;
    public float Damage;

    [Header("Magic")]
    public Projectile ProjectilePrefab;
    public float RecuiredMana;
}
