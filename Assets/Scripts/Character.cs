using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum characterClass { monster, fighter, rogue, mage, cleric}
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
    public Sprite portrait;
}
