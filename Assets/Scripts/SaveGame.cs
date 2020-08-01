using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveGame : MonoBehaviour
{
    MomentManager momentManager => MomentManager.instance;
    [SerializeField] private Button button;

    private void Awake() => button.onClick.AddListener(Save);

    private void Save()
    {
        SaveData saveData = new SaveData();
        saveData.currentDialogueLine = momentManager.currentStripIndex;
        saveData.currentStrip = momentManager.currentDialogueStrip;
        File.WriteAllText(Application.persistentDataPath + Path.DirectorySeparatorChar + "Save", JsonUtility.ToJson(saveData));
    }
}