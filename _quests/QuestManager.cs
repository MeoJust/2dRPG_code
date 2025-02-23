using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [Header("Config")]
    [SerializeField] Quest[] _quests;

    [Header("NPC Quest Panel")]
    [SerializeField] QuestCardNPC _questCardNPC_prefab;
    [SerializeField] Transform _npcPanelContainer;

    [Header("Player Quest Panel")]
    [SerializeField] QuestCardPlayer _questCardPlayer_prefab;
    [SerializeField] Transform _playerPanelContainer;

    void OnEnable()
    {
        foreach (Quest quest in _quests)
        {
            quest.ResetQuest();
        }
    }

    void Start()
    {
        LoadQuestsIntoNPCPanel();
    }

    public void AcceptQuest(Quest quest)
    {
        QuestCardPlayer questCardPlayer = Instantiate(_questCardPlayer_prefab, _playerPanelContainer);
        questCardPlayer.ConfigQuestUI(quest);
    }

    public void AddProgress(string questID, int amount)
    {
        Quest questToUpdate = QuestExists(questID);
        if (questToUpdate == null) return;
        
        if (questToUpdate.IsAccepted)
        {
            print("questObj++");
            questToUpdate.AddProgress(amount);
        }
    }

    Quest QuestExists(string questID)
    {
        foreach (Quest quest in _quests)
        {
            if (quest.ID == questID) return quest;
        }

        return null;
    }

    void LoadQuestsIntoNPCPanel()
    {
        for (int i = 0; i < _quests.Length; i++)
        {
            QuestCardNPC questCardNPC = Instantiate(_questCardNPC_prefab, _npcPanelContainer);
            questCardNPC.ConfigQuestUI(_quests[i]);
        }
    }
}
