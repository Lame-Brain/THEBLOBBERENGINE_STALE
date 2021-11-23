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
    private int hp, maxHp;
    private int xp, xpNNL;
    private int attk_base, attk_mod;
    private int armorClass_base, armorClass_mod;
    
    public int initBonus, hp_per_step;

    public int Strength() { return Base_Str + Mod_Str; }
    public int Dexterity() { return Base_Dex + Mod_Dex; }
    public int IQ() { return Base_IQ + Mod_IQ; }
    public int Wisdom() { return Base_Wis + Mod_Wis; }
    public int Charm() { return Base_Chrm + Mod_Chrm; }
    public int Health() { return Base_Health + Mod_Health; }
    public int HP() { return hp; }
    public int maxHP() { return maxHp; }
    public float HpPercent() { return (maxHp - hp) / maxHp; }
    public int XP() { return xp; }
    public int XP_NNL() { return xpNNL; }
    public float XP_Percent() { return (xpNNL - xp) / xpNNL; }
    public int Attack() { return attk_base + attk_mod; }
    public int Armor() { return armorClass_base + armorClass_mod; }
        
}
