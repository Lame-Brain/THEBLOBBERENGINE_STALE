using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public enum characterClass { monster, fighter, rogue, mage, cleric}
    public string characterName;
    public characterClass type;
    public int xpLevel, xpPoints, xpNNL;
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
    public InventoryItem eq_Neck, eq_LeftFinger, eq_RightFinger, eq_LeftHand, eq_RightHand, eq_Legs, eq_Feet;
}   

 
