using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveChestClass
{
    public SaveItemClass[] inventory = new SaveItemClass[16];

    public SaveChestClass(Item[] i)
    {
        for (int _i = 0; _i < 16; _i++)
        {
            if(i[_i] != null) inventory[_i] = new SaveItemClass(i[_i]);
            if (i[_i] == null) inventory[_i] = null;
        }
    }

    public Item[] LoadChestInventory(SaveItemClass[] i)
    {
        Item[] _result = new Item[16];

        for (int _i = 0; _i < 16; _i++)
        {
            if (inventory[_i] != null) _result[_i] = inventory[_i].LoadItem(inventory[_i]);
            if (inventory[_i] == null) _result[_i] = null;
        }

        return _result;
    }
}
