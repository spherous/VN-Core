using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.InputSystem.InputAction;

public class MomentManager : MonoBehaviour
{
    public static MomentManager instance;
    private UIManager ui => UIManager.instance;

    public DialogueStrip stripToPlay;
    [ShowInInspector, ReadOnly] private int currentStripIndex = 0;

    [ShowInInspector, ReadOnly] private bool inputBlocked = false;

    private void Awake() => instance = this;

    private void Start() =>
        ui.DisplayDialogue(stripToPlay.dialogueList[currentStripIndex]);

    // This is called when the player provides input
    public void ChangeDialogue(CallbackContext context)
    {
        // If the event was a button release or hold, ignore it
        if(!context.performed || inputBlocked) 
            return;
        
        // If the dialogue box is still printing the previous dialogue, instant finish it.
        if(ui.dialogueBox.printing)
            ui.dialogueBox.PrintAll();
        else
        {
            // A progression value of -1 should  rewind the dialogue, if available, while 1 should advance the dialogue
            int progressionValue = Mathf.FloorToInt(context.ReadValue<float>());
            
            currentStripIndex = progressionValue == 1 
                ? currentStripIndex + 1 >= stripToPlay.dialogueList.Count ? 0 : currentStripIndex + 1
                : currentStripIndex - 1 <= 0 ? 0 : currentStripIndex - 1;

            ui.DisplayDialogue(stripToPlay.dialogueList[currentStripIndex]);
        }
    }

    public void BlockInput() => inputBlocked = true;
    public void AllowInput() => inputBlocked = false;
}