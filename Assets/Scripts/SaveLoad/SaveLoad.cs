using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    public static SaveSlot[] saveSlot = new SaveSlot[5];
    public static int selectedSaveSlot;
}

/*Things to save
 * PC Name
 * PC Class
 * PC Level
 * PC XP
 * PC XP_NNL
 * PC Strength
 * PC Dexterity
 * PC Intelligence
 * PC Wisdom
 * PC Charisma
 * PC Health
 * PC Wounds
 * PC Mana
 * PC Drain
 * PC Defense
 * PC Attack
 * PC Portrait
 * PC head
 * PC neck
 * PC left finger
 * PC right finger
 * PC left hand
 * PC right hand
 * PC legs
 * PC feet 
 * (x4)
 * Party Wealth
 * Party Light
 * Party Inventory
 * Array of Node Inventory by level
 * Array of Treasure Chest Inventory by level
 * Monster Name
 * Monster Level
 * Monster Health
 * Monster Wounds
 * Monster Defense
 * Monster Attack
 * Monster Portrait
 * Monster Left Hand
 * Monster Right Hand
 * (repeat for each monster on current level)
 * (repeat for each boss that is still active)
 */
