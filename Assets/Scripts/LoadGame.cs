using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    MomentManager momentManager => MomentManager.instance;
    [SerializeField] private Button button;

    private void Awake() => button.onClick.AddListener(Load);

    private void Load()
    {
        if(File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "Save"))
        {
            SaveData save = JsonUtility.FromJson<SaveData>(
                File.ReadAllText(Application.persistentDataPath + Path.DirectorySeparatorChar + "Save")
            );
            
            if(save.currentStrip != null)
            {
                momentManager.EnterMoment(save.currentStrip);
                momentManager.JumpToLine(save.currentDialogueLine);
            }
            else
            {
                momentManager.ExitMoment();
            }
        }
    }
}
