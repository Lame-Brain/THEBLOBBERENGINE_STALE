using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScreenController : MonoBehaviour
{
    public GameObject itemTileRef, portraitRef;
    public GameObject headSlot_ref, neckSlot_ref, leftFingerSlot_ref, rightFingerSlot_ref, leftHandSlot_ref, rightHandSlot_ref, torsoSlot_ref, legsSlot_ref, feetSlot_ref;
    public Text partyWealth_ref;

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

        //Equipped Inventory
        if (GameManager.PARTY.PC[GameManager.SELECTED_CHARACTER].eq_Head != null)
        {
            _go = Instantiate(itemTileRef, headSlot_ref.transform);
            _go.GetComponent<Drag>().thisItem = GameManager.PARTY.PC[GameManager.SELECTED_CHARACTER].eq_Head;
        }

        if (GameManager.PARTY.PC[GameManager.SELECTED_CHARACTER].eq_Neck != null)
        {
            _go = Instantiate(itemTileRef, neckSlot_ref.transform);
            _go.GetComponent<Drag>().thisItem = GameManager.PARTY.PC[GameManager.SELECTED_CHARACTER].eq_Neck;
        }

        if (GameManager.PARTY.PC[GameManager.SELECTED_CHARACTER].eq_LeftFinger != null)
        {
            _go = Instantiate(itemTileRef, leftFingerSlot_ref.transform);
            _go.GetComponent<Drag>().thisItem = GameManager.PARTY.PC[GameManager.SELECTED_CHARACTER].eq_LeftFinger;
        }

        if (GameManager.PARTY.PC[GameManager.SELECTED_CHARACTER].eq_RightFinger != null)
        {
            _go = Instantiate(itemTileRef, rightFingerSlot_ref.transform);
            _go.GetComponent<Drag>().thisItem = GameManager.PARTY.PC[GameManager.SELECTED_CHARACTER].eq_RightFinger;
        }

        if (GameManager.PARTY.PC[GameManager.SELECTED_CHARACTER].eq_LeftHand != null)
        {
            _go = Instantiate(itemTileRef, leftHandSlot_ref.transform);
            _go.GetComponent<Drag>().thisItem = GameManager.PARTY.PC[GameManager.SELECTED_CHARACTER].eq_LeftHand;
        }

        if (GameManager.PARTY.PC[GameManager.SELECTED_CHARACTER].eq_RightHand != null)
        {
            _go = Instantiate(itemTileRef, rightHandSlot_ref.transform);
            _go.GetComponent<Drag>().thisItem = GameManager.PARTY.PC[GameManager.SELECTED_CHARACTER].eq_RightHand;
        }

        if (GameManager.PARTY.PC[GameManager.SELECTED_CHARACTER].eq_Torso != null)
        {
            _go = Instantiate(itemTileRef, torsoSlot_ref.transform);
            _go.GetComponent<Drag>().thisItem = GameManager.PARTY.PC[GameManager.SELECTED_CHARACTER].eq_Torso;
        }

        if (GameManager.PARTY.PC[GameManager.SELECTED_CHARACTER].eq_Legs != null)
        {
            _go = Instantiate(itemTileRef, legsSlot_ref.transform);
            _go.GetComponent<Drag>().thisItem = GameManager.PARTY.PC[GameManager.SELECTED_CHARACTER].eq_Legs;
        }

        if (GameManager.PARTY.PC[GameManager.SELECTED_CHARACTER].eq_Feet != null)
        {
            _go = Instantiate(itemTileRef, feetSlot_ref.transform);
            _go.GetComponent<Drag>().thisItem = GameManager.PARTY.PC[GameManager.SELECTED_CHARACTER].eq_Feet;
        }

        //Bag Inventory
        for(int _i = 0; _i < GameManager.PARTY.bagInventory.Length; _i++)
        {
            if (GameManager.PARTY.bagInventory[_i] != null)
            {
                _go = Instantiate(itemTileRef, transform.Find("BagSlots").GetChild(_i).transform);
                _go.GetComponent<Drag>().thisItem = GameManager.PARTY.bagInventory[_i];
            }
        }


        //Party Wealth
        partyWealth_ref.text = "Party Wealth: <color=yellow>" + GameManager.PARTY.wealth + "</color>";
    }

    public void CloseInventoryScreen()
    {
        GameManager.EXPLORE.CloseOverlays();
    }
}
