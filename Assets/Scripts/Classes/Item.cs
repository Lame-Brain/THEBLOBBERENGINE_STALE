using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public enum Type { misc, head, neck, ring, weapon, armor, light_source }
    public enum Slot { general, head, neck, finger, hand, torso, leg, foot }
    public string itm_Name, itm_Desc, itm_FullName, itm_Lore;
    public bool itm_Magical;
    public Type itm_Type;
    public Slot itm_Slot;
    public float itm_Value;
    public int itm_Quality, itm_AttackBonus, itm_MinDamage, itm_MaxDamage, itm_DefenseBonus, itm_MaxCharges, itm_MaxFuel, itm_CurrentFuel, itm_Icon;
    public int itm_ID_Quality, itm_ID_AttackBonus, itm_ID_Damage, itm_ID_Defense, itm_ID_Charges; //these are the modifiers for how the item changes if it is IDd

    [System.Serializable]
    public class ItemInstance
    {
        private Item item;
        private bool itm_ID, itm_Active;
        private int itm_CurrentCharges, itm_CurrentFuel;
        
        public ItemInstance(Item _item) //<----- Item Instance defaults to unidentified, inactive, and fully charged
        {
            this.item = _item;
            this.itm_ID = false; this.itm_Active = false;
            this.itm_CurrentCharges = this.item.itm_MaxCharges + this.item.itm_ID_Charges;
            this.itm_CurrentFuel = this.item.itm_MaxFuel;   
        }

        public int GetAttack() //<---- AttackBonus may be modified if the item is identified
        {
            int _result = _result = this.item.itm_AttackBonus;
            if (this.itm_ID) _result += this.item.itm_ID_AttackBonus;
            return _result;
        }
        public int GetDamage() //<---- Damage may be modified if the item is identified
        {
            int _result = _result = Random.Range(this.item.itm_MinDamage, this.item.itm_MaxDamage);
            if (this.itm_ID) _result += this.item.itm_ID_Damage;
            return _result;
        }
        public int GetDefense() //<---- Defense bonus is modified if the item is identified
        {
            int _result = this.item.itm_DefenseBonus;
            if (this.itm_ID) _result += this.item.itm_ID_Defense;
            return _result;
        }
        public string GetName() //<------ The name displayed is different if the item is identified
        {
            string _result = _result = this.item.itm_Name;
            if (this.itm_ID) _result = this.item.itm_FullName;
            return _result;
        }
        public string GetInfo() // <----- The description of the item is different if the item is identified
        {
            string _result = _result = this.item.itm_Desc;
            if (this.itm_ID) _result = this.item.itm_Lore;
            return _result;
        }
        public bool HasCharges() //<---- The number of charges of an item may change when it is identified
        {
            bool _result = (this.itm_CurrentCharges > this.item.itm_MaxCharges);
            if(this.itm_ID) _result = (this.itm_CurrentCharges > (this.item.itm_MaxCharges)+this.item.itm_ID_Charges);
            return _result;
        }
        public bool HasFuel() { return (this.itm_CurrentFuel > 0); } //<----- Fuel does not change when identified
        public void ID_Item() { this.itm_ID = true; } //< Identify the item
        public void UseItem()
        {
            if(this.item.itm_Type == Item.Type.light_source)
            {
                this.itm_Active = !this.itm_Active; //toggles active
                if(this.itm_Active) //When a lightsource is active, it uses an icon that is one higher in the icon array than when it is inactive. This way active lightsources appear different in the inventory.
                {
                    this.item.itm_Icon++;
                }
                else  //When a lightsource is inactive, it uses an icon that is one higher in the icon array than when it is inactive. This way active lightsources appear different in the inventory.
                {
                    this.item.itm_Icon--;
                }
            }
            if (HasCharges())
            {
                this.itm_CurrentCharges--;
                //TO DO: Implement effect code
            }
            if (HasFuel())
            {
                this.itm_CurrentFuel--;
            }
        }
        
    }
}
