using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_UI_Controller : MonoBehaviour
{
    public Canvas TOPLEVEL;
    public Canvas UI_INVENTORY_REF, UI_MAINMENU_REF, UI_CHEST_REF, UI_NAV_REF, UI_CHARACTERSHEET_REF, UI_MAP_REF, UI_JOURNAL_REF, UI_SPELLS_REF;
    public Transform ref_PartyPanel;
    public GameObject pf_PartyMemberSlot;
    public List<GameObject> ref_PartyMemberSlot = new List<GameObject>();
    public Image ref_Interact_Display;

    [HideInInspector]public GameObject ThisInventoryOverlay, thisMainMenuOverlay, thisChestOverlay, thisNavOverlay, thisCharacterSheetOverlay, thisMapScreenOverlay, thisJournalOverlay, thisSpellOverlay;



    // Start is called before the first frame update
    void Start()
    {
        //Singleton Pattern
        if (GameManager.EXPLORE == null)
        {
            GameManager.EXPLORE = this;
            DontDestroyOnLoad(GameManager.EXPLORE);
        }
        else { Destroy(this); }        
    }

    public void UpdateUI()
    {
        GameObject _tempGO;
        if (ref_PartyPanel.childCount != GameManager.PARTYSIZE) //If the Party slots need to be created or changed
        {
            ref_PartyMemberSlot.Clear();
            foreach (GameObject _go in GameObject.FindGameObjectsWithTag("PartyMember_UISlot")) Destroy(_go);
            for (int _i = 0; _i < GameManager.PARTYSIZE; _i++)
            {
                _tempGO = Instantiate(pf_PartyMemberSlot, ref_PartyPanel);
                _tempGO.GetComponent<PartyMemberSlotController>().PartyMemberIndex = _i;
                ref_PartyMemberSlot.Add(_tempGO);
            }
        }

        for(int _i = 0; _i < GameManager.PARTYSIZE; _i++)
        {
            ref_PartyMemberSlot[_i].transform.Find("Portrait").GetComponent<Image>().sprite = GameManager.GAME.PCIcons[GameManager.PARTY.PC[_i].pc_PortraintIndex];
            ref_PartyMemberSlot[_i].transform.Find("NamePanel").GetComponentInChildren<Text>().text = GameManager.PARTY.PC[_i].pc_Name;
            ref_PartyMemberSlot[_i].transform.Find("HealthBarContainer").transform.GetChild(0).GetComponent<Image>().fillAmount = (GameManager.PARTY.PC[_i].pc_HP / GameManager.PARTY.PC[_i].pc_Max_HP);
            if (GameManager.PARTY.PC[_i].pc_Max_MP == 0) ref_PartyMemberSlot[_i].transform.Find("ManaBarContainer").gameObject.SetActive(false);
            if (GameManager.PARTY.PC[_i].pc_Max_MP > 0)
            {
                ref_PartyMemberSlot[_i].transform.Find("ManaBarContainer").gameObject.SetActive(true);
                ref_PartyMemberSlot[_i].transform.Find("ManaBarContainer").transform.GetChild(0).GetComponent<Image>().fillAmount = (GameManager.PARTY.PC[_i].pc_MP / GameManager.PARTY.PC[_i].pc_Max_MP);
            }
        }
    }

    public void OpenInventory(int _selectedCharacter)
    {
        ThisInventoryOverlay = Instantiate(UI_INVENTORY_REF).gameObject;
        GameManager.SELECTED_CHARACTER = _selectedCharacter;
        GameManager.PARTY.AllowParyMovement = false;
        ref_Interact_Display.gameObject.SetActive(false);
    }
    public void OpenMainMenu()
    {
        thisMainMenuOverlay = Instantiate(UI_MAINMENU_REF).gameObject;
        GameManager.PARTY.AllowParyMovement = false;
        ref_Interact_Display.gameObject.SetActive(false);
    }
    public void OpenNavMenu()
    {
        if (thisNavOverlay == null)
        {
            thisNavOverlay = Instantiate(UI_NAV_REF).gameObject;
            GameManager.PARTY.AllowParyMovement = false;
            ref_Interact_Display.gameObject.SetActive(false);
        }
        else
        {
            CloseOverlays();
        }
    }
    public void OpenCharacterSheetMenu()
    {
        thisNavOverlay = Instantiate(UI_CHARACTERSHEET_REF).gameObject;
        GameManager.PARTY.AllowParyMovement = false;
        ref_Interact_Display.gameObject.SetActive(false);
    }
    public void OpenMapScreenMenu()
    {
        thisNavOverlay = Instantiate(UI_MAP_REF).gameObject;
        GameManager.PARTY.AllowParyMovement = false;
        ref_Interact_Display.gameObject.SetActive(false);
    }
    public void OpenJournalMenu()
    {
        thisNavOverlay = Instantiate(UI_JOURNAL_REF).gameObject;
        GameManager.PARTY.AllowParyMovement = false;
        ref_Interact_Display.gameObject.SetActive(false);
    }
    public void OpenSpellMenu()
    {
        thisNavOverlay = Instantiate(UI_SPELLS_REF).gameObject;
        GameManager.PARTY.AllowParyMovement = false;
        ref_Interact_Display.gameObject.SetActive(false);
    }
    public void OpenChest(GameObject chest)
    {
        thisChestOverlay = Instantiate(UI_CHEST_REF).gameObject;
        thisChestOverlay.GetComponentInChildren<ChestScreenController>().thisChest = chest.GetComponent<Hello_I_am_a_chest>();
        GameManager.PARTY.AllowParyMovement = false;
        ref_Interact_Display.gameObject.SetActive(false);
    }

    public void CloseOverlays()
    {
        if (ThisInventoryOverlay != null) Destroy(ThisInventoryOverlay);
        if (thisMainMenuOverlay != null) Destroy(thisMainMenuOverlay);
        if (thisChestOverlay != null) Destroy(thisChestOverlay);
        if (thisNavOverlay != null) Destroy(thisNavOverlay);
        if (thisCharacterSheetOverlay != null) Destroy(thisCharacterSheetOverlay);
        if (thisMapScreenOverlay != null) Destroy(thisMapScreenOverlay);
        if (thisJournalOverlay != null) Destroy(thisJournalOverlay);
        if (thisSpellOverlay != null) Destroy(thisSpellOverlay);


        ThisInventoryOverlay = null;
        thisMainMenuOverlay = null;
        thisChestOverlay = null;
        thisNavOverlay = null;
        thisCharacterSheetOverlay = null;
        thisMapScreenOverlay = null;
        thisJournalOverlay = null;
        thisSpellOverlay = null;
        GameManager.PARTY.AllowParyMovement = true;
        ref_Interact_Display.gameObject.SetActive(true);
        GameManager.SELECTED_CHARACTER = -1;
    }

    public bool OverlaysOpen()
    {
        bool _result = false;
        if (ThisInventoryOverlay != null) _result = true;
        if (thisMainMenuOverlay != null) _result = true;
        if (thisChestOverlay != null) _result = true;

        return _result;
    }

}
