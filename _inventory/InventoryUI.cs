using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventoryUI : Singleton<InventoryUI>
{
    [Header("Config")]
    [SerializeField] GameObject _inventoryPanel;
    [SerializeField] InventorySlot _slotPref;
    [SerializeField] Transform _slotContainer;

    [Header("Description")]
    [SerializeField] GameObject _descriptionPanel;
    [SerializeField] Image _itemIcon;
    [SerializeField] TextMeshProUGUI _itemNameTXT;
    [SerializeField] TextMeshProUGUI _itemDescriptionTXT;

    public InventorySlot CurrentSlot { get; set; }

    List<InventorySlot> _slots = new List<InventorySlot>();

    protected override void Awake()
    {
        base.Awake();
        InitInventory();
    }

    void OnEnable()
    {
        InventorySlot.OnSlotSelectedEvent += OnSlotSelectedCallback;
    }

    void OnDisable()
    {
        InventorySlot.OnSlotSelectedEvent -= OnSlotSelectedCallback;
    }

    void OnSlotSelectedCallback(int index)
    {
        CurrentSlot = _slots[index];
        ShowItemDescription(index);
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

    public void UseItem()
    {
        if (CurrentSlot.Index == null) return;

        Inventory.Instance.UseItem(CurrentSlot.Index);
    }

    public void RemoveItem()
    {
        if (CurrentSlot.Index == null) return;

        Inventory.Instance.RemoveItem(CurrentSlot.Index);
    }

    public void EquipItem()
    {
        if (CurrentSlot.Index == null) return;

        Inventory.Instance.EquipItem(CurrentSlot.Index);
    }

    public void DrawItem(InventoryItemSO item, int index)
    {
        InventorySlot slot = _slots[index];
        if (item == null)
        {
            slot.ShowSlotInfo(false);
            return;
        }
        slot.ShowSlotInfo(true);
        slot.UpdateSlot(item);
    }

    public void ShowItemDescription(int index)
    {
        if (Inventory.Instance.InventoryItems[index] == null) return;
        _descriptionPanel.SetActive(true);
        _itemIcon.sprite = Inventory.Instance.InventoryItems[index].ItemIcon;
        _itemNameTXT.text = Inventory.Instance.InventoryItems[index].ItemName;
        _itemDescriptionTXT.text = Inventory.Instance.InventoryItems[index].ItemDescription;
    }

    public void OpenCloseInventory()
    {
        _inventoryPanel.SetActive(!_inventoryPanel.activeSelf);
        if (!_inventoryPanel.activeSelf)
        {
            _descriptionPanel.SetActive(false);
            CurrentSlot = null;
        }
    }
}