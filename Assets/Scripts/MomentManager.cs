using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.InputSystem.InputAction;

public class MomentManager : MonoBehaviour
{
    public static MomentManager instance;
    private UIManager ui => UIManager.instance;

    [ShowInInspector, ReadOnly] public DialogueStrip currentDialogueStrip;
    [ShowInInspector, ReadOnly] public int currentStripIndex = 0;

    [ShowInInspector, ReadOnly] private bool inputBlocked = false;

    private void Awake() => instance = this;

    // private void Start() =>
    //     ui.DisplayDialogue(stripToPlay.dialogueList[currentStripIndex]);

    // This is called when the player provides input
    public void ChangeDialogue(CallbackContext context)
    {
        // If the event was a button release or hold, ignore it
        if(!context.performed || inputBlocked || currentDialogueStrip == null) 
            return;
        
        // If the dialogue box is still printing the previous dialogue, instant finish it.
        if(ui.dialogueBox.printing)
            ui.dialogueBox.PrintAll();
        else
            ChangeDialogue(Mathf.FloorToInt(context.ReadValue<float>()));
    }
    
    public void ChangeDialogue(int progressionValue = 1)
    {
        // Reached the end of the dialogue. Exit momemnt.
        if(progressionValue == 1 && currentStripIndex + 1 >= currentDialogueStrip.dialogueList.Count)
        {
            ui.ExitDialogueStrip(currentDialogueStrip);
            currentDialogueStrip = null;
            return;
        }
        // A progression value of -1 should rewind the dialogue, if available, while 1 should advance the dialogue
        else
            currentStripIndex = progressionValue == 1 
                ? currentStripIndex + 1 : currentStripIndex - 1 <= 0 
                    ? 0 : currentStripIndex - 1;

        ui.DisplayDialogue(currentDialogueStrip.dialogueList[currentStripIndex]);
    }

    public void EnterMoment(DialogueStrip dialogue)
    {
        currentDialogueStrip = dialogue;
        currentStripIndex = 0;
        ui.DisplayDialogue(currentDialogueStrip.dialogueList[currentStripIndex]);
    }
    
    public void JumpToLine(int line)
    {
        if(line < currentDialogueStrip.dialogueList.Count)
        {
            currentStripIndex = line;
            ui.DisplayDialogue(currentDialogueStrip.dialogueList[currentStripIndex]);
        }
    }

    public void ExitMoment()
    {
        currentDialogueStrip = null;
        currentStripIndex = 0;
        ui.CloseDialogueBox();
    }

    public void BlockInput() => inputBlocked = true;
    public void AllowInput() => inputBlocked = false;
}