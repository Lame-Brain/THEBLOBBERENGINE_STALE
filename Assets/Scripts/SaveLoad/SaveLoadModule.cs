using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public static class SaveLoadModule
{
    public static SaveSlot[] save_slot = new SaveSlot[5];
    public static int ActiveSceneIndex;

    public static void SaveGame(int _n)
    {
        save_slot[_n] = new SaveSlot();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveGame0"+_n+".sg");
        bf.Serialize(file, SaveLoadModule.save_slot[_n]);
        file.Close();
    }

    public static void LoadGame(int _n)
    {
        if(File.Exists(Application.persistentDataPath + "/saveGame0" + _n + ".sg"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveGame0"+_n+".sg", FileMode.Open);
            SaveLoadModule.save_slot[_n] = (SaveSlot)bf.Deserialize(file);
            file.Close();
            ActiveSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(ActiveSceneIndex);
            GameManager.PARTY.LoadParty(save_slot[_n].party);
            DynamicLevelController.ActivateData(ActiveSceneIndex);

            //TO DO: Load monsters

            GameManager.EXPLORE.DrawExplorerUI();
        }
    }
}