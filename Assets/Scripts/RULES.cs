using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RULES : MonoBehaviour
{
    [Header("24 is slowest, 0 is fastest")] public float moveSpeed;
    public float turnSpeed;
    public float MoveDelay;
    public float TileSize; //Find location by adding half this value, then dividing by this value to x and z
    public int Fighter_Health, Rogue_Health, Cleric_Health, Mage_Health;
    public int Fighter_Mana, Rogue_Mana, Cleric_Mana, Mage_Mana;
    public float Fighter_Attack, Rogue_Attack, Cleric_Attack, Mage_Attack;
    public int NNL_perLevel, FreePointsPerLevel;
}
