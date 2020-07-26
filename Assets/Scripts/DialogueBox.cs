using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;

    public void DisplayDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.speaker;
        dialogueText.text = dialogue.dialogue;
    }
}