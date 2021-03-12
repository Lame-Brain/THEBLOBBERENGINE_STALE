using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemTileController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public InventoryItem item = null;
    private static bool enableToolTips = true;

    public void OnDrag(PointerEventData eventData)
    {
        enableToolTips = false;
        transform.GetComponent<Image>().raycastTarget = false;
        transform.position = eventData.position;
        transform.parent.transform.SetAsLastSibling();
        transform.parent.parent.transform.SetAsLastSibling();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        enableToolTips = true;
        transform.localPosition = Vector3.zero;
        transform.GetComponent<Image>().raycastTarget = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Right Click
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Right Mouse Button Clicked on: " + item.genericName);
        }

        //Left Click
        if (eventData.button == PointerEventData.InputButton.Left && eventData.clickCount == 1)
        {
            Debug.Log("Left Mouse Button Clicked on: " + item.genericName);
        }

        //Left Click
        if (eventData.button == PointerEventData.InputButton.Left && eventData.clickCount == 2)
        {
            Debug.Log("Left Mouse Button Double Clicked on: " + item.genericName);

            bool _done = false;

            //if clicked on light, toggle active.
            if (item.type == InventoryItem.equipType.light)
            {
                item.active = !item.active;
                if (item.active) Tooltip.ShowToolTip_Static(" It is now lit ");
                if (!item.active) Tooltip.ShowToolTip_Static(" It is now unlit ");
                _done = true;
            }

            //If clicked on potion, use it.
            if (item.type == InventoryItem.equipType.potion)
            {
                _done = true;
            }

            //If clicked on weapons or armor, look for an empty slot. If found, equip. If not, relocate to next available bag slot.
            if (item.type == InventoryItem.equipType.weapon || item.type == InventoryItem.equipType.armor)
            {
                if (!_done && item.slot == InventoryItem.slotType.head && GameManager.EXPLORE.current_InventoryScreen.transform.Find("Head_Slot").childCount == 0) { transform.SetParent(GameManager.EXPLORE.current_InventoryScreen.transform.Find("Head_Slot").transform); _done = true; }
                if (!_done && item.slot == InventoryItem.slotType.neck && GameManager.EXPLORE.current_InventoryScreen.transform.Find("Neck_Slot").childCount == 0) { transform.SetParent(GameManager.EXPLORE.current_InventoryScreen.transform.Find("Neck_Slot").transform); _done = true; }
                if (!_done && item.slot == InventoryItem.slotType.ring && GameManager.EXPLORE.current_InventoryScreen.transform.Find("RightFinger_Slot").childCount == 0) { transform.SetParent(GameManager.EXPLORE.current_InventoryScreen.transform.Find("RightFinger_Slot").transform); _done = true; }
                if (!_done && item.slot == InventoryItem.slotType.ring && GameManager.EXPLORE.current_InventoryScreen.transform.Find("LeftFinger_Slot").childCount == 0) { transform.SetParent(GameManager.EXPLORE.current_InventoryScreen.transform.Find("LeftFinger_Slot").transform); _done = true; }
                if (!_done && item.slot == InventoryItem.slotType.hand && GameManager.EXPLORE.current_InventoryScreen.transform.Find("RightHand_Slot").childCount == 0) { transform.SetParent(GameManager.EXPLORE.current_InventoryScreen.transform.Find("RightHand_Slot").transform); _done = true; }
                if (!_done && item.slot == InventoryItem.slotType.hand && GameManager.EXPLORE.current_InventoryScreen.transform.Find("LeftHand_Slot").childCount == 0) { transform.SetParent(GameManager.EXPLORE.current_InventoryScreen.transform.Find("LeftHand_Slot").transform); _done = true; }
                if (!_done && item.slot == InventoryItem.slotType.torso && GameManager.EXPLORE.current_InventoryScreen.transform.Find("Torso_Slot").childCount == 0) { transform.SetParent(GameManager.EXPLORE.current_InventoryScreen.transform.Find("Torso_Slot").transform); _done = true; }
                if (!_done && item.slot == InventoryItem.slotType.leg && GameManager.EXPLORE.current_InventoryScreen.transform.Find("Legs_Slot").childCount == 0) { transform.SetParent(GameManager.EXPLORE.current_InventoryScreen.transform.Find("Legs_Slot").transform); _done = true; }
                if (!_done && item.slot == InventoryItem.slotType.foot && GameManager.EXPLORE.current_InventoryScreen.transform.Find("Feet_Slot").childCount == 0) { transform.SetParent(GameManager.EXPLORE.current_InventoryScreen.transform.Find("Feet_Slot").transform); _done = true; }
            }

            //relocate to next empty bag slot.
            if(!_done)
            {
                int _result = 19;
                for (int _i = 19; _i >= 0; _i--)
                {
                    if (GameManager.EXPLORE.current_InventoryScreen.transform.Find("Bag_Inventory").GetChild(_i).childCount == 0) _result = _i; //Find the lowest empty slot
                }
                transform.SetParent(GameManager.EXPLORE.current_InventoryScreen.transform.Find("Bag_Inventory").GetChild(_result).transform); //Set object to selected slot
            }

            Tooltip.HideToolTip_Static();
            GameManager.EXPLORE.current_InventoryScreen.GetComponent<Inventory_Controller>().ScreenToInventory();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        string output = null;
        if (!item.identified) output = item.genericName + "\n" + item.description;
        if (item.identified) output = item.fullName + "\n" + item.lore;
        if (item.type == InventoryItem.equipType.weapon) output += "\nDamage: " + item.minDamage + " to " + item.maxDamage;
        if (item.type == InventoryItem.equipType.armor) output += "\nDefense bonus: " + item.defense;
        if (item.type == InventoryItem.equipType.potion) output += "\nDouble Click to use.";
        if (item.type == InventoryItem.equipType.light) output += "\nDuration: " + item.currentDuration + " of " + item.maxDuration;
        if (item.fragile) output += "\nThis item is fragile.";
        if (item.type == InventoryItem.equipType.light && item.active) output += "\nDouble Click to snuff.";
        if (item.type == InventoryItem.equipType.light && !item.active) output += "\nDouble Click to light.";
        if (item.type == InventoryItem.equipType.weapon || item.type == InventoryItem.equipType.weapon) output += "\nDouble Click to equip or unequip.";

        if (enableToolTips) Tooltip.ShowToolTip_Static(output);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideToolTip_Static();
    }

    public void UpdateItemTile()
    {
        GetComponentInParent<Image>().sprite = GameManager.GAME.item_Icons[item.itemIconIndex];
    }

    public void PassTime()
    {
        if(item.type == InventoryItem.equipType.light && item.active)
        {
            item.currentDuration--; //active lightsource reduces duration

            if(item.currentDuration < 5) // light flicker
            {
                //ToDo: light flicker warning that light is low
            }

            if(item.currentDuration < 0) // active lightsources burn out if duration is less than 0.
            {
                Destroy(this);
                GameManager.EXPLORE.current_InventoryScreen.GetComponent<Inventory_Controller>().ScreenToInventory();
            }
        }
    }
}
