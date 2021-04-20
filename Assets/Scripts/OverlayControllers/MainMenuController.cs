using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void SaveGameButton()
    {
        SaveLoadModule.SaveGame(GameManager.SAVESLOT);
        GameManager.EXPLORE.CloseOverlays();
    }

    public void LoadGameButton()
    {
        SaveLoadModule.LoadGame(GameManager.SAVESLOT);
        GameManager.GAME.LoadSceneThenLoadGame(SaveLoadModule.save_slot[GameManager.SAVESLOT].currentDungeonLevel);
        GameManager.EXPLORE.CloseOverlays();
    }
}
