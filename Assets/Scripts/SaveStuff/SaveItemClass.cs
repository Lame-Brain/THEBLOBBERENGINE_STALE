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

    public SaveItemClass(Item.ItemInstance i)
    {
        this.itm_Name = i.Template().itm_Name;
        this.itm_Desc = i.Template().itm_Desc;
        this.itm_FullName = i.Template().itm_FullName;
        this.itm_Lore = i.Template().itm_Lore;
        this.itm_Type = i.Template().itm_Type;
        this.itm_Slot = i.Template().itm_Slot;
        this.itm_Value = i.Template().itm_Value;
        this.itm_Quality = i.Template().itm_Quality;
        this.itm_AttackBonus = i.Template().itm_AttackBonus;
        this.itm_ID_Damage = i.Template().itm_ID_Damage;
        this.itm_ID_Defense = i.Template().itm_ID_Defense;
        this.itm_ID_Charges = i.Template().itm_ID_Charges;
        this.itm_ID = i.IsIdentified();
        this.itm_Active = i.IsActive();
        this.itm_CurrentCharges = i.GetCharges();
        this.itm_CurrentFuel = i.GetFuel();
    }
}
/*

 */
