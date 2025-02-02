using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LootBTN : MonoBehaviour
{

    [Header("Config")]
    [SerializeField] Image _icon;
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _quantity;

    public DropItem ItemLoaded { get; private set; }

    public void ConfigLootBTN(DropItem item)
    {
        ItemLoaded = item;
        _icon.sprite = item.item.ItemIcon;
        _name.text = item.item.ItemName;
        _quantity.text = item.minQuantity.ToString();
    }

    public void CollectItem(){
        if(ItemLoaded == null){
            return;
        }

        Inventory.Instance.AddItem(ItemLoaded.item, ItemLoaded.minQuantity);
        ItemLoaded.PickedItem = true;
        Destroy(gameObject);
    }
}

