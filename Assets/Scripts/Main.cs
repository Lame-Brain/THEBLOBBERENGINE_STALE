using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerCharacter Me = new PlayerCharacter();
        Me.pcName = "Test Character";
        Me.pcClass = BlobberEngine._enum.CharacterClass.Fighter;
        Debug.Log(Me.HP(5));
        Debug.Log(Me.HP(5));
        Me.HP(5);
        Debug.Log(Me.HP());

        string filename = "outputcharacter.txt";
        /*
        if (File.Exists(filename))
        {
            Debug.Log("File exists, wiping it out.");
            File.Delete(filename);
        }
        Stream filestream = File.Open(filename, FileMode.Create, FileAccess.Write);
        BinaryFormatter br = new BinaryFormatter();
        br.Serialize(filestream, Me.SaveCharacter());
        */
        BinaryFormatter bf = new BinaryFormatter();
        Stream filestream = File.Open(filename, FileMode.Open);
        SaveCharacter Sc = (SaveCharacter)bf.Deserialize(filestream);
        Me.LoadCharacter(Sc);
        
        filestream.Close();

        Debug.Log(Me.pcName + " the " + Me.pcClass.ToString() + " has a " + Me.weapon_EQ);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
