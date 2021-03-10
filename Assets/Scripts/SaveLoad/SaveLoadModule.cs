using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadModule
{
    public static SaveSlot[] save_slot = new SaveSlot[5];

    public static void SaveGame(int _n)
    {
        save_slot[_n] = new SaveSlot();
        GameObject _go = GameObject.FindGameObjectWithTag("Player");
        save_slot[_n].x_coor = (int)_go.transform.position.x;
        save_slot[_n].y_coor = (int)_go.transform.position.z;
        save_slot[_n].face = 0;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveGame0"+_n+".tbe");
        bf.Serialize(file, SaveLoadModule.save_slot[_n]);
        file.Close();
    }
}