using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveSlot
{
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
    public struct serialCharacter
    {
        public string characterName;
        public Character.characterClass type;
        public int xpLevel, xpPoints, xpNNL, freePoints;
        public int strength, dexterity, intelligence, wisdom, charisma;
        public float health, wounds, mana, drain, defense, attack;
        public int portraitIndex;
        public serialItem eq_Head, eq_Neck, eq_LeftFinger, eq_RightFinger, eq_LeftHand, eq_RightHand, eq_Torso, eq_Legs, eq_Feet;

        public serialCharacter(int n)
        {
            characterName = GameManager.PARTY.PC[n].characterName;
            type = GameManager.PARTY.PC[n].type;
            xpLevel = GameManager.PARTY.PC[n].xpLevel; xpPoints = GameManager.PARTY.PC[n].xpPoints; xpNNL = GameManager.PARTY.PC[n].xpNNL; freePoints = GameManager.PARTY.PC[n].freePoints;
            strength = GameManager.PARTY.PC[n].strength;
            dexterity = GameManager.PARTY.PC[n].dexterity;
            intelligence = GameManager.PARTY.PC[n].intelligence;
            wisdom = GameManager.PARTY.PC[n].wisdom;
            charisma = GameManager.PARTY.PC[n].charisma;
            health = GameManager.PARTY.PC[n].health;
            wounds = GameManager.PARTY.PC[n].wounds;
            mana = GameManager.PARTY.PC[n].mana;
            drain = GameManager.PARTY.PC[n].drain;
            defense = GameManager.PARTY.PC[n].defense;
            attack = GameManager.PARTY.PC[n].attack;
            portraitIndex = GameManager.PARTY.PC[n].portraitIndex;
            eq_Head = new serialItem(GameManager.PARTY.PC[n].eq_Head);
            eq_Neck = new serialItem(GameManager.PARTY.PC[n].eq_Neck);
            eq_LeftFinger = new serialItem(GameManager.PARTY.PC[n].eq_LeftFinger);
            eq_RightFinger = new serialItem(GameManager.PARTY.PC[n].eq_RightFinger);
            eq_LeftHand = new serialItem(GameManager.PARTY.PC[n].eq_LeftHand);
            eq_RightHand = new serialItem(GameManager.PARTY.PC[n].eq_RightHand);
            eq_Torso = new serialItem(GameManager.PARTY.PC[n].eq_Torso);
            eq_Legs = new serialItem(GameManager.PARTY.PC[n].eq_Legs);
            eq_Feet = new serialItem(GameManager.PARTY.PC[n].eq_Feet); 
        }
    }
    [System.Serializable]
    public struct serialParty
    {
        public serialCharacter[] PC;
        public int money; 
        public int light;
        public int x_coor, y_coor, face;
        public serialItem[] bagInventory;

        public serialParty(int n)
        {
            PC = new serialCharacter[4];
            for(int _i = 0; _i < 4; _i++)
            {
                PC[_i] = new serialCharacter(_i);
            }
            money = GameManager.PARTY.money;
            light = GameManager.PARTY.light;
            x_coor = GameManager.PARTY.x_coor; y_coor = GameManager.PARTY.y_coor; face = GameManager.PARTY.face;
            bagInventory = new serialItem[20];
            for(int _i = 0; _i < 20; _i++)
            {
                bagInventory[_i] = new serialItem(GameManager.PARTY.bagInventory[_i]);
            }
        }
    }
    [System.Serializable]
    public struct ChestData
    {
        public string chestName;
        public int x, y;
        public serialItem[] inventory;

        //Here is how to get the scene value = UnityEngine.SceneManagement.SceneManager.GetActiveScene();

        public ChestData(string _cn, int _x, int _y, InventoryItem[] _inv)
        {
            chestName = _cn;
            x = _x; y = _y;
            inventory = new serialItem[_inv.Length];
            for (int i = 0; i < _inv.Length; i++)
            {
                //Debug.Log("Data Dump: _inv.Length = " + _inv.Length + ", inventory.length = " + inventory.Length + " and current index is " + i);
                inventory[i] = new serialItem(_inv[i]);
            }
        }
    }
    [System.Serializable]
    public struct DoorData
    {
        public int x, y;
        public bool doorOpen, knownLocked;
        public float lockValue;
        public int iconIndex;

        public DoorData(int _x, int _y, bool _do, bool _kl, float _lv, int _ii)
        {
            x = _x; y = _y;
            doorOpen = _do;
            knownLocked = _kl;
            lockValue = _lv;
            iconIndex = _ii;
        }
    }
    [System.Serializable]
    public struct NodeData
    {
        public int x, y;
        public serialItem[] inventory;

        public NodeData(int _x, int _y, InventoryItem[] _inv)
        {
            x = _x; y = _y;
            inventory = new serialItem[9];
            for (int i = 0; i < 9; i++) inventory[i] = new serialItem(_inv[i]);
        }
    }
    [System.Serializable]
    public struct MiniMapData
    {
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
        public MiniMapData(int Filler)
        {         
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
        public MiniMapData(int[,] map, int[,] mN, int[,] mE, int[,] mS, int[,] mW, bool[,] mND, bool[,] mED, bool[,] mSD, bool[,] mWD, bool[,] mNT, bool[,] mET, bool[,] mST, bool[,] mWT, bool[,] mapC)
        {
            mapCenter = new int[256];
            for (int y = 0; y < 16; y++) for (int x = 0; x < 16; x++) mapCenter[y * 16 + x] = map[x, y];
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
    [System.Serializable]
    public struct SceneData
    {
        List<ChestData> ChestData;
        List<DoorData> DoorData;
        List<NodeData> NodeData;
        List<MiniMapData> MiniMapData;

        public SceneData(int filler)
        {
            ChestData = new List<ChestData>();
            DoorData = new List<DoorData>();
            NodeData = new List<NodeData>();
            MiniMapData = new List<MiniMapData>();
        }
    }




    public serialParty party = new serialParty(0);    


    //TO DO Add monsters
}