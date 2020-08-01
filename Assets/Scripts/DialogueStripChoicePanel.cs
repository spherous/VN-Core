using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStripChoicePanel : MonoBehaviour
{
    [SerializeField] private GameObject dialogueStripChoicePrefab;
    [SerializeField] private List<DialogueStrip> dialogueStrips = new List<DialogueStrip>();
    private List<DialogueStripOption> existingOptions = new List<DialogueStripOption>();
    
    private void Start() => PopulateWithDialogueStrips();

    private void PopulateWithDialogueStrips()
    {
        for(int i = 0; i < dialogueStrips.Count; i++)
            AddDialogueChoice(dialogueStrips[i]);
    }

    private void AddDialogueChoice(DialogueStrip dialogueStrip)
    {
        DialogueStripOption newOption = Instantiate(
            dialogueStripChoicePrefab,
            transform
        ).GetComponent<DialogueStripOption>();
        existingOptions.Add(newOption);
        newOption.Init(dialogueStrip);
    }

    public void RemoveStrip(DialogueStrip strip)
    {
        for(int i = 0; i < dialogueStrips.Count; i++)
        {
            if(dialogueStrips[i] == strip)
            {
                dialogueStrips.Remove(dialogueStrips[i]);
                Destroy(existingOptions[i].gameObject);
                existingOptions.RemoveAt(i);
            }
        }
    }
}