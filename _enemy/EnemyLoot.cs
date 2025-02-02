using UnityEngine;
using System;
using System.Collections.Generic;
public class EnemyLoot : MonoBehaviour

{
    [Header("Config")]
    [SerializeField] float _expDrop;
    [SerializeField] DropItem[] _dropItems;

    public List<DropItem> Items { get; private set; }
    public float ExpDrop => _expDrop;

    void Start()
    {
        LoadDropItems();
    }

    void LoadDropItems()

    {
        Items = new List<DropItem>();
        foreach (DropItem item in _dropItems){
            float prob = UnityEngine.Random.Range(0, 100);
            if (prob <= item.DropChance){
                Items.Add(item);
            }
        }
    }
}


[Serializable]
public class DropItem

{
    [Header("Config")]
    public string Name;
    public InventoryItemSO item;
    public int minQuantity;
    public int maxQuantity;

    [Header("Drop Chance")]
    public float DropChance;
    public bool PickedItem { get; set; }
}

