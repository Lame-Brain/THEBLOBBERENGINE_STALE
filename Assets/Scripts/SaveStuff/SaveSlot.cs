using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveSlot
{
    public List<SaveCharacterClass> PC = new List<SaveCharacterClass>();
    public SaveItemClass[] bagInventory = new SaveItemClass[20];
    public List<SaveLevelClass> Levels = new List<SaveLevelClass>();
    public int wealth, light, currentDungeonLevel;
    public float xCoord, yCoord, face_xCoord, face_yCoord, face_zCoord;
    public PartyController.Direction facing;

    public SaveSlot()
    {
        //Load Party members into SaveSlot
        for(int _p = 0; _p < GameManager.PARTYSIZE; _p++) 
        {
            PC.Add(new SaveCharacterClass(GameManager.PARTY.PC[_p]));
        }

        //Load party baggage into SaveSlot
        for (int _i = 0; _i < 20; _i++)
        {            
            if(GameManager.PARTY.bagInventory[_i] != null) bagInventory[_i] = new SaveItemClass(GameManager.PARTY.bagInventory[_i]);
        }

        //Load Party variables into SaveSlot
        wealth = GameManager.PARTY.wealth;
        light = GameManager.PARTY.light;
        currentDungeonLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        xCoord = (int)GameManager.PARTY.transform.position.x;
        yCoord = (int)GameManager.PARTY.transform.position.z;
        face_xCoord = GameManager.PARTY.FaceMe.transform.position.x;
        face_yCoord = GameManager.PARTY.FaceMe.transform.position.y;
        face_zCoord = GameManager.PARTY.FaceMe.transform.position.z;
        facing = GameManager.PARTY.facing;

        //Initialize Level List by grabbing data from all levels in the GameManager.GAME.Levels array
        List<GameObject> chestlist = new List<GameObject>(); List<GameObject> lootList = new List<GameObject>(); //Need these lists later
        for(int _l = 0; _l < GameManager.GAME.Levels.Length; _l++)
        {
            Levels.Add(new SaveLevelClass()); //start by adding an entry to the list

            chestlist.Clear(); lootList.Clear(); //make sure the lists are empty.

            FindAllChildrenWithTag(GameManager.GAME.Levels[_l].transform, "Chest", chestlist); //Make a list of chests
            FindAllChildrenWithTag(GameManager.GAME.Levels[_l].transform, "GridNode", lootList); //Make a list of loot

            if (chestlist.Count > 0) foreach (GameObject _ch in chestlist) Levels[_l].chest.Add(new SaveChestClass(_ch.GetComponent<Hello_I_am_a_chest>().inventory)); //Save the chests to the save slot
            if (lootList.Count > 0) foreach (GameObject _lt in lootList) Levels[_l].loot.Add(new SaveLootClass(_lt.GetComponent<GridNode>().inventory)); //Save the loot to the save slot
        }
    }

    public void UpdateSaveSlot(int thisLevel)
    {
        //Same as in initialization, want to update this every time the game is saved
        for (int _p = 0; _p < GameManager.PARTYSIZE; _p++)
        {
            PC.Add(new SaveCharacterClass(GameManager.PARTY.PC[_p]));
        }
        for (int _i = 0; _i < 20; _i++)
        {
            if (GameManager.PARTY.bagInventory[_i] != null) bagInventory[_i] = new SaveItemClass(GameManager.PARTY.bagInventory[_i]);
        }
        wealth = GameManager.PARTY.wealth;
        light = GameManager.PARTY.light;
        currentDungeonLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        xCoord = (int)GameManager.PARTY.transform.position.x;
        yCoord = (int)GameManager.PARTY.transform.position.z;
        face_xCoord = GameManager.PARTY.FaceMe.transform.position.x;
        face_yCoord = GameManager.PARTY.FaceMe.transform.position.y;
        face_zCoord = GameManager.PARTY.FaceMe.transform.position.z;
        facing = GameManager.PARTY.facing;

        //Save data for this level only
        List<GameObject> chestlist = new List<GameObject>(); List<GameObject> lootList = new List<GameObject>();
        FindAllChildrenWithTag(GameManager.GAME.Levels[thisLevel].transform, "Chest", chestlist); //Make a list of chests
        FindAllChildrenWithTag(GameManager.GAME.Levels[thisLevel].transform, "GridNode", lootList); //Make a list of loot
        if (chestlist.Count > 0) foreach (GameObject _ch in chestlist) Levels[thisLevel].chest.Add(new SaveChestClass(_ch.GetComponent<Hello_I_am_a_chest>().inventory)); //Save the chests to the save slot
        if (lootList.Count > 0) foreach (GameObject _lt in lootList) Levels[thisLevel].loot.Add(new SaveLootClass(_lt.GetComponent<GridNode>().inventory)); //Save the loot to the save slot
        Debug.Log(lootList.Count);
    }

    public void LoadLevel()
    {
        Debug.Log("Loading Level");

        //Load Characters
        for (int _p = 0; _p < GameManager.PARTYSIZE; _p++)
        {
            GameManager.PARTY.PC[_p] = PC[_p].LoadCharacter(PC[_p]);
        }

        //Load party Inventory
        for (int _i = 0; _i < 20; _i++)
        {
            if (bagInventory[_i] == null) GameManager.PARTY.bagInventory[_i] = null;
            if (bagInventory[_i] != null) GameManager.PARTY.bagInventory[_i] = ScriptableObject.CreateInstance<Item>().LoadItem(bagInventory[_i]);
        }

        //Load Party Variables
        GameManager.PARTY.wealth = SaveLoadModule.save_slot[GameManager.SAVESLOT].wealth;
        GameManager.PARTY.light = SaveLoadModule.save_slot[GameManager.SAVESLOT].light;
        GameManager.PARTY.facing = SaveLoadModule.save_slot[GameManager.SAVESLOT].facing;        
        GameManager.PARTY.transform.position = new Vector3(SaveLoadModule.save_slot[GameManager.SAVESLOT].xCoord, .5f, SaveLoadModule.save_slot[GameManager.SAVESLOT].yCoord);
        GameManager.PARTY.FaceMe.transform.position = new Vector3(SaveLoadModule.save_slot[GameManager.SAVESLOT].face_xCoord, SaveLoadModule.save_slot[GameManager.SAVESLOT].face_yCoord, SaveLoadModule.save_slot[GameManager.SAVESLOT].face_zCoord);
        GameManager.PARTY.transform.LookAt(GameManager.PARTY.FaceMe.position);
        GameManager.PARTY.GetMyNode();
        GameManager.PARTY.WhatsInFrontOfMe();

        //Load this level's treasure chests data
        int thisLevel = SaveLoadModule.save_slot[GameManager.SAVESLOT].currentDungeonLevel;
        List<GameObject> chestlist = new List<GameObject>(); List<GameObject> lootList = new List<GameObject>();
        FindAllChildrenWithTag(GameManager.GAME.Levels[thisLevel].transform, "Chest", chestlist); //Make a list of chests
        FindAllChildrenWithTag(GameManager.GAME.Levels[thisLevel].transform, "GridNode", lootList); //Make a list of loot
        if (chestlist.Count > 0)
            for (int _i = 0; _i < chestlist.Count; _i++)
                for (int _c = 0; _c < 16; _c++)
                    if (Levels[thisLevel].chest[_i].inventory[_c] != null) chestlist[_i].GetComponent<Hello_I_am_a_chest>().inventory[_c] = ScriptableObject.CreateInstance<Item>().LoadItem(Levels[thisLevel].chest[_i].inventory[_c]);
        if (lootList.Count > 0)
            for (int _i = 0; _i < lootList.Count; _i++)
                for (int _c = 0; _c < 9; _c++)
                    if (Levels[thisLevel].loot[_i].inventory[_c] != null)
                    {
                        lootList[_i].GetComponent<GridNode>().inventory[_c] = ScriptableObject.CreateInstance<Item>().LoadItem(Levels[thisLevel].loot[_i].inventory[_c]);
                        lootList[_i].GetComponent<GridNode>().DynamicProps();
                    }

        //Load Door status
        //Load Trap Status
        //Load Monsters
        //Load Floor Loot inventory

        //If not in the correct level, load the correct level

        //Load data to game

        //Update UI

        //Trigger Dynamic props

    }












    public static void FindAllChildrenWithTag(Transform parent, string tag, List<GameObject> children_List)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.tag == tag)
            {
                children_List.Add(child.gameObject);
            }
            FindAllChildrenWithTag(child, tag, children_List);
        }
    }
}