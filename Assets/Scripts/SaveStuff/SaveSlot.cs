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
        //Characters
        for (int _i = 0; _i < GameManager.PARTYSIZE; _i++) PC.Add(new SaveCharacterClass(GameManager.PARTY.PC[_i]));
        //Bag Inventory
        for (int _i = 0; _i < 20; _i++)
        {
            if (GameManager.PARTY.bagInventory[_i] != null)
            {
                //Debug.Log("Slot #" + _i + " = " + GameManager.PARTY.bagInventory[_i].name);
                bagInventory[_i] = new SaveItemClass(GameManager.PARTY.bagInventory[_i]);
            }
            if (GameManager.PARTY.bagInventory[_i] == null)
            {
                //Debug.Log("Slot #" + _i + " = null");
                bagInventory[_i] = null;
            }            
        }
        
        //Party info
        this.wealth = GameManager.PARTY.wealth;
        this.light = GameManager.PARTY.light;
        this.currentDungeonLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        this.xCoord = (int)GameManager.PARTY.transform.position.x;
        this.yCoord = (int)GameManager.PARTY.transform.position.z;
        this.face_xCoord = (int)GameManager.PARTY.FaceMe.position.x;
        this.face_yCoord = GameManager.PARTY.FaceMe.position.y;
        this.face_zCoord = (int)GameManager.PARTY.FaceMe.position.z;
        this.facing = GameManager.PARTY.facing;


        //Level Stuff
        List<GameObject> chests = new List<GameObject>(); chests.Clear();
        Debug.Log("Initial Save!!!!");
        for (int _l = 0; _l < GameManager.GAME.Levels.Length; _l++)
        {
            Levels.Add(new SaveLevelClass());

            Debug.Log("Levels count = " + Levels.Count);

            //Chests in GameManager.GAME.Levels array
            FindAllChildrenWithTag(GameManager.GAME.Levels[_l].transform, "Chest", chests);

            //parse through them
            for (int _i = 0; _i < chests.Count; _i++)
            {
                Levels[_l].Chest.Add(new SaveChestClass()); //Adds an entry to the Levels[].Chest List
                Levels[_l].Chest[_i].xCoord = (int)chests[_i].transform.position.x; Levels[_l].Chest[_i].yCoord = (int)chests[_i].transform.parent.position.z; //Assigns meta data to the Levels[].Chest list entry
                Levels[_l].Chest[_i].rotX = chests[_i].transform.rotation.x; Levels[_l].Chest[_i].rotY = chests[_i].transform.rotation.y; Levels[_l].Chest[_i].rotZ = chests[_i].transform.rotation.z; Levels[_l].Chest[_i].rotW = chests[_i].transform.rotation.w;

                Debug.Log("Chest count in level " + _l + " = " + Levels[_l].Chest.Count + "... this chest is at: " + Levels[_l].Chest[_l].xCoord + ", " + Levels[_l].Chest[_l].yCoord);// Debug output

                //Assigns the inventory of each chest to the inventory in Levels[].Chest list.
                for (int _s = 0; _s < 16; _s++)
                {
                    if (chests[_i].GetComponent<Hello_I_am_a_chest>().inventory[_s] != null) Levels[_l].Chest[_i].inventory[_s] = new SaveItemClass(chests[_i].GetComponent<Hello_I_am_a_chest>().inventory[_s]);
                }
            }
                

            //TO DO: loot

            //TO DO: Monster Spawns
        }        
    }

    public void UpdateSaveSlot(int ThisLevel)
    {
        //Characters
        for (int _i = 0; _i < GameManager.PARTYSIZE; _i++) PC.Add(new SaveCharacterClass(GameManager.PARTY.PC[_i]));
        //Bag Inventory
        for (int _i = 0; _i < 20; _i++)
        {
            if (GameManager.PARTY.bagInventory[_i] != null)
            {
                Debug.Log("Slot #" + _i + " = " + GameManager.PARTY.bagInventory[_i].name);
                bagInventory[_i] = new SaveItemClass(GameManager.PARTY.bagInventory[_i]);
            }
            if (GameManager.PARTY.bagInventory[_i] == null)
            {
                Debug.Log("Slot #" + _i + " = null");
                bagInventory[_i] = null;
            }
        }

        //Party info
        this.wealth = GameManager.PARTY.wealth;
        this.light = GameManager.PARTY.light;
        this.currentDungeonLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        this.xCoord = (int)GameManager.PARTY.transform.position.x;
        this.yCoord = (int)GameManager.PARTY.transform.position.z;
        this.face_xCoord = (int)GameManager.PARTY.FaceMe.position.x;
        this.face_yCoord = GameManager.PARTY.FaceMe.position.y;
        this.face_zCoord = (int)GameManager.PARTY.FaceMe.position.z;
        this.facing = GameManager.PARTY.facing;


        //Level Stuff
        List<GameObject> chests = new List<GameObject>(); chests.Clear();
                       
        //All the chests on this level
        FindAllChildrenWithTag(GameManager.GAME.Levels[ThisLevel].transform, "Chest", chests);
        for (int _i = 0; _i < Levels[ThisLevel].Chest.Count; _i++)
        {
            foreach (GameObject _chestGO in chests)
            {
//                Debug.Log("x check " + (int)_chestGO.transform.position.x + " ?= " + Levels[ThisLevel].Chest[_i].xCoord);
//                Debug.Log("y check " + (int)_chestGO.transform.position.z + " ?= " + Levels[ThisLevel].Chest[_i].yCoord);
//                Debug.Log("rotX check " + _chestGO.transform.rotation.x + " ?= " + Levels[ThisLevel].Chest[_i].rotX);
//                Debug.Log("rotY check " + _chestGO.transform.rotation.y + " ?= " + Levels[ThisLevel].Chest[_i].rotY);
//                Debug.Log("rotZ check " + _chestGO.transform.rotation.z + " ?= " + Levels[ThisLevel].Chest[_i].rotZ);
//                Debug.Log("rotW check " + _chestGO.transform.rotation.w + " ?= " + Levels[ThisLevel].Chest[_i].rotW);
                // Cycles through all the chests, comparing agains the one in the _i to see if location and angle match
                if ((int)_chestGO.transform.position.x == Levels[ThisLevel].Chest[_i].xCoord && (int)_chestGO.transform.position.z == Levels[ThisLevel].Chest[_i].yCoord &&
                        _chestGO.transform.rotation.x == Levels[ThisLevel].Chest[_i].rotX && _chestGO.transform.rotation.y == Levels[ThisLevel].Chest[_i].rotY && 
                        _chestGO.transform.rotation.z == Levels[ThisLevel].Chest[_i].rotZ && _chestGO.transform.rotation.w == Levels[ThisLevel].Chest[_i].rotW)
                {
                    for (int _s = 0; _s < 16; _s++)
                    {
//                        if (chests[_i].GetComponent<Hello_I_am_a_chest>().inventory[_s] == null) { Levels[ThisLevel].Chest[_i].inventory[_s] = null; Debug.Log("Saving Null"); }
//                        if (chests[_i].GetComponent<Hello_I_am_a_chest>().inventory[_s] != null) { Levels[ThisLevel].Chest[_i].inventory[_s] = new SaveItemClass(chests[_i].GetComponent<Hello_I_am_a_chest>().inventory[_s]); Debug.Log("Saving Item"); }
                        //Update the inventory of the stored chest in Levels[].Chest list
                        if (chests[_i].GetComponent<Hello_I_am_a_chest>().inventory[_s] == null) Levels[ThisLevel].Chest[_i].inventory[_s] = null;
                        if (chests[_i].GetComponent<Hello_I_am_a_chest>().inventory[_s] != null) Levels[ThisLevel].Chest[_i].inventory[_s] = new SaveItemClass(chests[_i].GetComponent<Hello_I_am_a_chest>().inventory[_s]);
                    }
                }
            }
        }

        //TO DO: Loot

        //TO DO: Monster Spawns
        

    }

    public void LoadLevelData(int ThisLevel)
    {
        Debug.Log("I knew I'd get into that terrible stuff before too long");

        List<GameObject> chests = new List<GameObject>(); chests.Clear();

        //LOAD All the chests on this level
        FindAllChildrenWithTag(GameManager.GAME.Levels[ThisLevel].transform, "Chest", chests);
        for (int _i = 0; _i < Levels[ThisLevel].Chest.Count; _i++)
        {
            foreach (GameObject _chestGO in chests)
            {
                if ((int)_chestGO.transform.position.x == Levels[ThisLevel].Chest[_i].xCoord && (int)_chestGO.transform.position.z == Levels[ThisLevel].Chest[_i].yCoord &&
                        _chestGO.transform.rotation.x == Levels[ThisLevel].Chest[_i].rotX && _chestGO.transform.rotation.y == Levels[ThisLevel].Chest[_i].rotY &&
                        _chestGO.transform.rotation.z == Levels[ThisLevel].Chest[_i].rotZ && _chestGO.transform.rotation.w == Levels[ThisLevel].Chest[_i].rotW)
                {
                    for (int _s = 0; _s < 16; _s++)
                    {
                        if (Levels[ThisLevel].Chest[_i].inventory[_s] == null) chests[_i].GetComponent<Hello_I_am_a_chest>().inventory[_s] = null;
                        if (Levels[ThisLevel].Chest[_i].inventory[_s] != null) chests[_i].GetComponent<Hello_I_am_a_chest>().inventory[_s] = GameManager.GAME.ref_item.LoadItem((Levels[ThisLevel].Chest[_i].inventory[_s]));
                    }
                }
            }
        }
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
