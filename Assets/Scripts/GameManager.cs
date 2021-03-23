﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GAME;
    public static PartyController PARTY;
    public static ExploreController EXPLORE;
    public static RULES RULES;

    public Sprite[] PC_Portrait, monster_Sprite, item_Icons, Icons;
    public Material[] DungeonColorTextures;
    public int SelectedSaveSlot;

    //Dynamic Level Controller data
    public GameObject[] Map, NodeHive, Spawner;


    void Awake()
    {
        if (GAME == null) GAME = this;
        else if (GAME != this) Destroy(this.gameObject);
        
        DontDestroyOnLoad(gameObject);


        //Hide Editor Only objects
        GameObject[] _EditorOnlyObjs = GameObject.FindGameObjectsWithTag("EditorOnly");
        foreach (GameObject _go in _EditorOnlyObjs) _go.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {        
        //Debug settings
        SelectedSaveSlot = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab)) //DEBUG
        {
            //UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

            //PARTY.PassTurn();
            //Splash("-14 hp", Color.red, Color.white, EXPLORE.pcSlot[0]);
            //Splash("-12 hp", Color.red, Color.white, EXPLORE.pcSlot[1]);
            //Splash("-28 hp", Color.red, Color.white, EXPLORE.pcSlot[2]);
            //Splash("-5 hp", Color.red, Color.white, EXPLORE.pcSlot[3]);
            //MessageWindow.ShowMessage_Static("This is a test message!");

                            //Debug.Log("Save");
                            //SaveLoadModule.SaveGame(0);
                            //Debug.Log("Load");
                            //SaveLoadModule.LoadGame(0); 

            /*
             * foreach(Material _mat in DungeonColorTextures)
                {
                    _mat.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
                }
            */

//            Debug.Log(PARTY.face + " = " + PARTY.transform.rotation.eulerAngles.y);
        }
    }

    public static void Splash(string text, Color bg, Color tc, GameObject target)
    {
        GameObject _go = Instantiate(EXPLORE.ref_Splash, target.transform);
        _go.GetComponent<Splash>().Show(text, bg, tc);
    }
}