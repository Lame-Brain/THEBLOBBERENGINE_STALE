using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScreenController : MonoBehaviour
{
    public GameObject itemTileRef, bagSlotRef, groundSlotRef, chestSlotRef;
    [HideInInspector] public Hello_I_am_a_chest thisChest;

    private void Start()
    {
        UpdateInventoryScreenFromInventory();
    }

    private void UpdateInventoryScreenFromInventory()
    {
        GameObject _go = null;

        //Bag Inventory
        for (int _i = 0; _i < GameManager.PARTY.bagInventory.Length; _i++)
        {
            if (GameManager.PARTY.bagInventory[_i] != null)
            {
                _go = Instantiate(itemTileRef, bagSlotRef.transform.GetChild(_i).transform);
                _go.GetComponent<Drag>().thisItem = GameManager.PARTY.bagInventory[_i];
            }
        }

        //Chest Inventory
        for (int _i = 0; _i < thisChest.inventory.Length; _i++)
        {
            if (thisChest.inventory[_i] != null)
            {
                _go = Instantiate(itemTileRef, chestSlotRef.transform.GetChild(_i).transform);
                _go.GetComponent<Drag>().thisItem = thisChest.inventory[_i];
            }
        }
    }
    private void UpdateInventoryFromInventoryScreen()
    {
        //Bag Inventory
        for (int _i = 0; _i < bagSlotRef.transform.childCount; _i++)
        {
            if (bagSlotRef.transform.GetChild(_i).transform.childCount > 0) GameManager.PARTY.bagInventory[_i] = bagSlotRef.transform.GetChild(_i).GetComponentInChildren<Drag>().thisItem;
            if (bagSlotRef.transform.GetChild(_i).transform.childCount == 0) GameManager.PARTY.bagInventory[_i] = null;
        }

        //Chest Inventory
        for (int _i = 0; _i < chestSlotRef.transform.childCount; _i++)
        {
            if (chestSlotRef.transform.GetChild(_i).transform.childCount > 0)  thisChest.inventory[_i] = chestSlotRef.transform.GetChild(_i).GetComponentInChildren<Drag>().thisItem;
            if (chestSlotRef.transform.GetChild(_i).transform.childCount == 0) thisChest.inventory[_i] = null;
        }
    }

    public void CloseChestScreen()
    {
        UpdateInventoryFromInventoryScreen();
        GameManager.EXPLORE.CloseOverlays();
    }
}
