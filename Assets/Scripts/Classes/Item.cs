using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlobberEngine;

public class Item 
{
    public ItemBase itemBase;
    public bool identified;
    public int currentDurability, currentCharges;
    public int IconOverride;

    public Item(ItemBase _item)
    {
        itemBase = _item;
        identified = false;
        currentDurability = _item.itemMaxDurability;
        currentCharges = _item.itemMaxCharges;
        IconOverride = 0;
    }
    public Item(int _item)
    {
        itemBase = GameObject.FindObjectOfType<AssetManager>().FindItemInList(_item);
        identified = false;
        currentDurability = itemBase.itemMaxDurability;
        currentCharges = itemBase.itemMaxCharges;
        IconOverride = 0;
    }

    public string ItemName() { return identified ? itemBase.ID_Name : itemBase.itemName; }
    public string ItemDescription() { return identified ? itemBase.ID_Description : itemBase.itemDescription; }
    public bool IsMagical() { return itemBase.magical; }
    public int ItemType() { return itemBase.itemType; }
    public int ItemSlot() { return itemBase.itemSlot; }
    public float ItemValue() { return itemBase.itemValue; }
    public float ItemQuality() { return itemBase.itemQuality; } 
    public float Durability() { return (itemBase.itemMaxDurability - currentDurability) / itemBase.itemMaxDurability; }
    public float Charges() { return (itemBase.itemMaxCharges - currentCharges) / itemBase.itemMaxCharges; }
    public int WeaponDamage() 
    { 
        int result = itemBase.weaponDamageBonus + _tool.dice(itemBase.weaponDamageDiceNum, itemBase.weaponDamageDiceSides);
        result += identified ? itemBase.weaponDamageIdentifiedBonus : 0;
        return result; 
    }
    public int WeaponAttack()
    {
        int result = itemBase.weaponAttackBonus;
        result += identified ? itemBase.weaponAttackIdentifiedBonus : 0;
        return result;
    }
    public int ArmorDodge()
    {
        int result = itemBase.armorDodgeBonus;
        result += identified ? itemBase.armorIdendtifiedDodgeBonus : 0;
        return result;
    }
    public int ArmorBlock()
    {
        int result = itemBase.armorBlockBonus;
        result += identified ? itemBase.armorIdendtifiedBlockBonus : 0;
        return result;
    }
    public int IconIndex()
    {
        int result = (IconOverride > 0) ? IconOverride : itemBase.IconIndex;
        return result;
    }

    public int[] SaveItem()
    {
        int[] result = new int[5];
        result[0] = itemBase.ID;
        result[1] = (identified) ? 1 : 0;
        result[2] = currentDurability;
        result[3] = currentCharges;
        result[4] = IconOverride;
        return result;
    }

    public void LoadItem(int[] _item)
    {
        itemBase = GameObject.FindObjectOfType<AssetManager>().FindItemInList(_item[0]);
        identified = (_item[1] == 1) ? true : false;
        currentDurability = _item[2];
        currentCharges = _item[3];
        IconOverride = _item[4];
    }
}
