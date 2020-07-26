using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu]
public class DialogueStrip : ScriptableObject
{
    public TextAsset dialogueScript;
    public List<Dialogue> dialogueList = new List<Dialogue>();

    [Button]
    public void ReloadAssetData()
    {
        dialogueList.Clear();
        
        string[] lines = dialogueScript.text.Split(new string[]{Environment.NewLine}, StringSplitOptions.None);
        for(int i = 0; i < lines.Length; i++)
        {
            Match match = Regex.Match(lines[i], @"(?<name>.*)\: (?<dialogue>.*)");
            
            // If the regex fails, we know there was no speaker, thus we can assume this line is narration
            if(!match.Success)
            {
                dialogueList.Add(new Dialogue{dialogue = lines[i]});
                continue;
            }
            
            dialogueList.Add(new Dialogue{
                speaker = match.Groups["name"].Value,
                dialogue = match.Groups["dialogue"].Value
            });
        }
    }
}