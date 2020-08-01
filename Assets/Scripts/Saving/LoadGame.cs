using System.IO;
using UnityEngine;

public static class LoadGame
{
    private static MomentManager momentManager => MomentManager.instance;

    public static void Load()
    {
        if(!File.Exists(GamePaths.savePath + "Save"))
            return;
        
        SaveData save = JsonUtility.FromJson<SaveData>(
            File.ReadAllText(GamePaths.savePath + "Save")
        );
        
        if(save.currentStrip != null)
        {
            momentManager.EnterMoment(save.currentStrip);
            momentManager.JumpToLine(save.currentDialogueLine);
        }
        else
            momentManager.ExitMoment();
    }
}