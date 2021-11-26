using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemBase")]
public class ItemBase : ScriptableObject
{
    public int ID;
    public string itemName, itemDescription, ID_Name, ID_Description;
    public bool magical;
    public int itemSlot, itemType, itemQuality, itemMaxDurability, itemMaxCharges;
    public float itemValue;
    public int weaponDamageBonus, weaponDamageDiceNum, weaponDamageDiceSides, weaponDamageIdentifiedBonus;
    public int weaponAttackBonus, weaponAttackIdentifiedBonus;
    public int armorDodgeBonus, armorBlockBonus, armorIdendtifiedDodgeBonus, armorIdendtifiedBlockBonus;
    public int IconIndex;
}
