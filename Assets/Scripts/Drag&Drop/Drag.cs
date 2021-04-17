using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item thisItem;
    public Transform Old_Parent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //1. store original parent object transform
        Old_Parent = this.transform.parent;
        //2. parent THIS item to Top-Level Canvas
        this.transform.SetParent(GameManager.EXPLORE.TOPLEVEL.transform);
        //3. Turn Raycast Target off
        transform.GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //match this transform to mouse pointer
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Check if item is still parent to TOPLEVEL, and put it back if so.
        if(transform.parent.name == GameManager.EXPLORE.TOPLEVEL.name) transform.SetParent(Old_Parent);
        //Center item on parent
        transform.localPosition = Vector3.zero;
        //Turn raycast target back on
        transform.GetComponent<Image>().raycastTarget = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        string _result = "";

        //Design ToolTip
        _result = this.thisItem.GetName() + ": " + this.thisItem.GetInfo();
        if (this.thisItem.itm_Type == Item.Type.axe) _result += "\nThis is an axe.";
        if (this.thisItem.itm_Type == Item.Type.simple_weapon) _result += "\nThis is a simple weapon.";
        if (this.thisItem.itm_Type == Item.Type.sword) _result += "\nThis is a sword.";
        if (this.thisItem.itm_Type == Item.Type.mace) _result += "\nThis is a mace.";
        if (this.thisItem.itm_Type == Item.Type.light_armor) _result += "\nThis is light armor.";
        if (this.thisItem.itm_Type == Item.Type.medium_armor) _result += "\nThis is a medium armor.";
        if (this.thisItem.itm_Type == Item.Type.heavy_armor) _result += "\nThis is a heavy armor.";
        if (this.thisItem.itm_Type == Item.Type.head) _result += "\nIt is worn on the head.";
        if (this.thisItem.itm_Type == Item.Type.light_source) _result += "\nThis is a lightsource.";        
        if (this.thisItem.itm_Type == Item.Type.neck) _result += "\nThis is worn around your neck.";
        if (this.thisItem.itm_Type == Item.Type.ring) _result += "\nThis is worn on a finger.";
        if (this.thisItem.GetAttack() != 0) _result += "This item modifies Attack by " + this.thisItem.GetAttack();
        if (this.thisItem.GetMinDamage() != 0 || this.thisItem.GetMaxDamage() != 0) _result += "\nThis item does between " + this.thisItem.GetMinDamage() + " and " + this.thisItem.GetMaxDamage() + " points of damage.";
        if (this.thisItem.GetDefense() != 0) _result += "\nThis item modifies Defense = " + this.thisItem.GetDefense();


        //To DO: add magical and curse checks when I have characters to check
        if (!this.thisItem.itm_ID) _result += "\nIdentifing the item may give more information.";


        Tooltip.ShowToolTip_Static(_result);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideToolTip_Static();
    }

    private void Update()
    {
        this.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = GameManager.GAME.ItemIcon[this.thisItem.itm_Icon];
    }
}
