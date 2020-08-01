using System.IO;
using UnityEngine;

public static class SaveGame 
{
    private static MomentManager momentManager => MomentManager.instance;
    
    public static void Save()
    {
        SaveData saveData = new SaveData(
            momentManager.currentDialogueStrip,
            momentManager.currentStripIndex
        );

        File.WriteAllText(GamePaths.savePath + "Save", JsonUtility.ToJson(saveData));
    }
}