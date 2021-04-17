using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Statics
    public static GameManager GAME;
    public static PartyController PARTY;
    public static Main_UI_Controller EXPLORE;
    public static int SAVESLOT, SELECTED_CHARACTER;

    //Config settings and Rules
    public TextAsset ConfigFile;
    public static float MOVESPEED, TURNSPEED, MESSAGE_SPEED, BATTLE_SPEED, MUSIC_VOLUME, SFX_volume;
    public static int TILESIZE = 2;
    public static int PARTYSIZE = 4;

    //Icon Reference Arrays
    public Sprite[] ItemIcon;
    public Sprite[] PCIcons;

    //Debug Stuff
    public Item ref_item;
    public Item item1, item2;
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
        SELECTED_CHARACTER = -1;

        DEBUGSTUFF();

        //INSTANTIATE INVENTORY
        for (int _i = 0; _i < GameManager.PARTYSIZE; _i++)
        {
            if (GameManager.PARTY.PC[_i].eq_Head != null) Object.Instantiate(GameManager.PARTY.PC[_i].eq_Head);
            if (GameManager.PARTY.PC[_i].eq_Neck != null) Object.Instantiate(GameManager.PARTY.PC[_i].eq_Neck);
            if (GameManager.PARTY.PC[_i].eq_LeftFinger != null) Object.Instantiate(GameManager.PARTY.PC[_i].eq_LeftFinger);
            if (GameManager.PARTY.PC[_i].eq_RightFinger != null) Object.Instantiate(GameManager.PARTY.PC[_i].eq_RightFinger);
            if (GameManager.PARTY.PC[_i].eq_LeftHand != null) Object.Instantiate(GameManager.PARTY.PC[_i].eq_LeftHand);
            if (GameManager.PARTY.PC[_i].eq_RightHand != null) Object.Instantiate(GameManager.PARTY.PC[_i].eq_RightHand);
            if (GameManager.PARTY.PC[_i].eq_Torso != null) Object.Instantiate(GameManager.PARTY.PC[_i].eq_Torso);
            if (GameManager.PARTY.PC[_i].eq_Legs != null) Object.Instantiate(GameManager.PARTY.PC[_i].eq_Legs);
            if (GameManager.PARTY.PC[_i].eq_Feet != null) Object.Instantiate(GameManager.PARTY.PC[_i].eq_Feet);
        }


        //MORE DEBUG
        PARTY.PC[0].eq_RightHand = item1;
        PARTY.PC[1].eq_RightHand = item2;


        for (int _i = 0; _i < PARTY.bagInventory.Length; _i++) if (PARTY.bagInventory[_i] != null) PARTY.bagInventory[_i] = Instantiate(PARTY.bagInventory[_i]);
        //TO DO: Chests and Floor Loot

        //Initial save. this should only run if there is no save for the game already
        if (!SaveLoadModule.DoesSaveExist(SAVESLOT))
        {
            //SET party to full health and mana
            PARTY.PC[0].pc_HP = PARTY.PC[0].pc_Max_HP; PARTY.PC[0].pc_MP = PARTY.PC[0].pc_Max_MP;
            PARTY.PC[1].pc_HP = PARTY.PC[1].pc_Max_HP; PARTY.PC[1].pc_MP = PARTY.PC[1].pc_Max_MP;
            PARTY.PC[2].pc_HP = PARTY.PC[2].pc_Max_HP; PARTY.PC[2].pc_MP = PARTY.PC[2].pc_Max_MP;
            PARTY.PC[3].pc_HP = PARTY.PC[3].pc_Max_HP; PARTY.PC[3].pc_MP = PARTY.PC[3].pc_Max_MP;

            //Spin up blank savegame
            SaveLoadModule.NewSaveGame(SAVESLOT);
        }
        else //otherwise, load the save game
        {
            SaveLoadModule.LoadGame(SAVESLOT);

            //Load Characters
            for(int _p = 0; _p < PARTYSIZE; _p++) PARTY.PC[_p].LoadCharacter(SaveLoadModule.save_slot[SAVESLOT].PC[_p]);

            //Load BagInventory
            for (int _bi = 0; _bi < 20; _bi++) if (SaveLoadModule.save_slot[SAVESLOT].bagInventory[_bi] != null) PARTY.bagInventory[_bi].LoadItem(SaveLoadModule.save_slot[SAVESLOT].bagInventory[_bi]);

            //Load Party Variables
            PARTY.wealth = SaveLoadModule.save_slot[SAVESLOT].wealth;
            PARTY.light = SaveLoadModule.save_slot[SAVESLOT].light;
            PARTY.facing = SaveLoadModule.save_slot[SAVESLOT].facing;
            PARTY.transform.position = new Vector3(SaveLoadModule.save_slot[SAVESLOT].xCoord, .5f, SaveLoadModule.save_slot[SAVESLOT].yCoord);
            PARTY.FaceMe.transform.position = new Vector3(SaveLoadModule.save_slot[SAVESLOT].face_xCoord, SaveLoadModule.save_slot[SAVESLOT].face_yCoord, SaveLoadModule.save_slot[SAVESLOT].face_zCoord);
        }

        


        EXPLORE.UpdateUI();
    }

    public void DEBUGSTUFF()
    {
        //DEBUG!!! SET SAVE SLOT TO 0
        SAVESLOT = 0;
        PARTY.PC[0] = Character.CreateInstance<Character>(); PARTY.PC[0].LoadCharacter("Daire", Character.Class.Fighter, 0, 16, 10, 8, 8, 8, 13);
        PARTY.PC[1] = Character.CreateInstance<Character>(); PARTY.PC[1].LoadCharacter("Bandon", Character.Class.Cleric, 1, 13, 8, 8, 16, 10, 10);
        PARTY.PC[2] = Character.CreateInstance<Character>(); PARTY.PC[2].LoadCharacter("Jinx", Character.Class.Rogue, 2, 8, 16, 10, 8, 13, 10);
        PARTY.PC[3] = Character.CreateInstance<Character>(); PARTY.PC[3].LoadCharacter("Dyson", Character.Class.Mage, 3, 8, 8, 16, 13, 8, 8);

        item1 = Object.Instantiate(ref_item);
        item2 = Object.Instantiate(ref_item);
        gobbo1.GetComponent<MobLogic>().InitializeMob();
        gobbo2.GetComponent<MobLogic>().InitializeMob();

        item2.itm_ID = true;
        Debug.Log("This is the First Sword: " + item1.GetName() + " it deals " + item1.GetDamage() + " damage!");
        Debug.Log("This is the Second Sword: " + item2.GetName() + " it deals " + item2.GetDamage() + " damage!");

        //        Character pc = new Character("tester", Character.Class.Fighter, 8, 8, 8, 8, 8, 8, 8);
        //        Debug.Log("Hello " + pc.pc_Name + "! " + pc.pc_Max_HP);

        gobbo2.GetComponent<MobLogic>().mob_data.mob_HP--;
        Debug.Log("Goblins are here! Gobbo1 has " + gobbo1.GetComponent<MobLogic>().mob_data.mob_HP + " hp.");
        Debug.Log("Goblins are here! Gobbo2 has " + gobbo2.GetComponent<MobLogic>().mob_data.mob_HP + " hp.");
    }
}
