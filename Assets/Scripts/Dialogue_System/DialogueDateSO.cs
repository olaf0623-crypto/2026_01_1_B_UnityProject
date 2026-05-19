using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueDateSO", menuName = "Scriptable Objects/DialogueDateSO")]
public class DialogueDateSO : ScriptableObject
{
    [Header("캐릭터 정보")]
    public string characterName = "캐릭터";
    public Sprite characterImage;

    [Header("대화 내용")]
    [TextArea(3, 10)]
    public List<string> dialogueLines = new List<string>();
}
