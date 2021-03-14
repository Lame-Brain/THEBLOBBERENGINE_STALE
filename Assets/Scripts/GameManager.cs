using System.Collections;
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

    void Awake()
    {
        if (GAME == null)
        {
            GAME = this;
            DontDestroyOnLoad(GAME);
        }
        else { Destroy(this); }

        GameObject _ruleObject = GameObject.FindGameObjectWithTag("GameRules");
        if (RULES == null)
        {            
            RULES = _ruleObject.GetComponent<RULES>();
            DontDestroyOnLoad(RULES);
        }
        else { Destroy(_ruleObject); }

        //Hide Editor Only objects
        GameObject[] _EditorOnlyObjs = GameObject.FindGameObjectsWithTag("EditorOnly");
        foreach (GameObject _go in _EditorOnlyObjs) _go.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        //PARTY = GameObject.FindGameObjectWithTag("Player").GetComponent<PartyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tilde))
        {
            /* 
                Debug.Log("Save");
                SaveLoadModule.SaveGame(0);
                Debug.Log("Load");
                SaveLoadModule.LoadGame(0);
            */
            /*
             * foreach(Material _mat in DungeonColorTextures)
                {
                    _mat.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
                }
            */

            Debug.Log(PARTY.face + " = " + PARTY.transform.rotation.eulerAngles.y);
        }
    }
}