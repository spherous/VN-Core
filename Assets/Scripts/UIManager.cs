using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public DialogueBox dialogueBox;
    
    private void Awake()
    {
        instance = this;
        dialogueBox.gameObject.SetActive(false);
    }

    public void DisplayDialogue(Dialogue dialogue)
    {
        if(!dialogueBox.gameObject.activeSelf)
            dialogueBox.gameObject.SetActive(true);
        dialogueBox.DisplayDialogue(dialogue);
    }
}