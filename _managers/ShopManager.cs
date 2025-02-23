using UnityEngine;

public class ShopManager : Singleton<ShopManager>
{
    [Header("Config")]
    [SerializeField] ShopCard _shopCardPrefab;
    [SerializeField] Transform _shopCardContainer;

    [Header("Items")]
    [SerializeField] ShopItem[] _shopItems;

    void Start(){
        LoadShop();
    }

    void LoadShop(){
        for(int i = 0; i < _shopItems.Length; i++){
            ShopCard card = Instantiate(_shopCardPrefab, _shopCardContainer);
            card.ConfigShopCard(_shopItems[i]);
        }
    }
    
}
