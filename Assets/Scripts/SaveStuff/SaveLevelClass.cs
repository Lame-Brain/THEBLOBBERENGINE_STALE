using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveLevelClass // Tracks Chest inventory, Loot Inventory, and Monster locations in a level
{
    public List<SaveChestClass> chest = new List<SaveChestClass>();
    public List<SaveLootClass> loot = new List<SaveLootClass>();
    public List<SaveTrapClass> trap = new List<SaveTrapClass>();
    public List<SaveDoorClass> door = new List<SaveDoorClass>();
    public List<int> SpawnTimer = new List<int>();
}
