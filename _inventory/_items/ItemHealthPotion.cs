using UnityEngine;

[CreateAssetMenu(fileName = "HealthPotion", menuName = "Inventory/HealthPotion")]
public class ItemHealthPotion : InventoryItemSO
{
    [Header("Config")]
    public float HealthValue;

    public override bool UseItem()
    {
        if (GameManager.Instance.Player.PlayerHealth.CanRestoreHealth())
        {
            GameManager.Instance.Player.PlayerHealth.RestoreHealth(HealthValue);
            return true;
        }
        return false;
    }
}
