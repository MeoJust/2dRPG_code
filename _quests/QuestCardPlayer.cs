using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QuestCardPlayer : QuestCardNPC
{
    [Header("Config")]
    [SerializeField] TextMeshProUGUI _statusTXT;
    [SerializeField] TextMeshProUGUI _goldRewardTXT;
    [SerializeField] TextMeshProUGUI _expRewardTXT;

    [Header("Item")]
    [SerializeField] Image _itemIcon;
    [SerializeField] TextMeshProUGUI _itemQuantityTXT;

    [Header("Rewards")]
    [SerializeField] GameObject _claimBTNGO;
    [SerializeField] GameObject _rewardsPanel;

    void OnEnable()
    {
        QuestCompletedCheck();
    }

    void Update()
    {
        _statusTXT.text = $"Status\n {QuestToComplete.CurrentStatus}/{QuestToComplete.QuestGoal}";
    }

    public override void ConfigQuestUI(Quest quest)
    {
        base.ConfigQuestUI(quest);
        _statusTXT.text = $"Status\n {quest.CurrentStatus}/{quest.QuestGoal}";
        _goldRewardTXT.text = quest.GoldReward.ToString();
        _expRewardTXT.text = quest.ExpReward.ToString();

        _itemIcon.sprite = quest.ItemsReward[0].Item.ItemIcon;
        _itemQuantityTXT.text = quest.ItemsReward[0].Quantity.ToString();
    }

    public void ClaimQuest()
    {
        GameManager.Instance.AddPlayerExp(QuestToComplete.ExpReward);
        Inventory.Instance.AddItem(QuestToComplete.ItemsReward[0].Item, QuestToComplete.ItemsReward[0].Quantity);
        CoinManager.Instance.AddCoins(QuestToComplete.GoldReward);
        gameObject.SetActive(false);
    }

    void QuestCompletedCheck()
    {
        if (QuestToComplete.IsCompleted)
        {
            _claimBTNGO.SetActive(true);
            _rewardsPanel.SetActive(false);
        }
    }

}