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
    public List<SpawnChildren> Spawn = new List<SpawnChildren>();

    [System.Serializable]
    public class SpawnChildren
    {
        int Number_of_Children;
        List<SaveMobLogicClass> children = new List<SaveMobLogicClass>();

        public SpawnChildren(Spawner _tots)
        {
            this.Number_of_Children = _tots.transform.childCount;
            this.children.Clear();
            for (int _i = 0; _i < _tots.transform.childCount; _i++)
            {
                this.children.Add(new SaveMobLogicClass(_tots.transform.GetChild(_i).GetComponent<MobLogic>()));
                this.children[_i].xCoord = _tots.transform.GetChild(_i).transform.localPosition.x;
                this.children[_i].yCoord = _tots.transform.GetChild(_i).transform.localPosition.z;
                Debug.Log("position = " + this.children[_i].xCoord + ", " + this.children[_i].yCoord);
            }
        }

        public void InsertKiddo(int index, SaveMobLogicClass mob, float x, float y)
        {
            this.children[index].xCoord = x;
            this.children[index].yCoord = y;
            this.children[index] = mob;
            
        }

        public int GetKiddoNum()
        {
            return this.Number_of_Children;
        }

        public SaveMobLogicClass GetKiddoLogic(int n)
        {
            SaveMobLogicClass _result = null;
            if (children[n] != null) _result = children[n];
            return _result;
        }
    }
}
