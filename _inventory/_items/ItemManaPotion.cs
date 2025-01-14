using UnityEngine;

[CreateAssetMenu(fileName = "Mana Potion", menuName = "Inventory/Mana Potion")]
public class ItemManaPotion : InventoryItemSO
{
    [Header("Config")]
    public float ManaAmount;

    public override bool UseItem()
    {
        if (GameManager.Instance.Player.PlayerMana.CanRecoverMana())
        {
            GameManager.Instance.Player.PlayerMana.RecoverMana(ManaAmount);
            return true;
        }
        return false;
    }
}
