using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveSlot
{
    public List<SaveCharacterClass> PC = new List<SaveCharacterClass>();    
    public SaveItemClass[] bagInventory = new SaveItemClass[20];
    public int wealth, light, currentDungeonLevel;
    public float xCoord, yCoord, face_xCoord, face_yCoord, face_zCoord;
    public PartyController.Direction facing;

    public SaveSlot()
    {
        for (int _i = 0; _i < GameManager.PARTYSIZE; _i++) PC.Add(new SaveCharacterClass(GameManager.PARTY.PC[_i]));
    }
}
