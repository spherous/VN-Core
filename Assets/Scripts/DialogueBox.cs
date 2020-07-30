using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

public class DialogueBox : MonoBehaviour
{
    MomentManager momentManager => MomentManager.instance;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private Dialogue currentDialogue;
    public Speed textPrintingSpeed = Speed.Fast;

    [ReadOnly] public bool printing = false;
    [ReadOnly] public bool autoPlay = false;

    public float displayForTime;
    private float advanceAtTime;

    private int currentPrintIndex = 0;
    private float nextPrintTime;

    private void Update()
    {
        if(printing)
        {
            switch(textPrintingSpeed)
            {
                // Each text printing speed prints at a different rate.
                case Speed.Instant:
                    return;
                case Speed.VeryFast:
                    // 2 characters per frame
                    currentPrintIndex = currentPrintIndex + 2 > currentDialogue.dialogue.Length ? currentDialogue.dialogue.Length : currentPrintIndex + 2;
                    break;
                case Speed.Fast:
                    // 1 character every frame
                    currentPrintIndex = currentPrintIndex + 1 > currentDialogue.dialogue.Length ? currentDialogue.dialogue.Length : currentPrintIndex + 1;
                    break;
                case Speed.Medium when Time.timeSinceLevelLoad >= nextPrintTime:
                    // 1 character every 0.025 seconds
                    currentPrintIndex = currentPrintIndex + 1 > currentDialogue.dialogue.Length ? currentDialogue.dialogue.Length : currentPrintIndex + 1;
                    nextPrintTime = Time.timeSinceLevelLoad + .025f;
                    break;
                case Speed.Slow when Time.timeSinceLevelLoad >= nextPrintTime:
                    // 1 character every 0.05 seconds
                    currentPrintIndex = currentPrintIndex + 1 > currentDialogue.dialogue.Length ? currentDialogue.dialogue.Length : currentPrintIndex + 1;
                    nextPrintTime = Time.timeSinceLevelLoad + .05f;
                    break;
                default:
                    return;
            }

            dialogueText.text = currentDialogue.dialogue.Substring(0, currentPrintIndex);
            
            if(currentPrintIndex == currentDialogue.dialogue.Length)
            {
                printing = false;
                if(autoPlay)
                    advanceAtTime = Time.timeSinceLevelLoad + displayForTime;
            }
        }
        else if(autoPlay && Time.timeSinceLevelLoad >= advanceAtTime)
            momentManager.ChangeDialogue();
    }

    public void DisplayDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.speaker;
        currentDialogue = dialogue;

        // When we display a new dialogue, we should always display the proper amount of it for the first frame        
        if(textPrintingSpeed == Speed.Instant)
        {
            // When it's instant, print the whole thing
            printing = false;
            currentPrintIndex = currentDialogue.dialogue.Length;
            if(autoPlay)
                advanceAtTime = Time.timeSinceLevelLoad + displayForTime;
        }
        else if(textPrintingSpeed == Speed.VeryFast)
        {
            // Print the first 2 characters for very fast
            printing = true;
            currentPrintIndex = 2;
        }
        else
        {
            // For everything else, just print the 1st character
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

// The speeds that the text prints out at
public enum Speed {Slow, Medium, Fast, VeryFast, Instant}