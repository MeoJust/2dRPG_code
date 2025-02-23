using UnityEngine;
using TMPro;
public class QuestCard : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private TextMeshProUGUI _questNameTXT;
    [SerializeField] private TextMeshProUGUI _questDescriptionTXT;

    public Quest QuestToComplete { get; set; }

    public virtual void ConfigQuestUI(Quest quest)
    {
        QuestToComplete = quest;
        _questNameTXT.text = quest.Name;
        _questDescriptionTXT.text = quest.Description;
    }
}
