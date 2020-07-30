using UnityEngine;
using TMPro;

public class UpdateTextSpeed : MonoBehaviour
{
    [SerializeField] private DialogueBox dialogueBox;
    [SerializeField] private TMP_Dropdown dropdown;
    
    public void UpdateSpeed() => dialogueBox.textPrintingSpeed = (Speed)dropdown.value;
}