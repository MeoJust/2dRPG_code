using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventoryUI : Singleton<InventoryUI>
{
    [Header("Config")]
    [SerializeField] InventorySlot _slotPref;
    [SerializeField] Transform _slotContainer;

    List<InventorySlot> _slots = new List<InventorySlot>();

    void Start()
    {
        InitInventory();
    }

    void InitInventory()
    {
        for (int i = 0; i < Inventory.Instance.InventorySize; i++)
        {
            InventorySlot slot = Instantiate(_slotPref, _slotContainer);
            slot.Index = i;
            _slots.Add(slot);
        }
    }

    public void DrawItem(InventoryItemSO item, int index){
        InventorySlot slot = _slots[index];
        slot.ShowSlotInfo(true);
        slot.UpdateSlot(item);
    }
}