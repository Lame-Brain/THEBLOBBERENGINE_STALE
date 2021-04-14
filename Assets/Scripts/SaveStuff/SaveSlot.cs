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
        for (int _i = 0; _i < 20; _i++) if(bagInventory[_i] != null) bagInventory[_i] = new SaveItemClass(GameManager.PARTY.bagInventory[_i]);
        this.wealth = GameManager.PARTY.wealth;
        this.light = GameManager.PARTY.light;
        this.currentDungeonLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        this.xCoord = (int)GameManager.PARTY.transform.position.x;
        this.yCoord = (int)GameManager.PARTY.transform.position.z;
        this.face_xCoord = (int)GameManager.PARTY.FaceMe.position.x;
        this.face_yCoord = (int)GameManager.PARTY.FaceMe.position.y;
        this.face_zCoord = (int)GameManager.PARTY.FaceMe.position.z;
        this.facing = GameManager.PARTY.facing;
    }
}
