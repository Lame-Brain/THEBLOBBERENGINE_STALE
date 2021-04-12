using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Statics
    public static GameManager GAME;
    public static PartyController PARTY;
    public static Main_UI_Controller EXPLORE;
    public static int SAVESLOT;

    //Config settings
    public TextAsset ConfigFile;
    public static float MOVESPEED, TURNSPEED, MESSAGE_SPEED, BATTLE_SPEED, MUSIC_VOLUME, SFX_volume;

    //Icon Reference Arrays
    public Sprite[] ItemIcon;

    //Debug Stuff
    public Item ref_item;
    public Item.ItemInstance item1, item2;
    public GameObject gobbo1, gobbo2;

    private void Awake()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("EditorOnly")) go.SetActive(false);

        if(ConfigFile == null)
        {
            MOVESPEED = 0.01f; TURNSPEED = 0.01f; MESSAGE_SPEED = 1f; BATTLE_SPEED = 1f;
            MUSIC_VOLUME = 1; SFX_volume = 1;
        }
        else
        {
            string[] lines = ConfigFile.text.Split('\n');
            MOVESPEED = float.Parse(lines[0]);
            TURNSPEED = float.Parse(lines[1]);
            MESSAGE_SPEED = float.Parse(lines[2]);
            BATTLE_SPEED = float.Parse(lines[3]);
            MUSIC_VOLUME = float.Parse(lines[4]);
            SFX_volume = float.Parse(lines[5]);
        }

        //Singleton Pattern
        if (GAME == null)
        {
            GAME = this;
            DontDestroyOnLoad(GAME);
        }
        else { Destroy(this); }
    }

    // Start is called before the first frame update
    void Start()
    {
        //DEBUG!!! SET SAVE SLOT TO 0
        SAVESLOT = 0;

        item1 = new Item.ItemInstance(ref_item);
        item2 = new Item.ItemInstance(ref_item);
        gobbo1.GetComponent<MobLogic>().InitializeMob();
        gobbo2.GetComponent<MobLogic>().InitializeMob();

        item2.ID_Item();
        Debug.Log("This is the First Sword: " + item1.GetName() + " it deals " + item1.GetDamage() + " damage!");
        Debug.Log("This is the Second Sword: " + item2.GetName() + " it deals " + item2.GetDamage() + " damage!");

        Character pc = new Character("tester", Character.Class.Fighter, 8, 8, 8, 8, 8, 8, 8);
        Debug.Log("Hello " + pc.pc_Name + "! " + pc.pc_Max_HP);

        gobbo2.GetComponent<MobLogic>().mob_data.mob_HP--;
        Debug.Log("Goblins are here! Gobbo1 has " + gobbo1.GetComponent<MobLogic>().mob_data.mob_HP + " hp.");
        Debug.Log("Goblins are here! Gobbo2 has " + gobbo2.GetComponent<MobLogic>().mob_data.mob_HP + " hp.");
    }

    // Update is called once per frame
    void Update()
    {
        //DEBUG EVENT
        if (Input.GetKeyUp(KeyCode.BackQuote))
        {
            Debug.Log("DEBUG KEY PRESSED");

            EXPLORE.OpenInventory(0);
        }
    }

    public void InitializeGame()
    {
        //Initial save. this should only run if there is no save for the game already
        if (!SaveLoadModule.DoesSaveExist(SAVESLOT))
        {
            //1. Locate Party Starting Bag Inventory and convert to Bag Inventory instance items
            for (int _i = 0; _i < PARTY.Starting_bagInventory.Length; _i++) if (PARTY.Starting_bagInventory[_i] != null) PARTY.bagInventory[_i] = new Item.ItemInstance(PARTY.Starting_bagInventory[_i]);
        }
    }
}
