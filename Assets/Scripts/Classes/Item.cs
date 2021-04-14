using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public enum Type { misc, head, neck, ring, simple_weapon, sword, axe, mace, light_armor, medium_armor, heavy_armor, shield, light_source }
    public enum Slot { general, head, neck, finger, hand, torso, leg, foot }
    public string itm_Name, itm_Desc, itm_FullName, itm_Lore;
    public bool itm_Magical, itm_Cursed;
    public Type itm_Type;
    public Slot itm_Slot;
    public float itm_Value;
    public int itm_Quality, itm_AttackBonus, itm_MinDamage, itm_MaxDamage, itm_DefenseBonus, itm_MaxCharges, itm_MaxFuel, itm_Icon;
    public int itm_ID_Quality, itm_ID_AttackBonus, itm_ID_Damage, itm_ID_Defense, itm_ID_Charges; //these are the modifiers for how the item changes if it is IDd

    public bool itm_ID, itm_Active;
    public int itm_CurrentCharges, itm_CurrentFuel;

    public int GetAttack() //<---- AttackBonus may be modified if the item is identified
    {
        int _result = _result = this.itm_AttackBonus;
        if (this.itm_ID) _result += this.itm_ID_AttackBonus;
        return _result;
    }
    public int GetDamage() //<---- Damage may be modified if the item is identified
    {
        int _result = _result = Random.Range(this.itm_MinDamage, this.itm_MaxDamage);
        if (this.itm_ID) _result += this.itm_ID_Damage;
        return _result;
    }
    public int GetDefense() //<---- Defense bonus is modified if the item is identified
    {
        int _result = this.itm_DefenseBonus;
        if (this.itm_ID) _result += this.itm_ID_Defense;
        return _result;
    }
    public string GetName() //<------ The name displayed is different if the item is identified
    {
        string _result = _result = this.itm_Name;
        if (this.itm_ID) _result = this.itm_FullName;
        return _result;
    }
    public string GetInfo() // <----- The description of the item is different if the item is identified
    {
        string _result = _result = this.itm_Desc;
        if (this.itm_ID) _result = this.itm_Lore;
        return _result;
    }
    public bool HasCharges() //<---- The number of charges of an item may change when it is identified
    {
        bool _result = (this.itm_CurrentCharges > this.itm_MaxCharges);
        if(this.itm_ID) _result = (this.itm_CurrentCharges > (this.itm_MaxCharges)+this.itm_ID_Charges);
        return _result;
    }

    public float GetMinDamage()
    {
        float _result = 0;
        _result = this.itm_MinDamage;
        if(this.itm_ID) _result += this.itm_ID_Damage;
        return _result;
    }
    public float GetMaxDamage()
    {
        float _result = 0;
        _result  = this.itm_MaxDamage;
        if (this.itm_ID) _result += this.itm_ID_Damage;
        return _result;
    }

    public void UseItem()
    {
        if(this.itm_Type == Item.Type.light_source)
        {
            this.itm_Active = !this.itm_Active; //toggles active
            if(this.itm_Active) //When a lightsource is active, it uses an icon that is one higher in the icon array than when it is inactive. This way active lightsources appear different in the inventory.
            {
                this.itm_Icon++;
            }
            else  //When a lightsource is inactive, it uses an icon that is one higher in the icon array than when it is inactive. This way active lightsources appear different in the inventory.
            {
                this.itm_Icon--;
            }
        }
        if (HasCharges())
        {
            this.itm_CurrentCharges--;
            //TO DO: Implement effect code
        }
        if (itm_CurrentFuel > 0)
        {
            this.itm_CurrentFuel--;
        }
    }
}
