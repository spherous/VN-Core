using System;
using UnityEngine;
using UnityEngine.UI;

public class AutoPlayToggle : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image image;
    [SerializeField] private DialogueBox dialogueBox;

    [SerializeField] private Color onColor;
    [SerializeField] private Color offColor;

    private void Awake() => button.onClick.AddListener(ToggleAuto);

    private void ToggleAuto()
    {
        dialogueBox.autoPlay = !dialogueBox.autoPlay;
        image.color = dialogueBox.autoPlay ? onColor : offColor;
    }
}
