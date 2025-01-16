using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] Image _itemIcon;
    [SerializeField] Image _quantityIMG;
    [SerializeField] TextMeshProUGUI _quantityTXT;

    public int Index { get; set; }

    public void UpdateSlot(InventoryItemSO item)
    {
        _itemIcon.sprite = item.ItemIcon;
        _quantityTXT.text = item.Quantity.ToString();
    }

    public void ShowSlotInfo(bool value)
    {
        _itemIcon.gameObject.SetActive(value);
        _quantityIMG.gameObject.SetActive(value);
    }
}