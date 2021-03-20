using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello_I_am_a_Chest : MonoBehaviour
{
    public GameObject ref_ChestPanel;
    public InventoryItem[] inventory = new InventoryItem[16];

    private GameObject chestInventoryScreen;

    public void InteractWithMe()
    {
        //Bring up menu
        GameManager.EXPLORE.selected_Character = -1;
        chestInventoryScreen = Instantiate(ref_ChestPanel, GameManager.EXPLORE.transform);
        chestInventoryScreen.GetComponent<ChestController>().ref_MyChest = transform.gameObject;
        chestInventoryScreen.GetComponent<ChestController>().InventoryToScreen();
    }
}
