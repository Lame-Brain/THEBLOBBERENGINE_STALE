using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMemberSlotController : MonoBehaviour
{
    public int PartyMemberIndex;

    public void ObjectClicked()
    {
        if (GameManager.PARTY.AllowParyMovement)
        {
            GameManager.EXPLORE.OpenInventory(PartyMemberIndex);
        }
    }
}
