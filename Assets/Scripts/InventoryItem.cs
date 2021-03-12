using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class InventoryItem: ScriptableObject
{
    public enum slotType { none, hand, head, torso, neck, ring, leg, foot, bag }
    public enum equipType { misc, weapon, armor, light, potion }
    public string genericName, fullName, description, lore;
    public slotType slot;
    public equipType type;
    public bool identified, magical, fragile, twoHanded, active;
    public int minDamage, maxDamage, fullCharges, maxDuration, quality;
    public int currentCharges, currentDuration;
    public float defense, critMultiplier, value;
    public int itemIconIndex;

    public InventoryItem LoadItem(SaveSlot.serialItem i)
    {
        genericName = i.genericName;
        fullName = i.fullName;
        description = i.description;
        lore = i.lore;
        slot = i.slot;
        type = i.type;
        identified = i.identified;
        magical = i.magical;
        fragile = i.fragile;
        twoHanded = i.twoHanded;
        active = i.active;
        minDamage = i.minDamage;
        maxDamage = i.maxDamage;
        fullCharges = i.fullCharges;
        maxDuration = i.maxDuration;
        quality = i.quality;
        currentCharges = i.currentCharges;
        currentDuration = i.currentDuration;
        defense = i.defense;
        critMultiplier = i.critMultiplier;
        value = i.value;
        itemIconIndex = i.itemIconIndex;

        return this;
    }
}