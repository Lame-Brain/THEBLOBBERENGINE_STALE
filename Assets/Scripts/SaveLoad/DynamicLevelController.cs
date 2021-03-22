using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
static public class DynamicLevelController
{
    public static List<ChestInventory> chestInv_List = new List<ChestInventory>();
    public static List<DoorStatus> doorStat_List = new List<DoorStatus>();
    public static List<GridNodeInventory> gridInv_List = new List<GridNodeInventory>();
    public static List<MapData> mapData_List = new List<MapData>();

    [System.Serializable]
    public struct serialItem
    {
        public string genericName, fullName, description, lore;
        public InventoryItem.slotType slot;
        public InventoryItem.equipType type;
        public bool identified, magical, fragile, twoHanded, active;
        public int minDamage, maxDamage, fullCharges, maxDuration, quality;
        public int currentCharges, currentDuration;
        public float defense, critMultiplier, value;
        public int itemIconIndex;

        public serialItem(InventoryItem i)
        {
            genericName = "";
            fullName = "";
            description = "";
            lore = "";
            slot = 0;
            type = 0;
            identified = false;
            magical = false;
            fragile = false;
            twoHanded = false;
            active = false;
            minDamage = 0;
            maxDamage = 0;
            fullCharges = 0;
            maxDuration = 0;
            quality = 0;
            currentCharges = 0;
            currentDuration = 0;
            defense = 0;
            critMultiplier = 0;
            value = 0;
            itemIconIndex = 0;
            if (i != null)
            {
                genericName = i.genericName;
                fullName = i.fullName;
                description = i.description;
                lore = i.lore;
                slot = i.slot;
                type = i.type;
                identified = i.identified;
                magical = i.magical;
                fragile = i.fragile;
                twoHanded = i.twoHanded;
                active = i.active;
                minDamage = i.minDamage;
                maxDamage = i.maxDamage;
                fullCharges = i.fullCharges;
                maxDuration = i.maxDuration;
                quality = i.quality;
                currentCharges = i.currentCharges;
                currentDuration = i.currentDuration;
                defense = i.defense;
                critMultiplier = i.critMultiplier;
                value = i.value;
                itemIconIndex = i.itemIconIndex;
            }
        }
    }

    [System.Serializable]
    public struct ChestInventory
    {
        public string chestName;
        public int x, y, scene;
        public serialItem[] inventory;

        //Here is how to get the scene value = UnityEngine.SceneManagement.SceneManager.GetActiveScene();

        public ChestInventory(string _cn, int _x, int _y, int _s, InventoryItem[] _inv)
        {
            chestName = _cn;
            x = _x; y = _y; scene = _s;
            inventory = new serialItem[_inv.Length];
            for (int i = 0; i < _inv.Length; i ++)
            {
                //Debug.Log("Data Dump: _inv.Length = " + _inv.Length + ", inventory.length = " + inventory.Length + " and current index is " + i);
                inventory[i] = new serialItem(_inv[i]);
            }
        }
    }

    [System.Serializable]
    public struct DoorStatus
    {
        public int scene, x, y;
        public bool doorOpen, knownLocked;
        public float lockValue;
        public int iconIndex;
        
        public DoorStatus(int _s, int _x, int _y, bool _do, bool _kl, float _lv, int _ii)
        {
            scene = _s;
            x = _x; y = _y;
            doorOpen = _do;
            knownLocked = _kl;
            lockValue = _lv;
            iconIndex = _ii;
        }
    }

    [System.Serializable]
    public struct GridNodeInventory
    {
        public int x, y, scene;
        public serialItem[] inventory;

        public GridNodeInventory(int _x, int _y, int _s, InventoryItem[] _inv)
        {
            x = _x; y = _y; scene = _s;
            inventory = new serialItem[9];
            for (int i = 0; i < 9; i++) inventory[i] = new serialItem(_inv[i]);
        }
    }

    [System.Serializable]
    public struct MapData
    {
        public int scene;
        public int[] mapCenter;
        public int[] mapN;
        public int[] mapE;
        public int[] mapS;
        public int[] mapW;
        public bool[] mapNdoor;
        public bool[] mapEdoor;
        public bool[] mapSdoor;
        public bool[] mapWdoor;
        public bool[] mapNtrap;
        public bool[] mapEtrap;
        public bool[] mapStrap;
        public bool[] mapWtrap;
        public bool[] mapChest;
        public MapData(int s)
        {
            scene = s;
            mapCenter = new int[256]; for (int _i = 0; _i < 256; _i++) mapCenter[_i] = 0;
            mapN = new int[256]; for (int _i = 0; _i < 256; _i++) mapN[_i] = 0;
            mapE = new int[256]; for (int _i = 0; _i < 256; _i++) mapE[_i] = 0;
            mapS = new int[256]; for (int _i = 0; _i < 256; _i++) mapS[_i] = 0;
            mapW = new int[256]; for (int _i = 0; _i < 256; _i++) mapW[_i] = 0;
            mapNdoor = new bool[256]; for (int _i = 0; _i < 256; _i++) mapNdoor[_i] = false;
            mapEdoor = new bool[256]; for (int _i = 0; _i < 256; _i++) mapEdoor[_i] = false;
            mapSdoor = new bool[256]; for (int _i = 0; _i < 256; _i++) mapSdoor[_i] = false;
            mapWdoor = new bool[256]; for (int _i = 0; _i < 256; _i++) mapWdoor[_i] = false;
            mapNtrap = new bool[256]; for (int _i = 0; _i < 256; _i++) mapNtrap[_i] = false;
            mapEtrap = new bool[256]; for (int _i = 0; _i < 256; _i++) mapEtrap[_i] = false;
            mapStrap = new bool[256]; for (int _i = 0; _i < 256; _i++) mapStrap[_i] = false;
            mapWtrap = new bool[256]; for (int _i = 0; _i < 256; _i++) mapWtrap[_i] = false;
            mapChest = new bool[256]; for (int _i = 0; _i < 256; _i++) mapChest[_i] = false;
        }
        public MapData(int s, int[,] map, int[,] mN, int[,] mE, int[,] mS, int[,] mW, bool[,] mND, bool[,] mED, bool[,] mSD, bool[,] mWD, bool[,] mNT, bool[,] mET, bool[,] mST, bool[,] mWT, bool[,] mapC)
        {
            scene = s;
            mapCenter = new int[256];
            for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) mapCenter[y * 16 + x] = map[x,y];
            mapN = new int[256];
            for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) mapN[y * 16 + x] = mN[x, y];            
            mapE = new int[256];
            for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) mapE[y * 16 + x] = mE[x, y];
            mapS = new int[256];
            for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) mapS[y * 16 + x] = mS[x, y];
            mapW = new int[256];
            for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) mapW[y * 16 + x] = mW[x, y];
            mapNdoor = new bool[256];
            for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) mapNdoor[y * 16 + x] = mND[x, y];
            mapEdoor = new bool[256];
            for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) mapEdoor[y * 16 + x] = mED[x, y];
            mapSdoor = new bool[256];
            for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) mapSdoor[y * 16 + x] = mSD[x, y];
            mapWdoor = new bool[256];
            for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) mapWdoor[y * 16 + x] = mWD[x, y];
            mapNtrap = new bool[256];
            for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) mapNtrap[y * 16 + x] = mNT[x, y];
            mapEtrap = new bool[256];
            for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) mapEtrap[y * 16 + x] = mET[x, y];
            mapStrap = new bool[256];
            for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) mapStrap[y * 16 + x] = mST[x, y];
            mapWtrap = new bool[256];
            for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) mapWtrap[y * 16 + x] = mWT[x, y];
            mapChest = new bool[256];
            for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) mapChest[y * 16 + x] = mapC[x, y];
        }
    }










    //Clear methods
    public static void ClearChestInvetoryList() { chestInv_List.Clear(); }
    public static void ClearDoorStatusList() { doorStat_List.Clear(); }
    public static void ClearGridNodeInventoryList() { gridInv_List.Clear(); }
    public static void ClearMapDataList() { mapData_List.Clear(); }


    //add levels to the lists
    public static void AddLevelToLists(int s)
    {
        //1. sort out chests from map
        List<GameObject> _results = new List<GameObject>();
        FindAllChildrenWithTag(GameManager.GAME.Map[s].transform, "ChestParent", _results);
        //2. Add inventory to Struct
        for(int _i = 0; _i < _results.Count; _i++) chestInv_List.Add(new ChestInventory(_results[_i].name, (int)_results[_i].transform.position.x, (int)_results[_i].transform.position.z, 
            s, _results[_i].GetComponentInChildren<Hello_I_am_a_Chest>().inventory));

        //3. Now with Door Statuses
        _results.Clear();
        FindAllChildrenWithTag(GameManager.GAME.Map[s].transform, "MapDoor", _results);
        Hello_I_am_a_door _found;
        for (int _i = 0; _i < _results.Count; _i++)
            if (_results[_i].GetComponent<Hello_I_am_a_door>() != null) doorStat_List.Add(new DoorStatus(s, (int)_results[_i].transform.position.x, (int)_results[_i].transform.position.z, _results[_i].GetComponent<Hello_I_am_a_door>().doorOpen, _results[_i].GetComponent<Hello_I_am_a_door>().knownLocked, 
                _results[_i].GetComponent<Hello_I_am_a_door>().lockValue, _results[_i].GetComponent<Hello_I_am_a_door>().IconIndex)); //Added this pattern to further reduce results to just the ones with "Hello_I_am_a_door" script


        //4. Now with GriddNode Inventories
        _results.Clear();
        FindAllChildrenWithTag(GameManager.GAME.NodeHive[s].transform, "Node", _results);
        for (int _i = 0; _i < _results.Count; _i++) gridInv_List.Add(new GridNodeInventory((int)_results[_i].transform.position.x, (int)_results[_i].transform.position.z, s, _results[_i].GetComponent<GridNode>().inventory));

        //5. MiniMap Data
        _results.Clear();
        mapData_List.Add(new MapData(s)); //Default map data to blank. Will get real information as it is updated

        //6. TO DO: Monster stuff











    }

    public static void UpdateLevelDataLists()
    {
        int s = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex; //Get current level index
        
        //Lists to store new information
        List<ChestInventory> newChestData_List = new List<ChestInventory>();
        List<DoorStatus> newDoorData_List = new List<DoorStatus>();
        List<GridNodeInventory> newGridData_List = new List<GridNodeInventory>();
        List<MapData> newMapData_List = new List<MapData>();
        //TO DO: Monster data

        //Collect current data into new lists
        List<GameObject> _results = new List<GameObject>();
        FindAllChildrenWithTag(GameObject.FindGameObjectWithTag("Map").transform, "ChestParent", _results);
        for (int _i = 0; _i < _results.Count; _i++) newChestData_List.Add(new ChestInventory(_results[_i].name, (int)_results[_i].transform.position.x, (int)_results[_i].transform.position.z,
             s, _results[_i].GetComponentInChildren<Hello_I_am_a_Chest>().inventory));

        _results.Clear();
        FindAllChildrenWithTag(GameObject.FindGameObjectWithTag("Map").transform, "MapDoor", _results);
        Hello_I_am_a_door _found;
        for (int _i = 0; _i < _results.Count; _i++)
            if (_results[_i].GetComponent<Hello_I_am_a_door>() != null) newDoorData_List.Add(new DoorStatus(s, (int)_results[_i].transform.position.x, (int)_results[_i].transform.position.z, _results[_i].GetComponent<Hello_I_am_a_door>().doorOpen, _results[_i].GetComponent<Hello_I_am_a_door>().knownLocked,
                _results[_i].GetComponent<Hello_I_am_a_door>().lockValue, _results[_i].GetComponent<Hello_I_am_a_door>().IconIndex)); //Added this pattern to further reduce results to just the ones with "Hello_I_am_a_door" script

        _results.Clear();
        FindAllChildrenWithTag(GameObject.FindGameObjectWithTag("NodeHive").transform, "Node", _results);
        for (int _i = 0; _i < _results.Count; _i++) newGridData_List.Add(new GridNodeInventory((int)_results[_i].transform.position.x, (int)_results[_i].transform.position.z, s, _results[_i].GetComponent<GridNode>().inventory));

        _results.Clear();        
        newMapData_List.Add(new MapData(s, GameManager.PARTY.map, GameManager.PARTY.mapN, GameManager.PARTY.mapE, GameManager.PARTY.mapS, GameManager.PARTY.mapW, 
                                            GameManager.PARTY.mapND, GameManager.PARTY.mapED, GameManager.PARTY.mapSD, GameManager.PARTY.mapWD,
                                            GameManager.PARTY.mapNT, GameManager.PARTY.mapET, GameManager.PARTY.mapST, GameManager.PARTY.mapWT, GameManager.PARTY.mapC));
        //Replace old chest data with new chest data
        for (int _i = 0; _i < chestInv_List.Count; _i++)
        {
            if (chestInv_List[_i].scene == s) //found a line in the master list that references the current scene
            {
                chestInv_List[_i] = newChestData_List[0]; //first line of new data list is inserted at this line
                newChestData_List.RemoveAt(0); //then the first line of the new data list is removed.
            }
        }
        //Replace old door data with new door data
        for (int _i = 0; _i < doorStat_List.Count; _i++)
        {
            if (doorStat_List[_i].scene == s)
            {
                doorStat_List[_i] = newDoorData_List[0]; 
                newDoorData_List.RemoveAt(0); 
            }
        }
        //Replace old GridNode inventory data
        for(int _i = 0; _i < gridInv_List.Count; _i++)
        {
            if(gridInv_List[_i].scene == s)
            {
                gridInv_List[_i] = newGridData_List[0];
                newGridData_List.RemoveAt(0);
            }
        }
        //Replace old Mini Map Data
        for (int _i = 0; _i < mapData_List.Count; _i++)
        {
            if(mapData_List[_i].scene == s)
            {
                mapData_List[_i] = newMapData_List[0];
                newMapData_List.RemoveAt(0);
            }
        }



        //TO DO: Monsters
        
        

    }

    public static void ActivateData(int s)
    {
        List<GameObject> _results = new List<GameObject>(), _new = new List<GameObject>();
        FindAllChildrenWithTag(GameObject.FindGameObjectWithTag("Map").transform, "ChestParent", _results);
        for (int _i = 0; _i < chestInv_List.Count; _i++)
            if (chestInv_List[_i].scene == s)
                foreach(GameObject go in _results)
                    if (chestInv_List[_i].chestName == go.name && chestInv_List[_i].x == go.transform.position.x && chestInv_List[_i].y == go.transform.position.z) go.GetComponentInChildren<Hello_I_am_a_Chest>().LoadInventory(chestInv_List[_i].inventory);

        _results.Clear(); 
        FindAllChildrenWithTag(GameObject.FindGameObjectWithTag("Map").transform, "MapDoor", _new);
        for (int i = 0; i < _new.Count; i++) if (_new[i].GetComponent<Hello_I_am_a_door>() != null) _results.Add(_new[i]);
        for (int i = 0; i < doorStat_List.Count; i++)
            if (doorStat_List[i].scene == s)
                foreach (GameObject go in _results)
                    if (doorStat_List[i].x == (int)go.transform.position.x && doorStat_List[i].y == (int)go.transform.position.z)
                    {
                        go.GetComponent<Hello_I_am_a_door>().doorOpen = doorStat_List[i].doorOpen;
                        go.GetComponent<Hello_I_am_a_door>().knownLocked = doorStat_List[i].knownLocked;
                        go.GetComponent<Hello_I_am_a_door>().lockValue = doorStat_List[i].lockValue;
                        go.GetComponent<Hello_I_am_a_door>().IconIndex = doorStat_List[i].iconIndex;
                    }

        _results.Clear();
        FindAllChildrenWithTag(GameObject.FindGameObjectWithTag("NodeHive").transform, "Node", _results);
        for (int i = 0; i < gridInv_List.Count; i++)
            if (gridInv_List[i].scene == s)
                foreach (GameObject go in _results)
                    if (gridInv_List[i].x == (int)go.transform.position.x && gridInv_List[i].y == (int)go.transform.position.z)
                        go.GetComponent<GridNode>().LoadInventory(gridInv_List[i].inventory);

        for(int i = 0; i < mapData_List.Count; i++)
            if(mapData_List[i].scene == s)
            {
                for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) GameManager.PARTY.map[x, y] = mapData_List[i].mapCenter[y * 16 + x];
                for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) GameManager.PARTY.mapN[x, y] = mapData_List[i].mapN[y * 16 + x];
                for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) GameManager.PARTY.mapE[x, y] = mapData_List[i].mapE[y * 16 + x];
                for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) GameManager.PARTY.mapS[x, y] = mapData_List[i].mapS[y * 16 + x];
                for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) GameManager.PARTY.mapW[x, y] = mapData_List[i].mapW[y * 16 + x];
                for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) GameManager.PARTY.mapND[x, y] = mapData_List[i].mapNdoor[y * 16 + x];
                for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) GameManager.PARTY.mapED[x, y] = mapData_List[i].mapEdoor[y * 16 + x];
                for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) GameManager.PARTY.mapSD[x, y] = mapData_List[i].mapSdoor[y * 16 + x];
                for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) GameManager.PARTY.mapWD[x, y] = mapData_List[i].mapWdoor[y * 16 + x];
                for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) GameManager.PARTY.mapNT[x, y] = mapData_List[i].mapNtrap[y * 16 + x];
                for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) GameManager.PARTY.mapET[x, y] = mapData_List[i].mapEtrap[y * 16 + x];
                for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) GameManager.PARTY.mapST[x, y] = mapData_List[i].mapStrap[y * 16 + x];
                for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) GameManager.PARTY.mapWT[x, y] = mapData_List[i].mapWtrap[y * 16 + x];
                for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) GameManager.PARTY.mapC[x, y] = mapData_List[i].mapChest[y * 16 + x];
            }
    }

    private static void FindAllChildrenWithTag(Transform parent, string tag, List<GameObject> children_List)
    {
        foreach(Transform child in parent)
        {
            if(child.gameObject.tag == tag)
            {
                children_List.Add(child.gameObject);
            }
            FindAllChildrenWithTag(child, tag, children_List);
        }
    }
}

