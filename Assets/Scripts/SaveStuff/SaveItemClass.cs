using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveItemClass
{
    public string itm_Name, itm_Desc, itm_FullName, itm_Lore;
    public bool itm_Magical, itm_Cursed;
    public Item.Type itm_Type;
    public Item.Slot itm_Slot;
    public float itm_Value;
    public int itm_Quality, itm_AttackBonus, itm_MinDamage, itm_MaxDamage, itm_DefenseBonus, itm_MaxCharges, itm_MaxFuel, itm_Icon;
    public int itm_ID_Quality, itm_ID_AttackBonus, itm_ID_Damage, itm_ID_Defense, itm_ID_Charges; //these are the modifiers for how the item changes if it is IDd
    public bool itm_ID, itm_Active;
    public int itm_CurrentCharges, itm_CurrentFuel;

    public SaveItemClass(Item i)
    {
        this.itm_Name = i.itm_Name;
        this.itm_Desc = i.itm_Desc;
        this.itm_FullName = i.itm_FullName;
        this.itm_Lore = i.itm_Lore;
        this.itm_Type = i.itm_Type;
        this.itm_Slot = i.itm_Slot;
        this.itm_Value = i.itm_Value;
        this.itm_Quality = i.itm_Quality;
        this.itm_AttackBonus = i.itm_AttackBonus;
        this.itm_MinDamage = i.itm_MinDamage;
        this.itm_MaxDamage = i.itm_MaxDamage;
        this.itm_DefenseBonus = i.itm_DefenseBonus;
        this.itm_MaxCharges = i.itm_MaxCharges;
        this.itm_MaxFuel = i.itm_MaxFuel;
        this.itm_Icon = i.itm_Icon;
        this.itm_ID_Quality = i.itm_ID_Quality;
        this.itm_ID_Damage = i.itm_ID_Damage;
        this.itm_ID_Defense = i.itm_ID_Defense;
        this.itm_ID_Charges = i.itm_ID_Charges;
        this.itm_ID = i.itm_ID;
        this.itm_Active = i.itm_Active;
        this.itm_CurrentCharges = i.itm_CurrentCharges;
        this.itm_CurrentFuel = i.itm_CurrentFuel;
    }

    public Item LoadItem(SaveItemClass i)
    {
        Item _result = null;

        _result.itm_Name = i.itm_Name;
        _result.itm_Desc = i.itm_Desc;
        _result.itm_FullName = i.itm_FullName;
        _result.itm_Lore = i.itm_Lore;
        _result.itm_Type = i.itm_Type;
        _result.itm_Slot = i.itm_Slot;
        _result.itm_Value = i.itm_Value;
        _result.itm_Quality = i.itm_Quality;
        _result.itm_AttackBonus = i.itm_AttackBonus;
        _result.itm_MinDamage = i.itm_MinDamage;
        _result.itm_MaxDamage = i.itm_MaxDamage;
        _result.itm_DefenseBonus = i.itm_DefenseBonus;
        _result.itm_MaxCharges = i.itm_MaxCharges;
        _result.itm_MaxFuel = i.itm_MaxFuel;
        _result.itm_Icon = i.itm_Icon;
        _result.itm_ID_Quality = i.itm_ID_Quality;
        _result.itm_ID_Damage = i.itm_ID_Damage;
        _result.itm_ID_Defense = i.itm_ID_Defense;
        _result.itm_ID_Charges = i.itm_ID_Charges;
        _result.itm_ID = i.itm_ID;
        _result.itm_Active = i.itm_Active;
        _result.itm_CurrentCharges = i.itm_CurrentCharges;
        _result.itm_CurrentFuel = i.itm_CurrentFuel;


        return _result;
    }
}
/*

 */
