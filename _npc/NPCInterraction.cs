using UnityEngine;

public class NPCInterraction : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] NPCDialogue _dialogueToShow;
    [SerializeField] GameObject _interractionBox;

    public NPCDialogue DialogueToShow => _dialogueToShow;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _interractionBox.SetActive(true);
            DialogueManager.Instance.NPCSelected = this;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _interractionBox.SetActive(false);
            DialogueManager.Instance.NPCSelected = null;
            DialogueManager.Instance.CloseDialogue();
        }
    }
}

