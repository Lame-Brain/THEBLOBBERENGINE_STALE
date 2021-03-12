﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExploreController : MonoBehaviour
{
    [Header("Party UI element Hookups")]
    public GameObject[] pcSlot = new GameObject[4];
    public GameObject ref_InventoryScreen;

    [Header("Other")]
    public bool movementPaused = false;
    public int selected_Character;

    public GameObject current_InventoryScreen;

    void Start()
    {
        GameManager.PARTY = GameObject.FindGameObjectWithTag("Player").GetComponent<PartyController>();
        GameManager.EXPLORE = this;
        DrawExplorerUI(); //First draw of UI.
    }

    void Update() //Explore controls go here.
    {
        
    }

    public void DrawExplorerUI()
    {
        for (int _i = 0; _i < 4; _i++)
        {
            pcSlot[_i].transform.Find("Character_Key").GetChild(0).GetComponent<Text>().text = (_i+1).ToString(); //This draws the slot number to the portrait, so player can hit this key to bring up this PC's info
            pcSlot[_i].transform.Find("Character_Portrait").GetComponent<Image>().sprite = GameManager.GAME.PC_Portrait[GameManager.PARTY.PC[_i].portraitIndex]; //This draws the PC's portrait
            pcSlot[_i].transform.Find("Character_Name_Plate").transform.GetChild(0).GetComponent<Text>().text = GameManager.PARTY.PC[_i].characterName;//this draws the PC's name
            pcSlot[_i].transform.Find("HealthBarContainer").transform.GetChild(1).GetComponent<Image>().fillAmount = (GameManager.PARTY.PC[_i].health - GameManager.PARTY.PC[_i].wounds) / GameManager.PARTY.PC[_i].health; //this draws the PC's health bar
            if (GameManager.PARTY.PC[_i].mana == 0) { pcSlot[_i].transform.Find("ManaBarContainer").gameObject.SetActive(false); } //If the PC has no mana, hide the mana bar.
            else
            {
                pcSlot[_i].transform.Find("ManaBarContainer").gameObject.SetActive(true); //IF the PC has Mana, show the mana bar
                pcSlot[_i].transform.Find("ManaBarContainer").transform.GetChild(1).GetComponent<Image>().fillAmount = (GameManager.PARTY.PC[_i].mana - GameManager.PARTY.PC[_i].drain) / GameManager.PARTY.PC[_i].mana; //draw the PC's Mana bar.
            } 
        }   
    }

    public void OpenInventoryScreen(int _n)
    {
        selected_Character = _n;
        if (current_InventoryScreen != null) Destroy(current_InventoryScreen);
        current_InventoryScreen = Instantiate(ref_InventoryScreen, this.transform);
    }
    public void CloseInventoryScreen()
    {
        Destroy(current_InventoryScreen);
        current_InventoryScreen = null;
    }

}
