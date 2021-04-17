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
}
/*

 */
