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
    }

}
