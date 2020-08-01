using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public DialogueBox dialogueBox;
    public DialogueStripChoicePanel dialogueStripChoicePanel;
    
    private void Awake()
    {
        instance = this;
        dialogueBox.gameObject.SetActive(false);
    }

    public void DisplayDialogue(Dialogue dialogue)
    {
        if(!dialogueBox.gameObject.activeSelf)
            dialogueBox.gameObject.SetActive(true);

        if(dialogueStripChoicePanel.gameObject.activeSelf)
            dialogueStripChoicePanel.gameObject.SetActive(false);

        dialogueBox.DisplayDialogue(dialogue);
    }
    public void ExitDialogueStrip(DialogueStrip strip)
    {
        dialogueBox.gameObject.SetActive(false);
        dialogueStripChoicePanel.gameObject.SetActive(true);
        dialogueStripChoicePanel.RemoveStrip(strip);
    }
    public void CloseDialogueBox()
    {
        if(dialogueBox.gameObject.activeSelf)
            dialogueBox.gameObject.SetActive(false);
        if(!dialogueStripChoicePanel.gameObject.activeSelf)
            dialogueStripChoicePanel.gameObject.SetActive(true);
    }
}