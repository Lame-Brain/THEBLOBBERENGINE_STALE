using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public enum characterClass { monster, Fighter, Rogue, Mage, Cleric}
    public string characterName;
    public characterClass type;
    public int xpLevel, xpPoints, xpNNL, freePoints;
    [Header("Attributes")]
    public int strength;
    public int dexterity, intelligence, wisdom, charisma;
    [Header("Derived Stats")]
    public float health;
    public float wounds, mana, drain, defense, attack;
    [Header("Portrait")]
    public int portraitIndex;
    [Header("Equipped Inventory")]
    public InventoryItem eq_Head;
    public InventoryItem eq_Neck, eq_LeftFinger, eq_RightFinger, eq_LeftHand, eq_RightHand, eq_Torso, eq_Legs, eq_Feet;
    [Header("Stance")]
    public bool frontLine;

    public void LoadCharacter(SaveSlot.serialCharacter c)
    {
        characterName = c.characterName;
        type = c.type;
        xpLevel = c.xpLevel; xpPoints = c.xpPoints; xpNNL = c.xpNNL; freePoints = c.freePoints;
        strength = c.strength; dexterity = c.dexterity;
        intelligence = c.intelligence; wisdom = c.wisdom;
        charisma = c.charisma;
        health = c.health; wounds = c.wounds;
        mana = c.mana; drain = c.drain;
        defense = c.defense; attack = c.attack;
        portraitIndex = c.portraitIndex;
        if (c.eq_Head.genericName != "") eq_Head = eq_Head.LoadItem(c.eq_Head);
        if (c.eq_Neck.genericName != "") eq_Neck = eq_Neck.LoadItem(c.eq_Neck);
        if (c.eq_LeftFinger.genericName != "") eq_LeftFinger = eq_LeftFinger.LoadItem(c.eq_LeftFinger);
        if (c.eq_RightFinger.genericName != "") eq_RightFinger = eq_RightFinger.LoadItem(c.eq_RightFinger);
        if (c.eq_LeftHand.genericName != "") eq_LeftHand = eq_LeftHand.LoadItem(c.eq_LeftHand);
        if (c.eq_RightHand.genericName != "") eq_RightHand = eq_RightHand.LoadItem(c.eq_RightHand);
        if (c.eq_Torso.genericName != "") eq_Torso = eq_Torso.LoadItem(c.eq_Torso);
        if (c.eq_Legs.genericName != "") eq_Legs = eq_Legs.LoadItem(c.eq_Legs);
        if (c.eq_Feet.genericName != "") eq_Feet = eq_Feet.LoadItem(c.eq_Feet);
    }
}   

 
