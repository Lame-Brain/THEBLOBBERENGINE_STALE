using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Main : MonoBehaviour
{   
    void Start()
    {
        PlayerCharacter Me = new PlayerCharacter();
        Me.pcName = "Test Character";
        Me.pcClass = BlobberEngine._enum.CharacterClass.Fighter;
        Debug.Log(Me.HP(5));
        Debug.Log(Me.HP(5));
        Me.HP(5);
        Debug.Log(Me.HP());


        List<PlayerCharacter> testroster = new List<PlayerCharacter>();
        testroster.Add(new PlayerCharacter());
        testroster.Add(new PlayerCharacter());
        testroster.Add(new PlayerCharacter());
        testroster.Add(new PlayerCharacter());
        testroster[0].pcName = "Test1"; testroster[0].pcClass = BlobberEngine._enum.CharacterClass.Fighter;
        testroster[1].pcName = "Test2"; testroster[1].pcClass = BlobberEngine._enum.CharacterClass.Thief;
        testroster[2].pcName = "Test3"; testroster[2].pcClass = BlobberEngine._enum.CharacterClass.Healer;
        testroster[3].pcName = "Test4"; testroster[3].pcClass = BlobberEngine._enum.CharacterClass.Magic_User;

        string filename = Application.persistentDataPath + "/ROSTER.TBE";
        if (File.Exists(filename))
        {
            Debug.Log("File exists, wiping it out.");
            File.Delete(filename);
        }
        Stream out_stream = File.Open(filename, FileMode.Create, FileAccess.Write);
        BinaryFormatter br = new BinaryFormatter();
        //br.Serialize(out_stream, testroster.Count.ToString());
        List<SaveCharacter> _saved_characters = new List<SaveCharacter>();
        for (int _i = 0; _i < testroster.Count; _i++) _saved_characters.Add(testroster[_i].SaveCharacter());
        br.Serialize(out_stream, _saved_characters);
        out_stream.Close();
                
        BinaryFormatter bf = new BinaryFormatter();
        Stream in_stream = File.Open(filename, FileMode.Open);
        List<SaveCharacter> _loaded_characters = bf.Deserialize(in_stream) as List<SaveCharacter>;
        in_stream.Close();

        testroster.Clear();        
        for (int _i = 0; _i < _loaded_characters.Count; _i++) testroster.Add(new PlayerCharacter(_loaded_characters[_i]));

        Debug.Log(testroster[0].pcName + " the " + testroster[0].pcClass.ToString());
        Debug.Log(testroster[1].pcName + " the " + testroster[1].pcClass.ToString());
        Debug.Log(testroster[2].pcName + " the " + testroster[2].pcClass.ToString());
        Debug.Log(testroster[3].pcName + " the " + testroster[3].pcClass.ToString());
        /**/
    }

}
