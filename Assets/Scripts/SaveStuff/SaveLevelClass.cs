using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveLevelClass
{
    // tracks the Chests and node loot in a level... also probably monsters, but I am not there yet
    public List<SaveChestClass> Chest = new List<SaveChestClass>();
    public List<SaveLootClass> Loot = new List<SaveLootClass>();

}
