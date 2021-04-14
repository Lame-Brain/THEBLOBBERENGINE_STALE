using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScreenController : MonoBehaviour
{
    public GameObject itemTileRef, portraitRef;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.SELECTED_CHARACTER > -1)
        {
            portraitRef.SetActive(true);
            transform.Find("Equipped_Title").gameObject.SetActive(true);
            transform.Find("Equipped Slots").gameObject.SetActive(true);
            transform.Find("TitleText").GetComponent<Text>().text = GameManager.PARTY.PC[GameManager.SELECTED_CHARACTER].pc_Name + "'s Inventory Screen";
            portraitRef.GetComponent<Image>().sprite = GameManager.GAME.PCIcons[GameManager.SELECTED_CHARACTER];
        }else
        {
            portraitRef.SetActive(false);
            transform.Find("Equipped_Title").gameObject.SetActive(false);
            transform.Find("Equipped Slots").gameObject.SetActive(false);
            transform.Find("TitleText").GetComponent<Text>().text = "Inventory Screen";
        }
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
            if (GameManager.PARTY.bagInventory[_i] != null)
            {
                Debug.Log("made it to index " + _i);
                Debug.Log("Found a " + GameManager.PARTY.bagInventory[_i].GetName());
                _go = Instantiate(itemTileRef, transform.Find("BagSlots").GetChild(_i).transform);
                _go.GetComponent<Drag>().thisItem = GameManager.PARTY.bagInventory[_i];
            }
        }
    }

    public void CloseInventoryScreen()
    {
        GameManager.EXPLORE.CloseInventory();
    }
}
