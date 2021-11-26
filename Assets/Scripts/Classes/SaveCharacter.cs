using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveCharacter
{
    public string PCname;
    public string PCclass;
    public int Base_Str, Mod_Str;
    public int Base_Dex, Mod_Dex;
    public int Base_IQ, Mod_IQ;
    public int Base_Wis, Mod_Wis;
    public int Base_Chrm, Mod_Chrm;
    public int Base_Health, Mod_Health;
    public int hp, maxHp;
    public int xp, xpNNL;
    public int Base_Attk, Mod_Attk;
    public int Base_Block, Mod_Block;
    public int Base_Dodge, Mod_Dodge;
    public float Base_Reflex, Mod_Reflex;
    public float Base_Fortitude, Mod_Fortitude;
    public float Base_Willpower, Mod_Willpower;
    public int initBonus;

    public int NumConditions;
    public List<int[]> condition = new List<int[]>();
    public int[] head_EQ = new int[5];
    public int[] neck_EQ = new int[5];
    public int[] armor_EQ = new int[5];
    public int[] wrists_EQ = new int[5];
    public int[] ring1_EQ = new int[5];
    public int[] ring2_EQ = new int[5];
    public int[] waist_EQ = new int[5];
    public int[] feet_EQ = new int[5];
    public int[] weapon_EQ = new int[5];
    public int[] shield_EQ = new int[5];    
    public int[,] BagItems = new int[5, 25];
    public string[,] KnownSpells = new string[5, 10];
    public int NumSkills;
    public List<string> skilllist = new List<string>();
}
