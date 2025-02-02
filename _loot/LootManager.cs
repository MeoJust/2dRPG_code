using UnityEngine;

public class LootManager : Singleton<LootManager>
{
    [Header("Config")]
    [SerializeField] GameObject _lootPanel;
    [SerializeField] GameObject _lootBTNPrefab;
    [SerializeField] Transform _lootContainer;

    bool IsLootPanelHasItems()
    {
        return _lootContainer.childCount > 0;
    }

    public void ShowLootPanel(EnemyLoot enemyLoot)
    {
        _lootPanel.SetActive(true);
        if (IsLootPanelHasItems())
        {

            for (int i = 0; i < _lootContainer.childCount; i++)
            {
                Destroy(_lootContainer.GetChild(i).gameObject);
            }
        }

        foreach (var item in enemyLoot.Items)
        {
            if (item.PickedItem)
            {
                continue;
            }

            LootBTN lootBTN = Instantiate(_lootBTNPrefab, _lootContainer).GetComponent<LootBTN>();
            lootBTN.ConfigLootBTN(item);
        }
    }

    public void CloseLootPanel(){
        _lootPanel.SetActive(false);
    }
}
