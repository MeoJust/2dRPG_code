using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopCard : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] Image _itemIcon;
    [SerializeField] TextMeshProUGUI _itemName;
    [SerializeField] TextMeshProUGUI _itemCost;
    [SerializeField] TextMeshProUGUI _buyAmount;

    ShopItem _item;
    int _quantity;
    float _initCost;
    float _currentCost;

    void Update(){
        _buyAmount.text = _quantity.ToString();
        _itemCost.text = _currentCost.ToString();
    }

    public void ConfigShopCard(ShopItem shopItem)
    {
        _item = shopItem;
        _itemIcon.sprite = shopItem.Item.ItemIcon;
        _itemName.text = shopItem.Item.ItemName;
        _itemCost.text = shopItem.Cost.ToString();
        _initCost = shopItem.Cost;
        _currentCost = shopItem.Cost;
        _quantity = 1;
    }

    public void BuyItem(){
        if(CoinManager.Instance.Coins >= _currentCost){
            Inventory.Instance.AddItem(_item.Item, _quantity);
            CoinManager.Instance.RemoveCoins(_currentCost);
            _quantity = 1;
            _currentCost = _initCost;
        }
    }

    public void Add()
    {
        float cost = _initCost * (_quantity + 1);
        if (CoinManager.Instance.Coins >= cost)
        {
            _quantity++;
            _currentCost = _initCost * _quantity;
        }
    }

    public void Remove()
    {
        if (_quantity == 1) return;
        _quantity--;
        _currentCost = _initCost * _quantity;
    }
}
