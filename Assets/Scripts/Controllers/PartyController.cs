using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PartyController : MonoBehaviour
{
    public Character[] PC;
    public int money; //how much money does the party have?
    public int light; //how many more turns of light does the party have?
    public InventoryItem[] bagInventory = new InventoryItem[20]; //What is the party carrying?
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadParty(SaveSlot.serialParty p)
    {
        for (int _i = 0; _i < 4; _i++) PC[_i].LoadCharacter(p.PC[_i]);
        //for (int _i = 0; _i < 4; _i++) {PC[_i].LoadCharacter(p.PC[_i]); Debug.Log(PC[_i].characterName); }
        money = p.money;
        light = p.light;
        for (int _i = 0; _i < 20; _i++) if(p.bagInventory[_i].genericName != "") bagInventory[_i] = bagInventory[_i].LoadItem(p.bagInventory[_i]);
    }
}
