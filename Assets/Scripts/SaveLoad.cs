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

    public static void InitSave(int _n)
    {
        save_slot[_n] = new SaveSlot();
        //save_slot[_n].InitialSave();
    }

    public static void SaveGame(int _n)
    {
        //save_slot[_n].SaveData(SceneManager.GetActiveScene().buildIndex);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveGame0" + _n + ".sg");
        bf.Serialize(file, SaveLoadModule.save_slot[_n]);
        file.Close();
    }

    public static void LoadGame(int _n)
    {
        if (File.Exists(Application.persistentDataPath + "/saveGame0" + _n + ".sg"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveGame0" + _n + ".sg", FileMode.Open);
            SaveLoadModule.save_slot[_n] = (SaveSlot)bf.Deserialize(file);
            file.Close();

            //If not in the correct level, load the correct level

            //Load data to game

            //Update UI

            //Trigger Dynamic props
        }
    }
}