using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello_I_am_a_Chest : MonoBehaviour
{
    public GameObject ref_ChestPanel;
    public InventoryItem[] inventory = new InventoryItem[16];

    private GameObject chestInventoryScreen;
    private bool TimeIsPassing = false;

    private void Start()
    {
        for (int _i = 0; _i < 16; _i++) if (inventory[_i] != null) inventory[_i] = new InventoryItem(inventory[_i].genericName, inventory[_i].fullName, inventory[_i].description, inventory[_i].lore, inventory[_i].slot, inventory[_i].type, inventory[_i].identified, inventory[_i].magical, inventory[_i].fragile, inventory[_i].twoHanded, inventory[_i].active, inventory[_i].minDamage, inventory[_i].maxDamage,     inventory[_i].fullCharges, inventory[_i].maxDuration, inventory[_i].quality, inventory[_i].currentCharges, inventory[_i].defense, inventory[_i].critMultiplier, inventory[_i].value, inventory[_i].itemIconIndex);
    }

    public void InteractWithMe()
    {
        //Bring up menu
        GameManager.EXPLORE.selected_Character = -1;
        chestInventoryScreen = Instantiate(ref_ChestPanel, GameManager.EXPLORE.transform);
        chestInventoryScreen.GetComponent<ChestController>().ref_MyChest = transform.gameObject;
        GameManager.EXPLORE.current_Chest_Panel = chestInventoryScreen;
        chestInventoryScreen.GetComponent<ChestController>().InventoryToScreen();
    }

    public void TurnPasses()
    {
        for (int _i = 0; _i < 16; _i++)
        {
            if (inventory[_i] != null && inventory[_i].type == InventoryItem.equipType.light && inventory[_i].active) { inventory[_i].active = false; inventory[_i].itemIconIndex++; }
        }
    }

    public void LoadInventory(SaveSlot.serialItem[] serialItem)
    {
        for(int c = 0; c < serialItem.Length; c++)
        {
            Debug.Log(serialItem.Length);

            if (serialItem[c].genericName != "") inventory[c].genericName = serialItem[c].genericName;
            if (serialItem[c].genericName != "") inventory[c].fullName = serialItem[c].fullName;
            if (serialItem[c].genericName != "") inventory[c].description = serialItem[c].description;
            if (serialItem[c].genericName != "") inventory[c].lore = serialItem[c].lore;
            if (serialItem[c].genericName != "") inventory[c].slot = serialItem[c].slot;
            if (serialItem[c].genericName != "") inventory[c].type = serialItem[c].type;
            if (serialItem[c].genericName != "") inventory[c].identified = serialItem[c].identified;
            if (serialItem[c].genericName != "") inventory[c].magical = serialItem[c].magical;
            if (serialItem[c].genericName != "") inventory[c].fragile = serialItem[c].fragile;
            if (serialItem[c].genericName != "") inventory[c].twoHanded = serialItem[c].twoHanded;
            if (serialItem[c].genericName != "") inventory[c].active = serialItem[c].active;
            if (serialItem[c].genericName != "") inventory[c].minDamage = serialItem[c].minDamage;
            if (serialItem[c].genericName != "") inventory[c].maxDamage = serialItem[c].maxDamage;
            if (serialItem[c].genericName != "") inventory[c].fullCharges = serialItem[c].fullCharges;
            if (serialItem[c].genericName != "") inventory[c].maxDuration = serialItem[c].maxDuration;
            if (serialItem[c].genericName != "") inventory[c].quality = serialItem[c].quality;
            if (serialItem[c].genericName != "") inventory[c].currentCharges = serialItem[c].currentCharges;
            if (serialItem[c].genericName != "") inventory[c].currentDuration = serialItem[c].currentDuration;
            if (serialItem[c].genericName != "") inventory[c].defense = serialItem[c].defense;
            if (serialItem[c].genericName != "") inventory[c].critMultiplier = serialItem[c].critMultiplier;
            if (serialItem[c].genericName != "") inventory[c].value = serialItem[c].value;
            if (serialItem[c].genericName != "") inventory[c].itemIconIndex = serialItem[c].itemIconIndex;
        }
    }
}
