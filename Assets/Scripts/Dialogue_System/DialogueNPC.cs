using System.Xml;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    public DialogueDateSO myDialouge;
    private DialogueManager dialogueManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueManager = FindAnyObjectByType<DialogueManager>();

        if (dialogueManager != null)
        {
            Debug.LogError("다이얼 로그 매니저 없습니다");
        }
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (dialogueManager == null) return;
        if (dialogueManager.IsDialougeActive()) return;
        if (myDialouge == null) return;

        dialogueManager.StartDialouge(myDialouge);
    }
}
