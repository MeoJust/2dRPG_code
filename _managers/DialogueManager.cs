using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueManager : Singleton<DialogueManager>
{
    [Header("Config")]
    [SerializeField] GameObject _dialoguePanel;
    [SerializeField] TextMeshProUGUI _dialogueTXT;
    [SerializeField] TextMeshProUGUI _npcNameTXT;
    [SerializeField] Image _npcIcon;

    public NPCInterraction NPCSelected { get; set; }

    bool _isDialogueStarted = false;
    PlayerIA _actions;
    Queue<string> _dialogueQueue = new Queue<string>();

    protected override void Awake()
    {
        base.Awake();
        _actions = new PlayerIA();
    }

    void OnEnable()
    {
        _actions.Enable();
    }

    void OnDisable()
    {
        _actions.Disable();
    }

    void Start()
    {
        _actions.dialogue.interract.performed += ctx => ShowDialogue();
        _actions.dialogue.Continue.performed += ctx => ContinueDialogue();
    }

    public void CloseDialogue()
    {
        _dialoguePanel.SetActive(false);
        _isDialogueStarted = false;
        _dialogueQueue.Clear();
    }

    void LoadDilogueFromNPC()
    {
        if (NPCSelected.DialogueToShow.Dialogue.Length <= 0) return;

        foreach (string sentence in NPCSelected.DialogueToShow.Dialogue)
        {
            _dialogueQueue.Enqueue(sentence);
        }
    }

    void ShowDialogue()
    {
        if (NPCSelected == null) return;
        if (_isDialogueStarted) return;

        _dialoguePanel.SetActive(true);
        LoadDilogueFromNPC();
        _npcIcon.sprite = NPCSelected.DialogueToShow.Icon;
        _npcNameTXT.text = NPCSelected.DialogueToShow.Name;
        _dialogueTXT.text = NPCSelected.DialogueToShow.Greeting;
        _isDialogueStarted = true;
    }

    void ContinueDialogue()
    {
        if (NPCSelected == null)
        {
            _dialoguePanel.SetActive(false);
            _isDialogueStarted = false;
            return;
        }

        if (_dialogueQueue.Count <= 0)
        {
            CloseDialogue();
            return;
        }

        _dialogueTXT.text = _dialogueQueue.Dequeue();
    }
}

