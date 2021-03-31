using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StoreController : MonoBehaviour
{
    public GameObject[] ref_BagSlot, ref_StoreSlot;
    public GameObject ref_itemTile;
    public Text ref_StoreText, ref_money;

    private InventoryItem[] storeInventory;
    private int StoreMoney;
    
    // Start is called before the first frame update
    void Start()
    {
        StoreMoney = 0; //Store starts with 0. When store closes, new value is compared to this baseline, and party gold is adjusted by delta
        storeInventory = new InventoryItem[42];
        GenerateStoreInventory();
        InventoryToScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseStoreScreen()
    {
        Destroy(transform.gameObject);
        GameManager.EXPLORE.ClearAllScreens();
    }

    private void GenerateStoreInventory()
    {
        int _numitems4sale = Random.Range(4, 22);
        for(int _i = 0; _i < _numitems4sale; _i++)
        {
            storeInventory[_i] = GameManager.GAME.items[Random.Range(0, GameManager.GAME.items.Length)];
        }
    }

    public void InventoryToScreen()
    {
        ref_money.text = GameManager.PARTY.money.ToString();

        //Clean up old Item_Tiles
        GameObject[] _killList = GameObject.FindGameObjectsWithTag("Item_Tile");
        foreach (GameObject _target in _killList) Destroy(_target);
        //Draws Party Money
        ref_money.text = GameManager.PARTY.money.ToString();
        //Draw Bag Items that are in inventory
        GameObject _go = null;
        for (int _i = 0; _i < 20; _i++)
        {
            if (GameManager.PARTY.bagInventory[_i] != null)
            {
                _go = Instantiate(ref_itemTile, ref_BagSlot[_i].transform);
                _go.GetComponent<ItemTileController>().item = GameManager.PARTY.bagInventory[_i];
                _go.GetComponent<ItemTileController>().UpdateItemTile();
            }
        }
        //Draw Chest Items in that are in panel
        for (int _i = 0; _i < 42; _i++)
        {
            if(storeInventory[_i] != null)
            {
                _go = Instantiate(ref_itemTile, ref_StoreSlot[_i].transform);
                _go.GetComponent<ItemTileController>().item = storeInventory[_i];
                _go.GetComponent<ItemTileController>().UpdateItemTile();
            }
        }
    }

    public void ScreenToInventory()
    {
        //Update Party's bag slots
        for (int _i = 0; _i < 20; _i++)
        {
            if (ref_BagSlot[_i].transform.childCount == 0) GameManager.PARTY.bagInventory[_i] = null;
            if (ref_BagSlot[_i].transform.childCount > 0) GameManager.PARTY.bagInventory[_i] = ref_BagSlot[_i].GetComponentInChildren<ItemTileController>().item;
        }

        //Update Store's Inventory
        for(int _i = 0; _i < 42; _i++)
        {
            if (ref_StoreSlot[_i].transform.childCount == 0) storeInventory[_i] = null;
            if (ref_StoreSlot[_i].transform.childCount > 0) storeInventory[_i] = ref_StoreSlot[_i].GetComponentInChildren<ItemTileController>().item;
        }

        //Close the Loop! Call InventorytoScreen
        InventoryToScreen();
    }
}
