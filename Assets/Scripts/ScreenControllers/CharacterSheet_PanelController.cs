using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSheet_PanelController : MonoBehaviour
{
    public GameObject Character_Sheet_Panel;
    public Image Portrait;
    public TMPro.TextMeshProUGUI pcName;
    public Transform Inventory_Content;
    public GameObject TextLine_PF;
    public TMPro.TextMeshProUGUI stat1, stat2;

    private int Selected_Character;
    private AssetManager asset;
    private PlayerCharacter[] Party;
    private Party PartyScript;

    private void Awake()
    {
        asset = FindObjectOfType<AssetManager>();
        PartyScript = FindObjectOfType<Party>();
        Party = PartyScript.partyMember;
    }

    public void Update_Character_Sheet()
    {
        Portrait.sprite = asset.PORTRAITS[Party[Selected_Character].IconIndex];
        pcName.text = Party[Selected_Character].pcName;
        Update_Inventory_List();
        Update_Stats_Page();
    }

    public void Open_Character_Sheet(int n)
    {
        Selected_Character = n;
        Update_Character_Sheet();
        Update_Stats_Page();
    }

    public void Increase_Selected_Character()
    {
        Selected_Character++;
        if (Selected_Character > Party.Length) Selected_Character = 0;
        Update_Character_Sheet();
    }
    public void Decrease_Selected_Character()
    {
        Selected_Character--;
        if (Selected_Character < 0) Selected_Character = Party.Length - 1;
        Update_Character_Sheet();
    }
    public void Update_Inventory_List()
    {
        GameObject _go = null;
        if (Party[Selected_Character].weapon_EQ.itemBase.ID != 0)        {
            _go = Instantiate(TextLine_PF, Inventory_Content);
            _go.GetComponent<TMPro.TextMeshProUGUI>().text = "(EQ) " + Party[Selected_Character].weapon_EQ.ItemName();
        }
        if (Party[Selected_Character].shield_EQ.itemBase.ID != 0)        {
            _go = Instantiate(TextLine_PF, Inventory_Content);
            _go.GetComponent<TMPro.TextMeshProUGUI>().text = "(EQ) " + Party[Selected_Character].shield_EQ.ItemName();
        }
        if (Party[Selected_Character].armor_EQ.itemBase.ID != 0)        {
            _go = Instantiate(TextLine_PF, Inventory_Content);
            _go.GetComponent<TMPro.TextMeshProUGUI>().text = "(EQ) " + Party[Selected_Character].armor_EQ.ItemName();
        }
        if (Party[Selected_Character].head_EQ.itemBase.ID != 0)        {
            _go = Instantiate(TextLine_PF, Inventory_Content);
            _go.GetComponent<TMPro.TextMeshProUGUI>().text = "(EQ) " + Party[Selected_Character].head_EQ.ItemName();
        }
        if (Party[Selected_Character].neck_EQ.itemBase.ID != 0)        {
            _go = Instantiate(TextLine_PF, Inventory_Content);
            _go.GetComponent<TMPro.TextMeshProUGUI>().text = "(EQ) " + Party[Selected_Character].neck_EQ.ItemName();
        }
        if (Party[Selected_Character].wrists_EQ.itemBase.ID != 0)        {
            _go = Instantiate(TextLine_PF, Inventory_Content);
            _go.GetComponent<TMPro.TextMeshProUGUI>().text = "(EQ) " + Party[Selected_Character].wrists_EQ.ItemName();
        }
        if (Party[Selected_Character].ring1_EQ.itemBase.ID != 0)        {
            _go = Instantiate(TextLine_PF, Inventory_Content);
            _go.GetComponent<TMPro.TextMeshProUGUI>().text = "(EQ) " + Party[Selected_Character].ring1_EQ.ItemName();
        }
        if (Party[Selected_Character].ring2_EQ.itemBase.ID != 0)        {
            _go = Instantiate(TextLine_PF, Inventory_Content);
            _go.GetComponent<TMPro.TextMeshProUGUI>().text = "(EQ) " + Party[Selected_Character].ring2_EQ.ItemName();
        }
        if (Party[Selected_Character].waist_EQ.itemBase.ID != 0)        {
            _go = Instantiate(TextLine_PF, Inventory_Content);
            _go.GetComponent<TMPro.TextMeshProUGUI>().text = "(EQ) " + Party[Selected_Character].waist_EQ.ItemName();
        }
        if (Party[Selected_Character].feet_EQ.itemBase.ID != 0)        {
            _go = Instantiate(TextLine_PF, Inventory_Content);
            _go.GetComponent<TMPro.TextMeshProUGUI>().text = "(EQ) " + Party[Selected_Character].feet_EQ.ItemName();
        }
        for (int _i = 0; _i < Party[Selected_Character].bag_EQ.Length; _i++)        {
            if (Party[Selected_Character].bag_EQ[_i].itemBase.ID != 0)            {
                _go = Instantiate(TextLine_PF, Inventory_Content);
                _go.GetComponent<TMPro.TextMeshProUGUI>().text = Party[Selected_Character].bag_EQ[_i].ItemName();
            }
        }
    }

    public void Update_Stats_Page()
    {
        stat1.text = "XP\n" + Party[Selected_Character].XP() + "\nSTR\n" + Party[Selected_Character].Strength() + 
                     "\nDEX\n" + Party[Selected_Character].Dexterity() + "\nIQ\n" + Party[Selected_Character].IQ() +
                     "\nWis\n" + Party[Selected_Character].Wisdom() + "\nCharm\n" + Party[Selected_Character].Charm() +
                     "\nHealth\n" + Party[Selected_Character].Health();
        stat2.text = "HP\n" + Party[Selected_Character].HP() + " / " + Party[Selected_Character].MaxHP() + "\nReflex\n" + Party[Selected_Character].Reflex() +
                     "\nFort\n" + Party[Selected_Character].Fortitude() + "\nWill\n" + Party[Selected_Character].Willpower() + 
                     "\nBlock\n" + Party[Selected_Character].BlockAC() + "\nDodge\n" + Party[Selected_Character].DodgeAC() +
                     "\nAttack\n" + Party[Selected_Character].Attack();
    }
}
