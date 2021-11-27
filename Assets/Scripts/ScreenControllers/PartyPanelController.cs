using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyPanelController : MonoBehaviour
{
    public GameObject[] CharcterPanel;
    public Image[] CharacterPortrait;
    public Image[] CharacterHPBar;

    private AssetManager asset;

    private void Awake()
    {
        asset = FindObjectOfType<AssetManager>();
    }

    private void Start()
    {
        UpdatePartyPortraits();
    }

    public void UpdatePartyPortraits()
    {
        for (int _i = 0; _i < 4; _i++)
        {
            CharacterPortrait[_i].sprite = asset.PORTRAITS[BlobberEngine.Roster.GetMember(_i).IconIndex];
            CharacterHPBar[_i].fillAmount = BlobberEngine.Roster.GetMember(_i).HpPercent();
        }
    }
}
