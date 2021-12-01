using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyPanelController : MonoBehaviour
{
    public GameObject[] CharcterPanel;
    public Image[] CharacterPortrait;
    public Image[] CharacterHPBar;
    public GameObject Character_Sheet_Panel;

    private AssetManager asset;
    private PlayerCharacter[] Party;
    private Party PartyScript;

    private void Awake()
    {
        asset = FindObjectOfType<AssetManager>();
        PartyScript = FindObjectOfType<Party>();
        Party = PartyScript.partyMember;
    }

    private void Start()
    {
        UpdatePartyPortraits();
    }

    public void UpdatePartyPortraits()
    {
        for (int _i = 0; _i < 4; _i++)
        {
            CharacterPortrait[_i].sprite = asset.PORTRAITS[Party[_i].IconIndex];
            CharacterHPBar[_i].fillAmount = Party[_i].HpPercent();
        }
    }

    public void Player_Portrait_Clicked(int n)
    {
        Character_Sheet_Panel.SetActive(true);
        Character_Sheet_Panel.GetComponent<CharacterSheet_PanelController>().Open_Character_Sheet(n);
    }
}
