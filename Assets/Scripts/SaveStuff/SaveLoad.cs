using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public static class SaveLoadModule
{
    public static SaveSlot[] save_slot = new SaveSlot[4];
    public static int ActiveSceneIndex;

    public static void NewSaveGame(int _n)
    {
        //build save_slot
        save_slot[_n] = new SaveSlot();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveGame0" + _n + ".sg");
        bf.Serialize(file, SaveLoadModule.save_slot[_n]);
        file.Close();
    }

    public static void SaveGame(int _n)
    {        
        save_slot[_n].UpdateSaveSlot(SceneManager.GetActiveScene().buildIndex);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveGame0" + _n + ".sg");
        bf.Serialize(file, SaveLoadModule.save_slot[_n]);
        file.Close();
    }

    public static void LoadGame(int _n)
    {
        //if (File.Exists(Application.persistentDataPath + "/saveGame0" + _n + ".sg"))
        if (DoesSaveExist(_n))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveGame0" + _n + ".sg", FileMode.Open);
            SaveLoadModule.save_slot[_n] = (SaveSlot)bf.Deserialize(file);
            file.Close();
        }
    }

    public static void ApplyLoadData(int _n)
    {
        //Load Characters
        for (int _p = 0; _p<GameManager.PARTYSIZE; _p++) GameManager.PARTY.PC[_p].LoadCharacter(SaveLoadModule.save_slot[GameManager.SAVESLOT].PC[_p]);

        //Load BagInventory
        for (int _bi = 0; _bi< 20; _bi++)
        {
            if (SaveLoadModule.save_slot[_n].bagInventory[_bi] == null) GameManager.PARTY.bagInventory[_bi] = null;
            if (SaveLoadModule.save_slot[_n].bagInventory[_bi] != null) GameManager.PARTY.bagInventory[_bi] = Object.Instantiate(GameManager.GAME.ref_item.LoadItem(SaveLoadModule.save_slot[_n].bagInventory[_bi]));
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

        //Load Treasure Chest Inventory
        save_slot[_n].LoadLevelData(SceneManager.GetActiveScene().buildIndex);


        //Load Door status
        //Load Trap Status
        //Load Monsters
        //Load Floor Loot inventory

        //If not in the correct level, load the correct level

        //Load data to game

        //Update UI

        //Trigger Dynamic props

    }

    public static bool DoesSaveExist(int _n)
    {
        return File.Exists(Application.persistentDataPath + "/saveGame0" + _n + ".sg");
    }
}