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
}
