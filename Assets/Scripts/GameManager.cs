using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GAME;
    public static PartyController PARTY;

    public Sprite[] PC_Portrait, monster_Sprite, item_Icons;

    void Awake()
    {
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
        //PARTY = GameObject.FindGameObjectWithTag("Player").GetComponent<PartyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Save");
            SaveLoadModule.SaveGame(0);
        }
    }
}