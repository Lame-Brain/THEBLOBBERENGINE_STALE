using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlobberEngine;

public class PlayerCharacter
{    
    public string pcName;
    public _enum.CharacterClass pcClass;

    //Stats
    private int Base_Str, Mod_Str;
    private int Base_Dex, Mod_Dex;
    private int Base_IQ, Mod_IQ;
    private int Base_Wis, Mod_Wis;
    private int Base_Chrm, Mod_Chrm;
    private int Base_Health, Mod_Health;
    private int hp, maxHp, Mod_maxHp;
    private int xp, xpNNL, Drain_xp;
    private int Base_Attk, Mod_Attk;
    private int Base_Block, Mod_Block;
    private int Base_Dodge, Mod_Dodge;

    
    public int initBonus, hp_per_step;

    public int Strength() { return Base_Str + Mod_Str; }
    public int Strength(int value) { return Mod_Str += value; }
    public int Dexterity() { return Base_Dex + Mod_Dex; }
    public void Dexterity(int value) { Mod_Dex += value; }
    public int IQ() { return Base_IQ + Mod_IQ; }
    public int IQ(int value) { return Mod_IQ += value; }
    public int Wisdom() { return Base_Wis + Mod_Wis; }
    public int Wisdom(int value) { return Mod_Wis += value; }
    public int Charm() { return Base_Chrm + Mod_Chrm; }
    public int Charm(int value) { return Mod_Chrm += value; }
    public int Health() { return Base_Health + Mod_Health; }
    public int Health(int value) { return Mod_Health += value; }
    public int HP() { return hp; }
    public int HP(int value) { return hp += value; }
    public int MaxHP() { return maxHp + Mod_maxHp; }
    public int MaxHP(int value) { return Mod_maxHp += value; }
    public float HpPercent() { return ((maxHp + Mod_maxHp) - hp) / (maxHp + Mod_maxHp); }
    public int XP() { return xp + Drain_xp; }
    public int XP(int value) 
    { 
        Drain_xp += value;
        if (Drain_xp > 0) Drain_xp = 0;
        return xp += (value + Drain_xp); 
    }
    public int XP_NNL() { return xpNNL; }
    public float XP_Percent() { return (xpNNL - xp) / xpNNL; }
    public int Attack() { return Base_Attk + Mod_Attk; }
    public int Attack(int value) { return Mod_Attk += value; }
    public int BlockAC() { return Base_Block + Mod_Block; }
    public int BlockAC(int value) { return Mod_Block += value; }
    public int DodgeAC() { return Base_Dodge + Mod_Dodge; }
    public int DodgeAC(int value) { return Mod_Dodge += value; }
        
}
