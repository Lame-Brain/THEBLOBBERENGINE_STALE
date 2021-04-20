using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveCharacterClass
{    
    public string pc_Name;
    public Character.Class pc_Class;
    public int pc_PortraintIndex;
    public float pc_HP, pc_Max_HP, pc_MP, pc_Max_MP;
    public int pc_XP_Level, pc_XP, pc_XP_NNL; //NNL stands for NEEDED NEXT LEVEL
    public int pc_Base_Str, pc_Base_Dex, pc_Base_IQ, pc_Base_Wis, pc_Base_Charm, pc_Base_Health; //Stats are listed as Base and Mod. I will have get functions for these that will combine them for use in the game
    public int pc_Str_Mod, pc_Dex_Mod, pc_IQ_Mod, pc_Wis_Mod, pc_Charm_Mod, pc_Health_Mod;
    public List<string> skills = new List<string>(); //<--- Get function searches for if a particular function exists. this is cool!
    public SaveItemClass eq_Head, eq_Neck, eq_LeftFinger, eq_RightFinger, eq_LeftHand, eq_RightHand, eq_Torso, eq_Legs, eq_Feet; //Equipment slots
    public int pc_Defense, pc_Attack;
    public bool isDead; //oof!
    public bool con_Bless; public int tmr_Bless; //Bless increases attack and damage by 50%
    public bool con_Curse; public int tmr_Curse; //Curse reduces your attack and damage by 50%
    public bool con_Regen; public int tmr_Regen, val_Regen; //Regen increases health every turn (by val_Regen)
    public bool con_Poison; public int tmr_Poison, val_Poison;  //Poison reduces health every turn (by val_Poison) I included a tmr_Poison here, but current design is to not have it wear off.
    public bool con_Haste; public int tmr_Haste, val_Haste; //Hasted characters get two turns a round in battle.
    public bool con_Slow; public int tmr_Slow, val_Slow; //slow characters get a massive penalty to initiative in battle.
    public bool con_Sevrd; public int tmr_Sevrd; //Mana-Severed. Cannot regerate mana, even with the use of potions. Sucks for magic users.
    public bool con_Paralyzed; public int tmr_Paralyzed; //Stone-Form. Shouldn't have looked that Gorgon in the eye! Basically dead but does not clear with ressurect. It is better-dead. has a tmr_Stone variable, but I do not currently plan to use it.
    public bool con_Stone; public int tmr_Stone; //Stone-Form. Shouldn't have looked that Gorgon in the eye! Basically dead but does not clear with ressurect. It is better-dead. has a tmr_Stone variable, but I do not currently plan to use it.
    public bool con_Frog; public int tmr_Frog; //You have been turned into a toad! not sure if this will go in or not.
    public bool con_Shield; public int tmr_Shield, val_Shield; //Magical Shield absorbs val_Shield points of damage. 
    public bool con_Weak; public int tmr_Weak, val_Weak; //Weakness makes you easier to hit. Lowers Defense by val_Weak amount.
    public bool con_StrDisease; public int tmr_StrDisease, val_StrDisease; //Disease wastes the associated stat by val_XXXDisease amount. This is added to the stat mod
    public bool con_DexDisease; public int tmr_DexDisease, val_DexDisease;
    public bool con_IQDisease; public int tmr_IQDisease, val_IQDisease;
    public bool con_WisDisease; public int tmr_WisDisease, val_WisDisease;
    public bool con_CharmDisease; public int tmr_CharmDisease, val_CharmDisease;
    public bool con_HealthDisease; public int tmr_HealthDisease, val_HealthDisease;

    public SaveCharacterClass(Character c)
    {
        this.pc_Name = c.pc_Name;
        this.pc_Class = c.pc_Class;
        this.pc_PortraintIndex = c.pc_PortraintIndex;
        this.pc_HP = c.pc_HP; this.pc_Max_HP = c.pc_Max_HP; this.pc_MP = c.pc_MP; this.pc_Max_MP = c.pc_Max_MP;
        this.pc_XP_Level = c.pc_XP_Level; this.pc_XP = c.pc_XP; this.pc_XP_NNL = c.pc_XP_NNL;
        this.pc_Base_Str = c.pc_Base_Str; this.pc_Str_Mod = c.pc_Str_Mod;
        this.pc_Base_Dex = c.pc_Base_Dex; this.pc_Dex_Mod = c.pc_Dex_Mod;
        this.pc_Base_IQ = c.pc_Base_IQ; this.pc_IQ_Mod = c.pc_IQ_Mod;
        this.pc_Base_Wis = c.pc_Base_Wis; this.pc_Wis_Mod = c.pc_Wis_Mod;
        this.pc_Base_Charm = c.pc_Base_Charm; this.pc_Charm_Mod = c.pc_Charm_Mod;
        this.pc_Base_Health = c.pc_Base_Health; this.pc_Health_Mod = c.pc_Health_Mod;
        this.skills = c.skills;
        this.pc_Defense = c.pc_Defense; this.pc_Attack = c.pc_Attack;
        this.isDead = c.isDead;
        this.con_Bless = c.con_Bless; this.tmr_Bless = c.tmr_Bless;
        this.con_Curse = c.con_Curse; this.tmr_Curse = c.tmr_Curse;
        this.con_Regen = c.con_Regen; this.tmr_Regen = c.tmr_Regen; this.val_Regen = c.val_Regen;
        this.con_Poison = c.con_Poison; this.tmr_Poison = c.tmr_Poison; this.val_Poison = c.val_Poison;
        this.con_Haste = c.con_Haste; this.tmr_Haste = c.val_Haste;
        this.con_Slow = c.con_Slow; this.tmr_Slow = c.tmr_Slow; this.val_Slow = c.val_Slow;
        this.con_Sevrd = c.con_Sevrd; this.tmr_Sevrd = c.tmr_Sevrd;
        this.con_Paralyzed = c.con_Paralyzed; this.tmr_Paralyzed = c.tmr_Paralyzed;
        this.con_Stone = c.con_Stone; this.tmr_Stone = c.tmr_Stone;
        this.con_Frog = c.con_Frog; this.tmr_Frog = c.tmr_Frog;
        this.con_Shield = c.con_Shield; this.tmr_Shield = c.tmr_Shield; this.val_Shield = c.val_Shield;
        this.con_Weak = c.con_Weak; this.tmr_Weak = c.tmr_Weak; this.val_Weak = c.val_Weak;
        this.con_StrDisease = c.con_StrDisease; this.tmr_StrDisease = c.tmr_StrDisease; this.val_StrDisease = c.val_StrDisease;
        this.con_DexDisease = c.con_DexDisease; this.tmr_DexDisease = c.tmr_DexDisease; this.val_DexDisease = c.val_DexDisease;
        this.con_IQDisease = c.con_IQDisease; this.tmr_IQDisease = c.tmr_IQDisease; this.val_IQDisease = c.val_IQDisease;
        this.con_WisDisease = c.con_WisDisease; this.tmr_WisDisease = c.tmr_WisDisease; this.val_WisDisease = c.val_WisDisease;
        this.con_CharmDisease = c.con_CharmDisease; this.tmr_CharmDisease = c.tmr_CharmDisease; this.val_CharmDisease = c.val_CharmDisease;
        this.con_HealthDisease = c.con_HealthDisease; this.tmr_HealthDisease = c.tmr_HealthDisease; this.val_HealthDisease = c.val_HealthDisease;

        if (c.eq_Head != null) this.eq_Head = new SaveItemClass(c.eq_Head);
        if (c.eq_Neck != null) this.eq_Neck = new SaveItemClass(c.eq_Neck);
        if (c.eq_LeftFinger != null) this.eq_LeftFinger = new SaveItemClass(c.eq_LeftFinger);
        if (c.eq_RightFinger != null) this.eq_RightFinger = new SaveItemClass(c.eq_RightFinger);
        if (c.eq_LeftHand != null) this.eq_LeftHand = new SaveItemClass(c.eq_LeftHand);
        if (c.eq_RightHand != null) this.eq_RightHand = new SaveItemClass(c.eq_RightHand);
        if (c.eq_Torso != null) this.eq_Torso = new SaveItemClass(c.eq_Torso);
        if (c.eq_Legs != null) this.eq_Legs = new SaveItemClass(c.eq_Legs);
        if (c.eq_Feet != null) this.eq_Feet = new SaveItemClass(c.eq_Feet);
    }

    public Character LoadCharacter(SaveCharacterClass toon)
    {
        Character _result = ScriptableObject.CreateInstance<Character>();

        _result.name = toon.pc_Name + "_charcter";
        _result.pc_Name = toon.pc_Name;
        _result.pc_Class = toon.pc_Class;
        _result.pc_PortraintIndex = toon.pc_PortraintIndex;
        _result.pc_HP = toon.pc_HP;
        _result.pc_Max_HP = toon.pc_Max_HP;
        _result.pc_MP = toon.pc_MP;
        _result.pc_Max_MP = toon.pc_Max_MP;
        _result.pc_XP_Level = toon.pc_XP_Level;
        _result.pc_XP = toon.pc_XP;
        _result.pc_XP_NNL = toon.pc_XP_NNL;
        _result.pc_Base_Str = toon.pc_Base_Str;
        _result.pc_Str_Mod = toon.pc_Str_Mod;
        _result.pc_Base_Dex = toon.pc_Base_Dex;
        _result.pc_Dex_Mod = toon.pc_Dex_Mod;
        _result.pc_Base_IQ = toon.pc_Base_IQ;
        _result.pc_IQ_Mod = toon.pc_IQ_Mod;
        _result.pc_Base_Wis = toon.pc_Base_Wis;
        _result.pc_Wis_Mod = toon.pc_Wis_Mod;
        _result.pc_Base_Charm = toon.pc_Base_Charm;
        _result.pc_Charm_Mod = toon.pc_Charm_Mod;
        _result.pc_Base_Health = toon.pc_Base_Health;
        _result.pc_Health_Mod = toon.pc_Health_Mod;
        _result.skills = toon.skills;
        _result.pc_Defense = toon.pc_Defense;
        _result.pc_Attack = toon.pc_Attack;

        _result.isDead = toon.isDead;
        _result.con_Bless = toon.con_Bless; _result.tmr_Bless = toon.tmr_Bless;
        _result.con_Curse = toon.con_Curse; _result.tmr_Curse = toon.tmr_Curse;
        _result.con_Regen = toon.con_Regen; _result.tmr_Regen = toon.tmr_Regen; _result.val_Regen = toon.val_Regen;
        _result.con_Poison = toon.con_Poison; _result.tmr_Poison = toon.tmr_Poison; _result.val_Poison = toon.val_Poison;
        _result.con_Haste = toon.con_Haste; _result.tmr_Haste = toon.val_Haste;
        _result.con_Slow = toon.con_Slow; _result.tmr_Slow = toon.tmr_Slow; _result.val_Slow = toon.val_Slow;
        _result.con_Sevrd = toon.con_Sevrd; _result.tmr_Sevrd = toon.tmr_Sevrd;
        _result.con_Paralyzed = toon.con_Paralyzed; _result.tmr_Paralyzed = toon.tmr_Paralyzed;
        _result.con_Stone = toon.con_Stone; _result.tmr_Stone = toon.tmr_Stone;
        _result.con_Frog = toon.con_Frog; _result.tmr_Frog = toon.tmr_Frog;
        _result.con_Shield = toon.con_Shield; _result.tmr_Shield = toon.tmr_Shield; _result.val_Shield = toon.val_Shield;
        _result.con_Weak = toon.con_Weak; _result.tmr_Weak = toon.tmr_Weak; _result.val_Weak = toon.val_Weak;
        _result.con_StrDisease = toon.con_StrDisease; _result.tmr_StrDisease = toon.tmr_StrDisease; _result.val_StrDisease = toon.val_StrDisease;
        _result.con_DexDisease = toon.con_DexDisease; _result.tmr_DexDisease = toon.tmr_DexDisease; _result.val_DexDisease = toon.val_DexDisease;
        _result.con_IQDisease = toon.con_IQDisease; _result.tmr_IQDisease = toon.tmr_IQDisease; _result.val_IQDisease = toon.val_IQDisease;
        _result.con_WisDisease = toon.con_WisDisease; _result.tmr_WisDisease = toon.tmr_WisDisease; _result.val_WisDisease = toon.val_WisDisease;
        _result.con_CharmDisease = toon.con_CharmDisease; _result.tmr_CharmDisease = toon.tmr_CharmDisease; _result.val_CharmDisease = toon.val_CharmDisease;
        _result.con_HealthDisease = toon.con_HealthDisease; _result.tmr_HealthDisease = toon.tmr_HealthDisease; _result.val_HealthDisease = toon.val_HealthDisease;

        if (toon.eq_Head != null) _result.eq_Head = ScriptableObject.CreateInstance<Item>().LoadItem(toon.eq_Head);
        if (toon.eq_Head == null) _result.eq_Head = null;
        if (toon.eq_Neck != null) _result.eq_Neck = ScriptableObject.CreateInstance<Item>().LoadItem(toon.eq_Neck);
        if (toon.eq_Neck == null) _result.eq_Neck = null;
        if (toon.eq_LeftFinger != null) _result.eq_LeftFinger = ScriptableObject.CreateInstance<Item>().LoadItem(toon.eq_LeftFinger);
        if (toon.eq_LeftFinger == null) _result.eq_LeftFinger = null;
        if (toon.eq_RightFinger != null) _result.eq_RightFinger = ScriptableObject.CreateInstance<Item>().LoadItem(toon.eq_RightFinger);
        if (toon.eq_RightFinger == null) _result.eq_RightFinger = null;
        if (toon.eq_LeftHand != null) _result.eq_LeftHand = ScriptableObject.CreateInstance<Item>().LoadItem(toon.eq_LeftHand);
        if (toon.eq_LeftHand == null) _result.eq_LeftHand = null;
        if (toon.eq_RightHand != null) _result.eq_RightHand = ScriptableObject.CreateInstance<Item>().LoadItem(toon.eq_RightHand);
        if (toon.eq_RightHand == null) _result.eq_RightHand = null;
        if (toon.eq_Torso != null) _result.eq_Torso = ScriptableObject.CreateInstance<Item>().LoadItem(toon.eq_Torso);
        if (toon.eq_Torso == null) _result.eq_Torso = null;
        if (toon.eq_Legs != null) _result.eq_Legs = ScriptableObject.CreateInstance<Item>().LoadItem(toon.eq_Legs);
        if (toon.eq_Legs == null) _result.eq_Legs = null;
        if (toon.eq_Feet != null) _result.eq_Feet = ScriptableObject.CreateInstance<Item>().LoadItem(toon.eq_Feet);
        if (toon.eq_Feet == null) _result.eq_Feet = null;

        return _result;
    }
}
