using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueStripOption : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    MomentManager momentManager => MomentManager.instance;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI titleText;
    private DialogueStrip dialogueStrip;

    [SerializeField] private Color defaultColor;
    [SerializeField] private Color hoverColor;

    public void Init(DialogueStrip strip)
    {
        image.color = defaultColor;
        dialogueStrip = strip;
        titleText.text = dialogueStrip.name;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        momentManager.EnterMoment(dialogueStrip);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = hoverColor;        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = defaultColor;
    }
}