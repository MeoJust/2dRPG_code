using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class ItemWeapon : InventoryItemSO
{
    [Header("Weapon")]
    public WeaponSO Weapon;

    public override void EquipItem()
    {
        WpManager.Instance.EquipWeapon(Weapon);
    }
}