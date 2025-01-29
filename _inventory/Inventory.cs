using UnityEngine;
using System.Collections.Generic;
using BayatGames.SaveGameFree;

public class Inventory : Singleton<Inventory>
{
    [Header("Config")]
    [SerializeField] GameContent _gameContent;
    [SerializeField] int _inventorySize;
    [SerializeField] InventoryItemSO[] _inventoryItems;

    [Header("TEST")]
    public InventoryItemSO _testItem;

    public int InventorySize => _inventorySize;
    public InventoryItemSO[] InventoryItems => _inventoryItems;

    readonly string INVENTORY_KEY_DATA = "MY_INVENTORY";

    void Start()
    {
        _inventoryItems = new InventoryItemSO[_inventorySize];
        VerifyItemsForDraw();
        LoadInventory();



        //!!UBRAT'
        // SaveGame.Delete(INVENTORY_KEY_DATA);
        //!!UBRAT'
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddItem(_testItem, 1);
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
                    SaveInventory();
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

        SaveInventory();
    }

    public void UseItem(int index)
    {
        if (_inventoryItems[index] == null) return;
        if (_inventoryItems[index].UseItem())
        {
            DecreaseItemStack(index);
        }

        SaveInventory();
    }

    public void RemoveItem(int index)
    {
        if (_inventoryItems[index] == null) return;
        _inventoryItems[index].RemoveItem();
        _inventoryItems[index] = null;
        InventoryUI.Instance.DrawItem(null, index);

        SaveInventory();
    }

    public void EquipItem(int index)
    {
        if (_inventoryItems[index] == null) return;
        if (_inventoryItems[index].ItemType != ItemType.Weapon) return;
        _inventoryItems[index].EquipItem();
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

    void DecreaseItemStack(int index)
    {
        _inventoryItems[index].Quantity--;
        if (_inventoryItems[index].Quantity <= 0)
        {
            _inventoryItems[index] = null;
            InventoryUI.Instance.DrawItem(null, index);
        }
        else
        {
            InventoryUI.Instance.DrawItem(_inventoryItems[index], index);
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

    public void VerifyItemsForDraw()
    {
        for (int i = 0; i < _inventorySize; i++)
        {
            if (_inventoryItems[i] == null)
            {
                InventoryUI.Instance.DrawItem(null, i);
            }
        }
    }

    InventoryItemSO ItemExistInGameContent(string itemId){
        for(int i = 0; i < _inventorySize; i++){
            if(_gameContent.GameItems[i].ItemId == itemId){
                return _gameContent.GameItems[i];
            }
        }
        return null;
    }

    void LoadInventory(){
        if(SaveGame.Exists(INVENTORY_KEY_DATA)){
            InventoryData data = SaveGame.Load<InventoryData>(INVENTORY_KEY_DATA);
            for(int i = 0; i < _inventorySize; i++){
                if(data.ItemContent[i] != null){
                    InventoryItemSO item = ItemExistInGameContent(data.ItemContent[i]);
                    if(item != null){
                        _inventoryItems[i] = item.CopyItem();
                        _inventoryItems[i].Quantity = data.ItemQuantity[i];
                        InventoryUI.Instance.DrawItem(_inventoryItems[i], i);
                    }
                    else
                    {
                        _inventoryItems[i] = null;
                    }
                }
            }
        }
    }

    void SaveInventory(){
        InventoryData data = new InventoryData();
        data.ItemContent = new string[_inventorySize];
        data.ItemQuantity = new int[_inventorySize];
        for (int i = 0; i < _inventorySize; i++)
        {
            if (_inventoryItems[i] != null)
            {
                data.ItemContent[i] = _inventoryItems[i].ItemId;
                data.ItemQuantity[i] = _inventoryItems[i].Quantity;
            }
            else
            {
                data.ItemContent[i] = null;
                data.ItemQuantity[i] = 0;
            }
        }

        SaveGame.Save(INVENTORY_KEY_DATA, data);
    }
}

