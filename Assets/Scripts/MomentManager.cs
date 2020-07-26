using Sirenix.OdinInspector;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class MomentManager : MonoBehaviour
{
    private UIManager ui => UIManager.instance;

    public DialogueStrip stripToPlay;
    [ReadOnly] private int currentStripIndex = 0;

    private void Start()
    {
        ui.DisplayDialogue(stripToPlay.dialogueList[currentStripIndex]);
    }

    public void ChangeDialogue(CallbackContext context)
    {
        if(!context.performed)
            return;

        int value = Mathf.FloorToInt(context.ReadValue<float>());

        currentStripIndex = value == 1 
            ? currentStripIndex + 1 >= stripToPlay.dialogueList.Count ? 0 : currentStripIndex + 1
            : currentStripIndex - 1 <= 0 ? 0 : currentStripIndex - 1;

        ui.DisplayDialogue(stripToPlay.dialogueList[currentStripIndex]);
    }
}