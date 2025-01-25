using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventorySlot : MonoBehaviour
{
    public static event Action<int> OnSlotSelectedEvent;

    [Header("Config")]
    [SerializeField] Image _itemIcon;
    [SerializeField] Image _quantityIMG;
    [SerializeField] TextMeshProUGUI _quantityTXT;

    public int Index { get; set; }

    public void ClickSlot(){
        OnSlotSelectedEvent?.Invoke(Index);
    }

    public void UpdateSlot(InventoryItemSO item)
    {
        _itemIcon.sprite = item.ItemIcon;
        _quantityTXT.text = item.Quantity.ToString();
        _itemIcon.SetNativeSize();
    }

    public void ShowSlotInfo(bool value)
    {
        _itemIcon.gameObject.SetActive(value);
        _quantityIMG.gameObject.SetActive(value);
    }
}