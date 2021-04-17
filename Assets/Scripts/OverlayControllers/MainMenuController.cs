using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void SaveGameButton()
    {
        SaveLoadModule.SaveGame(GameManager.SAVESLOT);
    }

    public void LoadGameButton()
    {
        SaveLoadModule.LoadGame(GameManager.SAVESLOT);

        //Load Characters
        for (int _p = 0; _p < GameManager.PARTYSIZE; _p++) GameManager.PARTY.PC[_p].LoadCharacter(SaveLoadModule.save_slot[GameManager.SAVESLOT].PC[_p]);

        //Load BagInventory
        for (int _bi = 0; _bi < 20; _bi++) if (SaveLoadModule.save_slot[GameManager.SAVESLOT].bagInventory[_bi] != null) GameManager.PARTY.bagInventory[_bi].LoadItem(SaveLoadModule.save_slot[GameManager.SAVESLOT].bagInventory[_bi]);

        //Load Party Variables
        GameManager.PARTY.wealth = SaveLoadModule.save_slot[GameManager.SAVESLOT].wealth;
        GameManager.PARTY.light = SaveLoadModule.save_slot[GameManager.SAVESLOT].light;
        GameManager.PARTY.facing = SaveLoadModule.save_slot[GameManager.SAVESLOT].facing;
        GameManager.PARTY.transform.position = new Vector3(SaveLoadModule.save_slot[GameManager.SAVESLOT].xCoord, .5f, SaveLoadModule.save_slot[GameManager.SAVESLOT].yCoord);
        GameManager.PARTY.FaceMe.transform.position = new Vector3(SaveLoadModule.save_slot[GameManager.SAVESLOT].face_xCoord, SaveLoadModule.save_slot[GameManager.SAVESLOT].face_yCoord, SaveLoadModule.save_slot[GameManager.SAVESLOT].face_zCoord);
        GameManager.PARTY.transform.LookAt(GameManager.PARTY.FaceMe.position);
        GameManager.EXPLORE.CloseOverlays();
    }    
}
