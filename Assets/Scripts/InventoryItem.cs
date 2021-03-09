using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Flags]
public enum slotType { none, hand, head, torso, neck, ring, leg, foot, bag }

[CreateAssetMenu]
public class InventoryItem : ScriptableObject
{
    public string genericName, fullName, description, lore;
    public slotType slot;
    public bool identified, magical, fragile, twoHanded;
    public int minDamage, maxDamage, fullCharges, quality;
    public float defense, critMultiplier, value;
    public Sprite itemIcon;
}

/* Generic Name and description are shown if the item is not identified.
 * FullName and Lore are shown if the item is identified
 * value is useful for random tables
 * Damage values and critMult are for weapons
 * Charges show how many charges are max.... current charges are tracked by an items inventorySlotItem
 * defense is for armor
 * everything gets an Icon.
 */
