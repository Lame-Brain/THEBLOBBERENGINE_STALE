using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character : ScriptableObject
{
    public enum Class { Unassigned, Fighter, Rogue, Mage, Cleric }
    public string pc_Name;
    public Class pc_Class;
    public int pc_PortraintIndex;
    public float pc_HP, pc_Max_HP, pc_MP, pc_Max_MP;
    public int pc_XP_Level, pc_XP, pc_XP_NNL; //NNL stands for NEEDED NEXT LEVEL
    public int pc_Base_Str, pc_Base_Dex, pc_Base_IQ, pc_Base_Wis, pc_Base_Charm, pc_Base_Health; //Stats are listed as Base and Mod. I will have get functions for these that will combine them for use in the game
    public int pc_Str_Mod, pc_Dex_Mod, pc_IQ_Mod, pc_Wis_Mod, pc_Charm_Mod, pc_Health_Mod;
    public List<string> skills = new List<string>(); //<--- Get function searches for if a particular function exists. this is cool!
    public Item eq_Head, eq_Neck, eq_LeftFinger, eq_RightFinger, eq_LeftHand, eq_RightHand, eq_Torso, eq_Legs, eq_Feet; //Equipment slots
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

    //No instance, I want Player Characters to be unique.
    public void LoadCharacter(string _name, Class _class, int _portrait, int str, int dex, int iq, int wis, int charm, int hlth)
    {
        this.pc_Name = _name; this.pc_Class = _class; this.pc_PortraintIndex = _portrait;
        this.pc_XP_Level = 0; this.pc_XP = 0; this.pc_XP_NNL = 475; //as you level up, XP_NNL is calculated like this: nnl += (level * 475);                                                                                       

        //Set Stats
        this.pc_Base_Str = str; this.pc_Base_Dex = dex; this.pc_Base_IQ = iq; this.pc_Base_Wis = wis; this.pc_Base_Charm = charm; this.pc_Base_Health = hlth;

        //Set Skills
        if(_class == Class.Fighter) //Fighters Start with weapon and armor skills, Iron Fortitude, Forceful Striking, Stalwart Defender
        {
            this.skills.Add("Light_Armor");
            this.skills.Add("Medium_Armor");
            this.skills.Add("Heavy_Armor");
            this.skills.Add("Sword_Training");
            this.skills.Add("Axe_Training");
            this.skills.Add("Mace_Training");
            this.skills.Add("Iron_Fortitude"); //+4 max HP
            this.skills.Add("Forceful_Striking"); //use STR when attacking
            this.skills.Add("Stalwart_Defender"); //+1 Defense when Frontline
        }
        if(_class == Class.Rogue) 
        {
            this.skills.Add("Hardy_Fortitude"); //+2 max hp
            this.skills.Add("Disarm_Trap");
            this.skills.Add("Pick_Lock");
            this.skills.Add("Light_Armor");
            this.skills.Add("Sword_Training");
            this.skills.Add("Nimble_Dodger"); //Use DEX for defense
            this.skills.Add("Sneaky"); //Defense bonus when not Frontline
            this.skills.Add("Crititcal_Attacker"); //Does critical attacks
            this.skills.Add("Preciscion_Striker"); // uses DEX for attacks

        }
        if (_class == Class.Cleric) 
        {
            this.skills.Add("Divine_Favor");
            this.skills.Add("Light_Armor");
            this.skills.Add("Medium_Armor");
            this.skills.Add("Heavy_Armor");
            this.skills.Add("Mace_Training");
            this.skills.Add("Iron_Fortitude");
            this.skills.Add("Sense_Curses");
        }
        if (_class == Class.Mage)
        {
            this.skills.Add("Sense_Magic");
            this.skills.Add("Arcane_Focus");
            this.skills.Add("Lore");
        }

        //Set Items
        this.eq_Head = null;
        this.eq_Neck = null;
        this.eq_LeftFinger = null;
        this.eq_RightFinger = null;
        this.eq_LeftHand = null;
        this.eq_RightHand = null;
        this.eq_Torso = null;
        this.eq_Legs = null;
        this.eq_Feet = null;

        //Set conditions
        this.isDead = false; 
        this.con_Bless = false; 
        this.con_Curse = false;
        this.con_Regen = false;
        this.con_Poison = false;
        this.con_Haste = false;
        this.con_Slow = false;
        this.con_Sevrd = false;
        this.con_Stone = false;
        this.con_Frog = false;
        this.con_Shield = false;
        this.con_Weak = false;
        this.con_StrDisease = false;
        this.con_DexDisease = false;
        this.con_IQDisease = false;
        this.con_WisDisease = false;
        this.con_CharmDisease = false;
        this.con_HealthDisease = false;

        //Set Derived Stats
        this.pc_Max_HP = 0; this.pc_MP = 0;
        LevelUp();
    }

    public int STR()
    {
        int _result = this.pc_Base_Str + this.pc_Str_Mod;
        if (_result < 1) _result = 1;
        if (_result > 25) _result = 25;
        return _result;
    }
    public int DEX()
    {
        int _result = this.pc_Base_Dex + this.pc_Dex_Mod;
        if (_result < 1) _result = 1;
        if (_result > 25) _result = 25;
        return _result;
    }
    public int IQ()
    {
        int _result = this.pc_Base_IQ + this.pc_IQ_Mod;
        if (_result < 1) _result = 1;
        if (_result > 25) _result = 25;
        return _result;
    }
    public int WIS()
    {
        int _result = this.pc_Base_Wis + this.pc_Wis_Mod;
        if (_result < 1) _result = 1;
        if (_result > 25) _result = 25;
        return _result;
    }
    public int CHARM()
    {
        int _result = this.pc_Base_Charm + this.pc_Charm_Mod;
        if (_result < 1) _result = 1;
        if (_result > 25) _result = 25;
        return _result;
    }
    public int HEALTH()
    {
        int _result = this.pc_Base_Health + this.pc_Health_Mod;
        if (_result < 1) _result = 1;
        if (_result > 25) _result = 25;
        return _result;
    }
    public bool CanAct()
    {
        bool _result = true;
        if (this.isDead ||  this.con_Paralyzed || this.con_Stone || this.con_Frog) _result = false; //Dead people cannot act. Paralyzed people cannot act. Statues cannot act. Frogs cannot do anything meaningful. Sad but true.
        return _result;
    }
    public void LevelUp()//PROTIP: Lean on those Health, IQ, and WIS bonus potions before leveling up for extra rewards!
    {
        this.pc_Max_HP += 6; //Base 6 max hp per level
        if (this.skills.Contains("Savage_Fortitude")) this.pc_Max_HP += 6;
        if (this.skills.Contains("Iron_Fortitude")) this.pc_Max_HP += 4;
        if (this.skills.Contains("Hardy_Fortitude")) this.pc_Max_HP += 2;
        if (this.skills.Contains("Arcane_Focus")) this.pc_Max_HP -= 2;

        this.pc_Max_MP += 0;
        if (this.skills.Contains("Arcane_Spark")) this.pc_Max_MP += (int)(this.IQ() / 2) - 5;
        if (this.skills.Contains("Arcane_Focus")) this.pc_Max_MP += ((int)(this.IQ() / 2) - 5) * 2;
        if (this.skills.Contains("Divine_Faith")) this.pc_Max_MP += (int)((int)(this.WIS() / 2) - 5) / 2;
        if (this.skills.Contains("Divine_Favor")) this.pc_Max_MP += (int)(this.WIS() / 2) - 5;

        if (this.pc_HP < (int)(this.pc_Max_HP / 2)) this.pc_HP = (int)(this.pc_Max_HP / 2); //Restore HP and MP up to half their max when gaining a level.
        if (this.pc_MP < (int)(this.pc_Max_MP / 2)) this.pc_MP = (int)(this.pc_Max_MP / 2); //after all, I'm not a monster.

        this.pc_XP -= this.pc_XP_NNL;
        this.pc_XP_NNL += this.pc_XP_Level * 475; //<----- Later I will change this to a reference in the RULE document, that way level progression can be easily adjusted.
        this.pc_XP_Level++;
    }

    public void LoadCharacter(SaveCharacterClass _scc)
    {
        this.pc_Name = _scc.pc_Name;
        this.pc_Class = _scc.pc_Class;
        this.pc_PortraintIndex = _scc.pc_PortraintIndex;
        this.pc_HP = _scc.pc_HP; this.pc_Max_HP = _scc.pc_Max_HP; this.pc_MP = _scc.pc_MP; this.pc_Max_MP = _scc.pc_Max_MP;
        this.pc_XP_Level = _scc.pc_XP_Level; this.pc_XP = _scc.pc_XP; this.pc_XP_NNL = _scc.pc_XP_NNL;
        this.pc_Base_Str = _scc.pc_Base_Str; this.pc_Base_Dex = _scc.pc_Base_Dex; this.pc_Base_IQ = _scc.pc_Base_IQ; this.pc_Base_Wis = _scc.pc_Base_Wis; this.pc_Base_Charm = _scc.pc_Base_Charm; this.pc_Base_Health = _scc.pc_Base_Health;
        this.pc_Str_Mod = _scc.pc_Str_Mod; this.pc_Dex_Mod = _scc.pc_Dex_Mod; this.pc_IQ_Mod = _scc.pc_IQ_Mod; this.pc_Wis_Mod = _scc.pc_Wis_Mod; this.pc_Charm_Mod = _scc.pc_Charm_Mod; this.pc_Health_Mod = _scc.pc_Health_Mod;
        this.skills = _scc.skills;
        //this.eq_Head = _scc.eq_Head; eq_Neck, eq_LeftFinger, eq_RightFinger, eq_LeftHand, eq_RightHand, eq_Torso, eq_Legs, eq_Feet; //Equipment slots
        if (_scc.eq_Head != null) this.eq_Head.LoadItem(_scc.eq_Head);
        if (_scc.eq_Neck != null) this.eq_Neck.LoadItem(_scc.eq_Neck);
        if (_scc.eq_LeftFinger != null) this.eq_LeftFinger.LoadItem(_scc.eq_LeftFinger);
        if (_scc.eq_RightFinger != null) this.eq_RightFinger.LoadItem(_scc.eq_RightFinger);
        if (_scc.eq_LeftHand != null) this.eq_LeftHand.LoadItem(_scc.eq_LeftHand);
        if (_scc.eq_RightHand != null) this.eq_RightHand.LoadItem(_scc.eq_RightHand);
        if (_scc.eq_Torso != null) this.eq_Torso.LoadItem(_scc.eq_Torso);
        if (_scc.eq_Legs != null) this.eq_Legs.LoadItem(_scc.eq_Legs);
        if (_scc.eq_Feet != null) this.eq_Feet.LoadItem(_scc.eq_Feet);
        this.pc_Defense = _scc.pc_Defense; this.pc_Attack = _scc.pc_Attack;
        this.isDead = _scc.isDead; //oof!
        this.con_Bless = _scc.con_Bless;  this.tmr_Bless = _scc.tmr_Bless; 
        this.con_Curse = _scc.con_Curse;  this.tmr_Curse = _scc.tmr_Curse; 
        this.con_Regen = _scc.con_Regen;  this.tmr_Regen = _scc.tmr_Regen; this.val_Regen = _scc.val_Regen;
        this.con_Poison = _scc.con_Poison;  this.tmr_Poison = _scc.tmr_Poison; this.val_Poison = _scc.val_Poison;
        this.con_Haste = _scc.con_Haste;  this.tmr_Haste = _scc.tmr_Haste; this.val_Haste = _scc.val_Haste; 
        this.con_Slow = _scc.con_Slow;  this.tmr_Slow = _scc.tmr_Slow; this.val_Slow = _scc.val_Slow; 
        this.con_Sevrd = _scc.con_Sevrd;  this.tmr_Sevrd = _scc.tmr_Sevrd; 
        this.con_Paralyzed = _scc.con_Paralyzed;  this.tmr_Paralyzed = _scc.tmr_Paralyzed; 
        this.con_Stone = _scc.con_Stone;  this.tmr_Stone = _scc.tmr_Stone; 
        this.con_Frog = _scc.con_Frog;  this.tmr_Frog = _scc.tmr_Frog;
        this.con_Shield = _scc.con_Shield;  this.tmr_Shield = _scc.tmr_Shield; this.val_Shield = _scc.val_Shield;
        this.con_Weak = _scc.con_Weak;  this.tmr_Weak = _scc.tmr_Weak; this.val_Weak = _scc.val_Weak; 
        this.con_StrDisease = _scc.con_StrDisease;  this.tmr_StrDisease = _scc.tmr_StrDisease; this.val_StrDisease = _scc.val_StrDisease; 
        this.con_DexDisease = _scc.con_DexDisease;  this.tmr_DexDisease = _scc.tmr_DexDisease; this.val_DexDisease = _scc.val_DexDisease;
        this.con_IQDisease = _scc.con_IQDisease;  this.tmr_IQDisease = _scc.tmr_IQDisease; this.val_IQDisease = _scc.val_IQDisease;
        this.con_WisDisease = _scc.con_WisDisease;  this.tmr_WisDisease = _scc.tmr_WisDisease; this.val_WisDisease = _scc.val_WisDisease;
        this.con_CharmDisease = _scc.con_CharmDisease;  this.tmr_CharmDisease = _scc.tmr_CharmDisease; this.val_CharmDisease = _scc.val_CharmDisease;
        this.con_HealthDisease = _scc.con_HealthDisease;  this.tmr_HealthDisease = _scc.tmr_HealthDisease; this.val_HealthDisease = _scc.val_HealthDisease;
    }
}
