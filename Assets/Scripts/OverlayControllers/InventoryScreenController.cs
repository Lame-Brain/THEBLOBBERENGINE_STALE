using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScreenController : MonoBehaviour
{
    public int SelectedCharacterIndex;
    public GameObject itemTileRef;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("OPENED INVENTORY SCREEN");
        UpdateInventoryScreenFromInventory();
    }

    private void UpdateInventoryScreenFromInventory()
    {
        GameObject _go = null;

        //Clear out Existing Item Tiles
        foreach (GameObject _itemTile in GameObject.FindGameObjectsWithTag("UI_ItemTile")) Destroy(_itemTile);

        //Bag Inventory
        for(int _i = 0; _i < GameManager.PARTY.bagInventory.Length; _i++)
        {
            if (GameManager.PARTY.bagInventory[_i].ItemExist())
            {
                Debug.Log("made it to index " + _i);
                Debug.Log("Found a " + GameManager.PARTY.bagInventory[_i].GetName());
                _go = Instantiate(itemTileRef, transform.Find("BagSlots").GetChild(_i).transform);
                _go.GetComponent<Drag>().thisItem = GameManager.PARTY.bagInventory[_i];
            }
        }
    }
}
