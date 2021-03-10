using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NewInventoryItem : ScriptableObject
{
    public enum slotType { none, hand, head, torso, neck, ring, leg, foot, bag }
    public string genericName, fullName, description, lore;
    public slotType slot;
    public bool identified, magical, fragile, twoHanded, active;
    public int minDamage, maxDamage, fullCharges, maxDuration, quality;
    private int currentCharges, currentDuration;
    public float defense, critMultiplier, value;
    public Sprite itemIcon;
    public int itemIconIndex;
}

/* Generic Name and description are shown if the item is not identified.
 * FullName and Lore are shown if the item is identified
 * value is useful for random tables
 * Damage values and critMult are for weapons
 * Charges show how many charges are max.... current charges are tracked by an items inventorySlotItem
 * defense is for armor
 * everything gets an Icon.
 */
