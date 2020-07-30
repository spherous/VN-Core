using UnityEngine;
using UnityEngine.EventSystems;

public class BlockInputOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    MomentManager momentManager => MomentManager.instance;

    public void OnPointerEnter(PointerEventData eventData) => momentManager.BlockInput();
    public void OnPointerExit(PointerEventData eventData) => momentManager.AllowInput();
}