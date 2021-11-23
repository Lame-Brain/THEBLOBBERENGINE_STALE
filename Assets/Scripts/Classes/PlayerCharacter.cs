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

    private float hp, maxHp;
    private float xp, xpNNL;

    public int Strength() { return Base_Str + Mod_Str; }
    public int Dexterity() { return Base_Dex + Mod_Dex; }
    public int IQ() { return Base_IQ + Mod_IQ; }
    public int Wisdom() { return Base_Wis + Mod_Wis; }
    public int Charm() { return Base_Chrm + Mod_Chrm; }
    public int Health() { return Base_Health + Mod_Health; }
        
}
