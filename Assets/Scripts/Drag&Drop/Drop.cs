using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drop : MonoBehaviour, IDropHandler
{
    public Item.Slot ThisSlotType;

    public void OnDrop(PointerEventData eventData)
    {
        if (ThisSlotType == Item.Slot.general || eventData.pointerDrag.transform.GetComponent<Drag>().thisItem.Slot() == ThisSlotType) //If the slot is a general slot, or if the slot type is the correct one for the item.
        {
            if (gameObject.transform.childCount == 0) //if the slot is empty
            {
                //Debug.Log("Dragged from " + eventData.pointerDrag.transform.parent.name + ", a " + eventData.pointerDrag.transform.parent.GetComponent<ItemSlotController>().slotType + " slot, to " + gameObject.name + ", a " + slotType + " slot");
                //Debug.Log("Dropped " + eventData.pointerDrag.name+" on " + gameObject.name);
                //Debug.Log("Dragged from " + eventData.pointerDrag.transform.parent.tag + " to " + gameObject.tag);

                eventData.pointerDrag.transform.SetParent(this.transform);
            }
            else if (gameObject.transform.childCount > 0) //Slot is in use, can we swap?
            {
                if(eventData.pointerDrag.transform.GetComponent<Drag>().Old_Parent.GetComponent<Drop>().ThisSlotType == Item.Slot.general ||                                       // This code checks if the item already in 
                    eventData.pointerDrag.transform.GetComponent<Drag>().Old_Parent.GetComponent<Drop>().ThisSlotType == transform.GetComponentInChildren<Drag>().thisItem.Slot()) // the slot can swap to the other slot
                {
                    Debug.Log("SWAP GO!");

                    //Put existing child to OLD_Parent                    
                    transform.GetChild(0).transform.SetParent(eventData.pointerDrag.transform.GetComponent<Drag>().Old_Parent.transform);

                    //put TOP CANVAS item to this slot
                    eventData.pointerDrag.transform.SetParent(transform);

                    //set all items to 0,0,0
                    foreach (GameObject _go in GameObject.FindGameObjectsWithTag("UI_ItemTile")) _go.transform.localPosition = Vector3.zero;
                }
            }
        }
    }
}
