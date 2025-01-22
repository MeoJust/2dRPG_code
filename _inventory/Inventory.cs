using UnityEngine;
using System.Collections.Generic; 

public class Inventory : Singleton<Inventory>
{
    [Header("Config")]
    [SerializeField] int _inventorySize;
    [SerializeField] InventoryItemSO[] _inventoryItems;

    [Header("TEST")]
    public InventoryItemSO _testItem;

    public int InventorySize => _inventorySize;

    void Start()
    {
        _inventoryItems = new InventoryItemSO[_inventorySize];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddItem(_testItem, 3);
        }
    }

    public void AddItem(InventoryItemSO item, int quantity)
    {
        if (item == null || quantity <= 0) return;
        List<int> itemIndexes = CheckItemsStock(item.ItemId);
        if (item.IsStackable && itemIndexes.Count > 0)
        {
            foreach (var index in itemIndexes)
            {
                int maxStack = item.MaxStackSize;
                if (_inventoryItems[index].Quantity < maxStack)
                {
                    _inventoryItems[index].Quantity += quantity;
                    if (_inventoryItems[index].Quantity > maxStack)
                    {
                        int dif = _inventoryItems[index].Quantity - maxStack;
                        _inventoryItems[index].Quantity = maxStack;
                        AddItem(item, dif);
                    }
                    InventoryUI.Instance.DrawItem(_inventoryItems[index], index);
                    return;
                }
            }
        }
        int quantityToAdd = quantity > item.MaxStackSize ? item.MaxStackSize : quantity;
        AddItemToFreeSlot(item, quantityToAdd);
        int remainingAmount = quantity - quantityToAdd;
        if (remainingAmount > 0)
        {
            AddItem(item, remainingAmount);
        }
    }

    void AddItemToFreeSlot(InventoryItemSO item, int quantity)
    {
        for (int i = 0; i < _inventorySize; i++)
        {
            if (_inventoryItems[i] != null) continue;
            _inventoryItems[i] = item.CopyItem();
            _inventoryItems[i].Quantity = quantity;
            InventoryUI.Instance.DrawItem(_inventoryItems[i], i);
            return;
        }
    }

    List<int> CheckItemsStock(string itemId)
    {
        List<int> stock = new List<int>();
        for (int i = 0; i < _inventoryItems.Length; i++)
        {
            if (_inventoryItems[i] == null) continue;
            if (_inventoryItems[i].ItemId == itemId)
            {
                stock.Add(i);
            }
        }
        return stock;
    }
}
