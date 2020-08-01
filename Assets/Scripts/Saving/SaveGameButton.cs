using UnityEngine;
using UnityEngine.UI;

public class SaveGameButton : MonoBehaviour
{
    [SerializeField] private Button button;
    
    private void Awake() => button.onClick.AddListener(SaveGame.Save);
}
