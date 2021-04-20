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
    public static bool DoesSaveExist(int _n)
    {
        return File.Exists(Application.persistentDataPath + "/saveGame0" + _n + ".sg");
    }
}