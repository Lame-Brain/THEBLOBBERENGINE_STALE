using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Main : MonoBehaviour
{
    private void Awake()
    {
        
    }
    void Start()
    {
        PlayerCharacter Me = new PlayerCharacter();
        Me.pcName = "Test Character";
        Me.pcClass = BlobberEngine._enum.CharacterClass.Fighter;
        Debug.Log(Me.HP(5));
        Debug.Log(Me.HP(5));
        Me.HP(5);
        Debug.Log(Me.HP());

        Debug.Log(BlobberEngine.Roster.ROSTER.Count);

        BlobberEngine.Roster.ROSTER.Add(new PlayerCharacter());
        BlobberEngine.Roster.ROSTER.Add(new PlayerCharacter());
        BlobberEngine.Roster.ROSTER.Add(new PlayerCharacter());
        BlobberEngine.Roster.ROSTER.Add(new PlayerCharacter());

        BlobberEngine.Roster.ROSTER[0].ID = 0; BlobberEngine.Roster.ROSTER[0].pcName = "Dair"; BlobberEngine.Roster.ROSTER[0].pcClass = BlobberEngine._enum.CharacterClass.Fighter; BlobberEngine.Roster.ROSTER[0].IconIndex = 5;
        BlobberEngine.Roster.ROSTER[0].head_EQ = new Item(2); 
        BlobberEngine.Roster.ROSTER[0].weapon_EQ = new Item(3);
        BlobberEngine.Roster.ROSTER[0].bag_EQ[0] = new Item(1); BlobberEngine.Roster.ROSTER[0].bag_EQ[1] = new Item(3);
        BlobberEngine.Roster.ROSTER[1].ID = 1; BlobberEngine.Roster.ROSTER[1].pcName = "Jinx"; BlobberEngine.Roster.ROSTER[1].pcClass = BlobberEngine._enum.CharacterClass.Thief; BlobberEngine.Roster.ROSTER[1].IconIndex = 2;
        BlobberEngine.Roster.ROSTER[2].ID = 2; BlobberEngine.Roster.ROSTER[2].pcName = "Father Gil"; BlobberEngine.Roster.ROSTER[2].pcClass = BlobberEngine._enum.CharacterClass.Healer; BlobberEngine.Roster.ROSTER[2].IconIndex = 19; BlobberEngine.Roster.ROSTER[2].HP(-2);
        BlobberEngine.Roster.ROSTER[3].ID = 3; BlobberEngine.Roster.ROSTER[3].pcName = "Gedrin"; BlobberEngine.Roster.ROSTER[3].pcClass = BlobberEngine._enum.CharacterClass.Magic_User; BlobberEngine.Roster.ROSTER[3].IconIndex = 0;

        BlobberEngine.Roster.Save_Roster();

        Debug.Log(BlobberEngine.Roster.ROSTER.Count);

    }

}
