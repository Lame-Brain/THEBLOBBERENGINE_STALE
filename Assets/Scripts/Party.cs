using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    public static Party PARTY;
    public PlayerCharacter[] partyMember = new PlayerCharacter[4];
    public int Gold;
    public List<string> KeyItems = new List<string>();


    private void Awake()
    {
        if (PARTY != null)
        {
            Debug.Log("Destroying duplicate singleton");
            Destroy(gameObject);
        }
        else
        {
            PARTY = this;
            DontDestroyOnLoad(PARTY);
            Debug.Log("Setting PARTY singleton");
        }

        BlobberEngine.Roster.Load_Roster();
        Debug.Log(BlobberEngine.Roster.GetMember(0).pcName + ": " +  BlobberEngine.Roster.GetMember(0).IconIndex);
        Debug.Log(BlobberEngine.Roster.GetMember(1).pcName + ": " +  BlobberEngine.Roster.GetMember(1).IconIndex);
        Debug.Log(BlobberEngine.Roster.GetMember(2).pcName + ": " +  BlobberEngine.Roster.GetMember(2).IconIndex);
        Debug.Log(BlobberEngine.Roster.GetMember(3).pcName + ": " +  BlobberEngine.Roster.GetMember(3).IconIndex);
        partyMember[0] = BlobberEngine.Roster.GetMember(0);
        partyMember[1] = BlobberEngine.Roster.GetMember(1);
        partyMember[2] = BlobberEngine.Roster.GetMember(2);
        partyMember[3] = BlobberEngine.Roster.GetMember(3);
    }

}
