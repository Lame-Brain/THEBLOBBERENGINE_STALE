using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridNode : MonoBehaviour
{
    public GameObject northLink;
    public GameObject eastLink;
    public GameObject southLink;
    public GameObject westLink;
    public GameObject northDoor;
    public GameObject eastDoor;
    public GameObject southDoor;
    public GameObject westDoor;
    [HideInInspector]
    public bool northChest = false, eastChest = false, southChest = false, westChest = false;
    [HideInInspector]
    public bool northTorch = false, eastTorch = false, southTorch = false, westTorch = false;

    public int nodeX, nodeY;
    public InventoryItem[] inventory = new InventoryItem[9];

    public int trapLevel, trapDamage;
    public bool trapDark;

    private void OnDrawGizmosSelected()
    {        
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 1);
    }

    private void Awake()
    {
        DynamicProps();
    }

    private void Start()
    {
        for(int _i =0; _i < 9; _i++) if (inventory[_i] != null) inventory[_i] = new InventoryItem(inventory[_i].genericName, inventory[_i].fullName, inventory[_i].description, inventory[_i].lore,
    inventory[_i].slot, inventory[_i].type, inventory[_i].identified, inventory[_i].magical, inventory[_i].fragile, inventory[_i].twoHanded, inventory[_i].active, inventory[_i].minDamage, inventory[_i].maxDamage,
    inventory[_i].fullCharges, inventory[_i].maxDuration, inventory[_i].quality, inventory[_i].currentCharges, inventory[_i].defense, inventory[_i].critMultiplier, inventory[_i].value, inventory[_i].itemIconIndex);
    }

    public void SetNodePosition(int x, int y)
    {
        nodeX = x;
        nodeY = y;
    }

    public void DynamicProps()
    {
        int _count = 0;
        for(int _i = 0; _i < inventory.Length; _i++)
        {
            if (inventory[_i] != null) _count++;
        }
        if (_count == 0) { transform.Find("BagSprite").gameObject.SetActive(false); }
        else { transform.Find("BagSprite").gameObject.SetActive(true); }
    }
    public void TurnPasses()
    {
        for (int _i = 0; _i < 9; _i++)
        {
            if (inventory[_i] != null && inventory[_i].type == InventoryItem.equipType.light && inventory[_i].active) { inventory[_i].active = false; inventory[_i].itemIconIndex++; }
        }
    }

    public void LoadInventory(DynamicLevelController.serialItem[] serialItem)
    {
        for (int c = 0; c < serialItem.Length; c++)
        {
            if(serialItem[c].genericName != "") inventory[c].genericName = serialItem[c].genericName;
            if (serialItem[c].genericName != "") inventory[c].fullName = serialItem[c].fullName;
            if (serialItem[c].genericName != "") inventory[c].description = serialItem[c].description;
            if (serialItem[c].genericName != "") inventory[c].lore = serialItem[c].lore;
            if (serialItem[c].genericName != "") inventory[c].slot = serialItem[c].slot;
            if (serialItem[c].genericName != "") inventory[c].type = serialItem[c].type;
            if (serialItem[c].genericName != "") inventory[c].identified = serialItem[c].identified;
            if (serialItem[c].genericName != "") inventory[c].magical = serialItem[c].magical;
            if (serialItem[c].genericName != "") inventory[c].fragile = serialItem[c].fragile;
            if(serialItem[c].genericName != "") inventory[c].twoHanded = serialItem[c].twoHanded;
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
