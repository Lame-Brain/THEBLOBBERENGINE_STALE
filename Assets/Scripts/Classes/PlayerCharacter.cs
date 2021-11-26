using System.Collections.Generic;
using UnityEngine;
using BlobberEngine;

public class PlayerCharacter
{    
    public string pcName;
    public _enum.CharacterClass pcClass;

    //Stats
    private int Base_Str;
    private int Base_Dex;
    private int Base_IQ;
    private int Base_Wis;
    private int Base_Chrm;
    private int Base_Health;
    //health
    private int hp, maxHp;
    //xp
    private int xp, xpNNL;
    //attack
    private int Base_Attk;
    //defense
    private int Base_Block;
    private int Base_Dodge;
    //saves
    private float Base_Reflex;
    private float Base_Fortitude;
    private float Base_Willpower; 

    public int initBonus;
    public List<CharacterCondition> condition = new List<CharacterCondition>();

    //mods
    public int Mod_Str;
    public int Mod_Dex;
    public int Mod_IQ;
    public int Mod_Wis;
    public int Mod_Chrm;
    public int Mod_Health;
    public int Mod_maxHp;
    public int Drain_xp;
    public int Mod_Attk;
    public int Mod_Block;
    public int Mod_Dodge;
    public float Mod_Reflex;
    public float Mod_Fortitude;
    public float Mod_Willpower;

    //Equipment
    public Item head_EQ;
    public Item neck_EQ;
    public Item armor_EQ;
    public Item wrists_EQ;
    public Item ring1_EQ;
    public Item ring2_EQ;
    public Item waist_EQ;
    public Item feet_EQ;
    public Item weapon_EQ;
    public Item shield_EQ;
    public Item[] bag_EQ = new Item[25];

    //Skills
    public List<string> SkillList = new List<string>();

    //Spells
    public Spell[,] KnownSpells = new Spell[5,10]; //can know 5 spells of each level, 10 spell levels

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
    public float Reflex() { return Random.Range(0, (Base_Reflex + Mod_Reflex)); }
    public float Fortitude() { return Random.Range(0, (Base_Fortitude + Mod_Fortitude)); }
    public float Willpower() { return Random.Range(0, (Base_Willpower + Mod_Willpower)); }
        
    public SaveCharacter SaveCharacter()
    {
        SaveCharacter result = new SaveCharacter();
        result.PCname = pcName;
        result.PCclass = pcClass.ToString();
        result.Base_Str = Base_Str; result.Mod_Str = Mod_Str;
        result.Base_Dex = Base_Dex; result.Mod_Dex = Mod_Dex;
        result.Base_IQ = Base_IQ; result.Mod_IQ = Mod_IQ;
        result.Base_Wis = Base_Wis; result.Mod_Wis = Mod_Wis;
        result.Base_Chrm = Base_Chrm; result.Mod_Chrm = Mod_Chrm;
        result.Base_Health = Base_Health; result.Mod_Health = Mod_Health;
        result.hp = hp; result.maxHp = maxHp;
        result.xp = xp; result.xpNNL = xpNNL;
        result.Base_Attk = Base_Attk; result.Mod_Attk = Mod_Attk;
        result.Base_Block = Base_Block; result.Mod_Block = Base_Block;
        result.Base_Dodge = Base_Dodge; result.Mod_Dodge = Mod_Dodge;
        result.Base_Reflex = Base_Reflex; result.Mod_Reflex = Mod_Reflex;
        result.Base_Fortitude = Base_Fortitude; result.Mod_Fortitude = Mod_Fortitude;
        result.Base_Willpower = Base_Willpower; result.Mod_Willpower = Mod_Willpower;
        result.initBonus = initBonus;
        result.NumConditions = condition.Count;
        for (int _i = 0; _i < condition.Count; _i++) result.condition.Add(condition[_i].SaveCondition());
        int[] emptyitem = new int[5];
        result.head_EQ = (head_EQ != null) ? head_EQ.SaveItem() : emptyitem;
        result.neck_EQ = (neck_EQ != null) ? neck_EQ.SaveItem() : emptyitem;
        result.armor_EQ = (armor_EQ != null) ? armor_EQ.SaveItem() : emptyitem;
        result.wrists_EQ = (wrists_EQ != null) ? wrists_EQ.SaveItem() : emptyitem;
        result.ring1_EQ = (ring1_EQ != null) ? ring1_EQ.SaveItem() : emptyitem;
        result.ring2_EQ = (ring2_EQ != null) ? ring2_EQ.SaveItem() : emptyitem;
        result.feet_EQ = (feet_EQ != null) ? feet_EQ.SaveItem() : emptyitem;
        result.weapon_EQ = (weapon_EQ != null) ? weapon_EQ.SaveItem() : emptyitem;
        result.shield_EQ = (shield_EQ != null) ? shield_EQ.SaveItem() : emptyitem;
        for(int _i = 0; _i < 25; _i++)
        {
            int[] _item = (bag_EQ[_i] != null) ? bag_EQ[_i].SaveItem() : emptyitem;
            for (int _c = 0; _c < 3; _c++)
                result.BagItems[_c, _i] = _item[_c];            
        }
        for (int _y = 0; _y < 10; _y++)
            for (int _x = 0; _x < 5; _x++)
                result.KnownSpells[_x, _y] = (KnownSpells[_x, _y] != null) ? KnownSpells[_x, _y].spellInvoke : "";
        result.NumSkills = SkillList.Count;
        for (int _i = 0; _i < SkillList.Count; _i++) result.skilllist.Add(SkillList[_i]);
        return result;
    }
    public void LoadCharacter(SaveCharacter _pc)
    {
        this.pcName = _pc.PCname;
        this.pcClass = (_enum.CharacterClass)System.Enum.Parse(typeof(_enum.CharacterClass), _pc.PCclass);
        this.Base_Str = _pc.Base_Str; this.Mod_Str = _pc.Mod_Str;
        this.Base_Dex = _pc.Base_Dex; this.Mod_Dex = _pc.Mod_Dex;
        this.Base_IQ = _pc.Base_IQ; this.Mod_IQ = _pc.Mod_IQ;
        this.Base_Wis = _pc.Base_Wis; this.Mod_Wis = _pc.Mod_Wis;
        this.Base_Chrm = _pc.Base_Chrm; this.Mod_Chrm = _pc.Mod_Chrm;
        this.Base_Health = _pc.Base_Health; this.Mod_Health = _pc.Mod_Health;
        this.hp = _pc.hp; this.maxHp = _pc.maxHp; this.xp = _pc.xp; this.xpNNL = _pc.xpNNL;
        this.Base_Attk = _pc.Base_Attk; this.Mod_Attk = _pc.Mod_Attk;
        this.Base_Block = _pc.Base_Block; this.Mod_Block = _pc.Mod_Block;
        this.Base_Dodge = _pc.Base_Dodge; this.Mod_Dodge = _pc.Mod_Dodge;
        this.Base_Reflex = _pc.Base_Reflex; this.Mod_Reflex = _pc.Mod_Reflex;
        this.Base_Fortitude = _pc.Base_Fortitude; this.Mod_Fortitude = _pc.Mod_Fortitude;
        this.Base_Willpower = _pc.Base_Willpower; this.Mod_Willpower = _pc.Mod_Willpower;
        this.initBonus = _pc.initBonus;
        this.condition.Clear();
        CharacterCondition _cc = new CharacterCondition(0, 0, 0);
        for (int _i = 0; _i < _pc.NumConditions; _i++)
        {
            _cc.LoadCondition(_pc.condition[_i]);
            this.condition.Add(_cc);
        }
        this.head_EQ = new Item(_pc.head_EQ);
        this.neck_EQ = new Item(_pc.neck_EQ);
        this.armor_EQ = new Item(_pc.armor_EQ);
        this.wrists_EQ = new Item(_pc.wrists_EQ);
        this.ring1_EQ = new Item(_pc.ring1_EQ);
        this.ring2_EQ = new Item(_pc.ring2_EQ);
        this.waist_EQ = new Item(_pc.waist_EQ);
        this.feet_EQ = new Item(_pc.feet_EQ);
        this.weapon_EQ = new Item(_pc.weapon_EQ);
        this.shield_EQ = new Item(_pc.shield_EQ);
        int[] _ti = new int[5];
        for (int _y = 0; _y < 25; _y++)
        {
            for (int _x = 0; _x < 5; _x++)
                _ti[_x] = _pc.BagItems[_x, _y];
            this.bag_EQ[_y] = new Item(_ti);
        }
        for (int _y = 0; _y < 10; _y++)
            for (int _x = 0; _x < 5; _x++)
                this.KnownSpells[_x, _y] = GameObject.FindObjectOfType<AssetManager>().FindSpellInList(_pc.KnownSpells[_x, _y]);
        this.SkillList.Clear();
        for (int _i = 0; _i < _pc.NumSkills; _i++)
            this.SkillList.Add(_pc.skilllist[_i]);
    }
}
