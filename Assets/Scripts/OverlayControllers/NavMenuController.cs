using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMenuController : MonoBehaviour
{
    public void OpenInventory()
    {
        GameManager.EXPLORE.CloseOverlays();
        GameManager.EXPLORE.OpenInventory(0);
    }
    public void OpenCharacterSheet()
    {
        GameManager.EXPLORE.CloseOverlays();
        GameManager.EXPLORE.OpenCharacterSheetMenu();
    }
    public void OpenMapScreen()
    {
        GameManager.EXPLORE.CloseOverlays();
        GameManager.EXPLORE.OpenMapScreenMenu();
    }
    public void OpenJournalScreen()
    {
        GameManager.EXPLORE.CloseOverlays();
        GameManager.EXPLORE.OpenJournalMenu();
    }
    public void OpenSpellCompendium()
    {
        GameManager.EXPLORE.CloseOverlays();
        GameManager.EXPLORE.OpenSpellMenu();
    }
}
