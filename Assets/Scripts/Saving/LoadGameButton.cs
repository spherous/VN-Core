using UnityEngine;
using UnityEngine.UI;

public class LoadGameButton : MonoBehaviour
{
    [SerializeField] private Button button;
    private void Awake() => button.onClick.AddListener(LoadGame.Load);
}