﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem 
{
    public enum slotType { none, hand, head, torso, neck, ring, leg, foot, bag }
    public string genericName, fullName, description, lore;
    public slotType slot;
    public bool identified, magical, fragile, twoHanded, active;
    public int minDamage, maxDamage, fullCharges, maxDuration, quality;
    private int currentCharges, currentDuration;
    public float defense, critMultiplier, value;
    public int itemIconIndex;
}