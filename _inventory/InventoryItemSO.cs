using UnityEngine;

public enum ItemType
{
    Weapon,
    Potion,
    Scroll,
    Ingredient,
    Treasure
}

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory/Item")]
public class InventoryItemSO : ScriptableObject
{
    [Header("Item Information")]
    public string ItemId;
    public string ItemName;
    public Sprite ItemIcon;
    [TextArea(3, 10)] public string ItemDescription;

    [Header("Item Stats")]
    public ItemType ItemType;
    public bool IsConsumable;
    public bool IsStackable;
    public int MaxStackSize;

    [HideInInspector] public int Quantity;

    public InventoryItemSO CopyItem()
    {
        InventoryItemSO instance = Instantiate(this);
        return instance;
    }

    public virtual bool UseItem()
    {
        return true;
    }

    public virtual void RemoveItem()
    {
    }

    public virtual void EquipItem()
    {
    }
}
