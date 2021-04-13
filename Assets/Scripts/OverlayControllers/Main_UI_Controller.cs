using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_UI_Controller : MonoBehaviour
{
    public Canvas TOPLEVEL;
    public Canvas UI_INVENTORY_REF;
    public Transform ref_PartyPanel;
    public GameObject pf_PartyMemberSlot;
    public List<GameObject> ref_PartyMemberSlot = new List<GameObject>();

    [HideInInspector]public GameObject ThisInventoryOverlay;
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
    }
    public void CloseInventory()
    {
        Destroy(ThisInventoryOverlay);
        ThisInventoryOverlay = null;
    }

}
