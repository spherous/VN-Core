using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    // [SerializeField] private int textPrintingSpeed = 1;
    public Speed textPrintingSpeed = Speed.Fast;
    public bool printing = false;
    private Dialogue currentDialogue;
    private int currentPrintIndex = 0;

    private void Update()
    {
        switch(textPrintingSpeed)
        {
            case Speed.Instant:
                return;
            case Speed.VeryFast:
                currentPrintIndex = currentPrintIndex + 2 > currentDialogue.dialogue.Length ? currentDialogue.dialogue.Length : currentPrintIndex + 2;
                break;
            case Speed.Fast:
                currentPrintIndex = currentPrintIndex + 1 > currentDialogue.dialogue.Length ? currentDialogue.dialogue.Length : currentPrintIndex + 1;
                break;
            case Speed.Medium:
                break;
            case Speed.Slow:
                break;
            default:
                return;
        }

        dialogueText.text = currentDialogue.dialogue.Substring(0, currentPrintIndex);
        
        if(currentPrintIndex == currentDialogue.dialogue.Length)
            printing = false;
    }

    public void DisplayDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.speaker;
        currentDialogue = dialogue;
        
        if(textPrintingSpeed == Speed.Instant)
        {
            printing = false;
            currentPrintIndex = currentDialogue.dialogue.Length;
        }
        else if(textPrintingSpeed == Speed.VeryFast)
        {
            printing = true;
            currentPrintIndex = 2;
        }
        else
        {
            printing = true;
            currentPrintIndex = 1;
        }

        dialogueText.text = dialogue.dialogue.Substring(0, currentPrintIndex);
    }

    public void PrintAll()
    {
        printing = false;
        currentPrintIndex = currentDialogue.dialogue.Length;
        dialogueText.text = currentDialogue.dialogue.Substring(0, currentPrintIndex);
    }
}

public enum Speed {Slow, Medium, Fast, VeryFast, Instant}