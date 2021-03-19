using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExploreController : MonoBehaviour
{
    [Header("Party UI element Hookups")]
    public GameObject[] pcSlot = new GameObject[4];
    public GameObject ref_InventoryScreen;
    public GameObject ref_CharacterScreen;
    public GameObject ref_SpellCompendium;
    public GameObject ref_Map;
    public GameObject ref_MainMenu;
    public Image ref_Interact;
    public Sprite ref_empty;
    //public GameObject ref_messageWindow;
    public GameObject ref_Splash;


    [Header("Other")]
    public bool movementPaused = false;
    public int selected_Character;

    public GameObject current_InventoryScreen;
    public GameObject current_CharacterSheetScreen;
    public GameObject current_SpellCompendium;
    public GameObject current_Map;

    void Start()
    {
        GameObject _partyObj = GameObject.FindGameObjectWithTag("Player");
        if (GameManager.PARTY == null)
        {
            GameManager.PARTY = _partyObj.GetComponent<PartyController>();
            DontDestroyOnLoad(GameManager.PARTY);
        }
        else { Destroy(_partyObj); }

        if (GameManager.EXPLORE == null)
        {
            GameManager.EXPLORE = this;
            DontDestroyOnLoad(this);
        }
        else { Destroy(this); }

        DrawExplorerUI(); //First draw the UI.
    }

    public void DrawExplorerUI()
    {
        for (int _i = 0; _i < 4; _i++)
        {
            pcSlot[_i].transform.Find("Character_Key").GetChild(0).GetComponent<Text>().text = (_i+1).ToString(); //This draws the slot number to the portrait, so player can hit this key to bring up this PC's info
            pcSlot[_i].transform.Find("Character_Portrait").GetComponent<Image>().sprite = GameManager.GAME.PC_Portrait[GameManager.PARTY.PC[_i].portraitIndex]; //This draws the PC's portrait
            pcSlot[_i].transform.Find("Character_Name_Plate").transform.GetChild(0).GetComponent<Text>().text = GameManager.PARTY.PC[_i].characterName;//this draws the PC's name
            pcSlot[_i].transform.Find("HealthBarContainer").transform.GetChild(1).GetComponent<Image>().fillAmount = (GameManager.PARTY.PC[_i].health - GameManager.PARTY.PC[_i].wounds) / GameManager.PARTY.PC[_i].health; //this draws the PC's health bar
            if (GameManager.PARTY.PC[_i].wounds >= GameManager.PARTY.PC[_i].health) pcSlot[_i].transform.Find("Dead").gameObject.SetActive(true);
            if (GameManager.PARTY.PC[_i].wounds < GameManager.PARTY.PC[_i].health) pcSlot[_i].transform.Find("Dead").gameObject.SetActive(false);
            if (GameManager.PARTY.PC[_i].mana == 0) { pcSlot[_i].transform.Find("ManaBarContainer").gameObject.SetActive(false); } //If the PC has no mana, hide the mana bar.
            else
            {
                pcSlot[_i].transform.Find("ManaBarContainer").gameObject.SetActive(true); //IF the PC has Mana, show the mana bar
                pcSlot[_i].transform.Find("ManaBarContainer").transform.GetChild(1).GetComponent<Image>().fillAmount = (GameManager.PARTY.PC[_i].mana - GameManager.PARTY.PC[_i].drain) / GameManager.PARTY.PC[_i].mana; //draw the PC's Mana bar.
            }             
        }   
    }

    public void ClearAllScreens()
    {
        if (current_InventoryScreen != null) Destroy(current_InventoryScreen);
        if (current_CharacterSheetScreen != null) Destroy(current_CharacterSheetScreen);
        if (current_SpellCompendium != null) Destroy(current_SpellCompendium);
        if (current_Map != null) Destroy(current_Map);
        Tooltip.HideToolTip_Static();

        current_InventoryScreen = null;
        current_CharacterSheetScreen = null;
        current_SpellCompendium = null;
        current_Map = null;

        selected_Character = 0;
    }

    public void OpenInventoryScreen(int _n)
    {
        ClearAllScreens();
        selected_Character = _n;
        current_InventoryScreen = Instantiate(ref_InventoryScreen, this.transform);
    }
    public void OpenInventoryScreen()
    {
        ClearAllScreens();
        current_InventoryScreen = Instantiate(ref_InventoryScreen, this.transform);
    }

    public void OpenCharacterSheetScreen()
    {
        ClearAllScreens();
        current_CharacterSheetScreen = Instantiate(ref_CharacterScreen, this.transform);
    }

    public void OpenCharacterSheetScreen(int _n)
    {
        ClearAllScreens();
        selected_Character = _n;
        current_CharacterSheetScreen = Instantiate(ref_CharacterScreen, this.transform);
    }

    public void OpenSpellCompendium()
    {
        ClearAllScreens();
        current_SpellCompendium = Instantiate(ref_SpellCompendium, this.transform);
    }

    public void OpenSpellCompendium(int _n)
    {
        ClearAllScreens();
        selected_Character = _n;
        current_SpellCompendium = Instantiate(ref_SpellCompendium, this.transform);
    }

    public void OpenMapSheet()
    {
        ClearAllScreens();
        current_Map = Instantiate(ref_Map, this.transform);
    }

    public void OpenMapSheet(int _n)
    {
        ClearAllScreens();
        selected_Character = _n;
        current_Map = Instantiate(ref_Map, this.transform);
    }

    public void SaveGame()
    {
        Debug.Log("Game Saved by ExploreController");
        SaveLoadModule.SaveGame(GameManager.GAME.SelectedSaveSlot);
        ref_MainMenu.SetActive(false);
    }

    public void LoadGame()
    {
        Debug.Log("Game Loaded by ExploreController");
        SaveLoadModule.LoadGame(GameManager.GAME.SelectedSaveSlot);
        ref_MainMenu.SetActive(false);
    }
}
