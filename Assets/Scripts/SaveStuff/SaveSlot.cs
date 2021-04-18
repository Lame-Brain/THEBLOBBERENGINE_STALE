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
        for (int _i = 0; _i < 20; _i++) if(bagInventory[_i] != null) bagInventory[_i] = new SaveItemClass(GameManager.PARTY.bagInventory[_i]);
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
        //chests
                //// DEBUG /////
        Levels.Add(new SaveLevelClass());
        int ThisLevel = 0;
                //// DEBUG ////

        List<GameObject> chests = new List<GameObject>();
        FindAllChildrenWithTag(GameManager.GAME.Levels[0].transform, "Chest", chests);
        for(int _i = 0; _i < chests.Count; _i++)
        {
            Levels[ThisLevel].Chest.Add(new SaveChestClass());
            Levels[ThisLevel].Chest[_i].xCoord = (int)chests[_i].transform.position.x; Levels[ThisLevel].Chest[_i].yCoord = (int)chests[_i].transform.position.z;
            Levels[ThisLevel].Chest[_i].rotX = chests[_i].transform.rotation.x; Levels[ThisLevel].Chest[_i].rotY = chests[_i].transform.rotation.y; Levels[ThisLevel].Chest[_i].rotZ = chests[_i].transform.rotation.z; Levels[ThisLevel].Chest[_i].rotW = chests[_i].transform.rotation.w;
            for (int _s = 0; _s < 16; _s++)
            {
                if (chests[_i].GetComponent<Hello_I_am_a_chest>().inventory[_s] != null) Levels[ThisLevel].Chest[_i].inventory[_s] = new SaveItemClass(chests[_i].GetComponent<Hello_I_am_a_chest>().inventory[_s]);
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
