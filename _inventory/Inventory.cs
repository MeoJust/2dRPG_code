using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [Header("Config")]
    [SerializeField] int _inventorySize;
    [SerializeField] InventoryItemSO[] _items;

    [Header("TEST")] 
    public InventoryItemSO _testItem;

    public int InventorySize => _inventorySize;

    void Start()
    {
        _items = new InventoryItemSO[_inventorySize];
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.T)){
            _items[0] = _testItem.CopyItem();
            _items[0].Quantity = 10;
            InventoryUI.Instance.DrawItem(_items[0], 0);
        }
    }
}
