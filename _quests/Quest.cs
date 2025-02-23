using UnityEngine;

[CreateAssetMenu]
public class Quest : ScriptableObject
{
    [Header("Quest Info")]
    public string Name;
    public string ID;
    public int QuestGoal;

    [Header("Quest Description")]
    [TextArea] public string Description;

    [Header("Quest Rewards")]
    public int GoldReward;
    public float ExpReward;
    public QuestItemReward[] ItemsReward;

    [HideInInspector] public int CurrentStatus;
    [HideInInspector] public bool IsAccepted;
    [HideInInspector] public bool IsCompleted;

    public void AddProgress(int amount)
    {
        CurrentStatus += amount;

        if (CurrentStatus >= QuestGoal)
        {
            CurrentStatus = QuestGoal;
            QuestCompleted();
        }
    }

    public void ResetQuest()
    {
        IsCompleted = false;
        IsAccepted = false;
        CurrentStatus = 0;
    }

    void QuestCompleted()
    {
        if (IsCompleted) return;

        IsCompleted = true;
    }

    [System.Serializable]
    public class QuestItemReward
    {
        public InventoryItemSO Item;
        public int Quantity;
    }}
