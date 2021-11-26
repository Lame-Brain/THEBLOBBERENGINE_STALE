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


        BlobberEngine.Roster.ROSTER.Add(new PlayerCharacter());
        BlobberEngine.Roster.ROSTER.Add(new PlayerCharacter());
        BlobberEngine.Roster.ROSTER.Add(new PlayerCharacter());
        BlobberEngine.Roster.ROSTER.Add(new PlayerCharacter());
        BlobberEngine.Roster.ROSTER[0].pcName = "Dair"; BlobberEngine.Roster.ROSTER[0].pcClass = BlobberEngine._enum.CharacterClass.Fighter;
        BlobberEngine.Roster.ROSTER[1].pcName = "Jinx"; BlobberEngine.Roster.ROSTER[1].pcClass = BlobberEngine._enum.CharacterClass.Thief;
        BlobberEngine.Roster.ROSTER[2].pcName = "Father Gil"; BlobberEngine.Roster.ROSTER[2].pcClass = BlobberEngine._enum.CharacterClass.Healer;
        BlobberEngine.Roster.ROSTER[3].pcName = "Gedrin"; BlobberEngine.Roster.ROSTER[3].pcClass = BlobberEngine._enum.CharacterClass.Magic_User;

        BlobberEngine.Roster.Save_Roster();

    }

}
