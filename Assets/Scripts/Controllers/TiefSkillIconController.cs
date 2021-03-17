using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TiefSkillIconController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        string _interactionType = GameManager.PARTY.interactContext;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.ShowToolTip_Static("Thief Skills allow you to attempt to bypass locks and disarm traps.");        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideToolTip_Static();
    }
}
