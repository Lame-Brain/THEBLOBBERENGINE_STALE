using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TiefSkillIconController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        string _interactionType = GameManager.PARTY.interactContext;
        GameObject _interactionObj = GameManager.PARTY.Interact_Object;
        //MessageWindow.ShowMessage_Static(_interactionType);
        if (_interactionType == "") //SEARCH
        {
            MessageWindow.ShowMessage_Static(GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].characterName + " looks around, but there is nothing to be found.");
            GameManager.EXPLORE.ClearAllScreens();
        }
        if (_interactionType == "LOCKED DOOR")
        {
            _interactionObj.GetComponent<Hello_I_am_a_door>().UnlockDoor();            
        }
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
