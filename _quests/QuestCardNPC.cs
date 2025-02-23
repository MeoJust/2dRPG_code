using UnityEngine;
using TMPro;

public class QuestCardNPC : QuestCard
{
    [SerializeField] TextMeshProUGUI _questRewardTXT;

    public override void ConfigQuestUI(Quest quest)
    {
        base.ConfigQuestUI(quest);

        string itemRewardsText = "";
        foreach (Quest.QuestItemReward itemReward in quest.ItemsReward)
        {
            itemRewardsText += $"- x{itemReward.Quantity} {itemReward.Item.ItemName}\n";
        }

        _questRewardTXT.text = $"- {quest.GoldReward} gold\n" +
                              $"- {quest.ExpReward} exp\n" +
                              itemRewardsText;
    }

    public void AcceptQuest()
    {
        if (!QuestToComplete) return;

        QuestToComplete.IsAccepted = true;
        QuestManager.Instance.AcceptQuest(QuestToComplete);
        gameObject.SetActive(false);
    }
}
