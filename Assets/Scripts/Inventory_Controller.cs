using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Controller : MonoBehaviour
{
    public GameObject portrait;
    public GameObject[] ref_BagSlot, ref_GroundSlot;
    public GameObject ref_HeadSlot, ref_NeckSlot, ref_TorsoSlot, ref_LeftFingerSlot, ref_RightFingerSlot, ref_LeftHandSlot, ref_RightHandSlot, ref_LegsSlot, ref_FeetSlot, ref_stanceFrame, ref_itemTile;
    public Text ref_money;
    public Sprite ref_AggStanceIcon, ref_DefStanceIcon;

    // Start is called before the first frame update
    void Start()
    {
        InventoryToScreen();
    }

    public void InventoryToScreen()
    {
        //Clean up old Item_Tiles
        GameObject[] _killList = GameObject.FindGameObjectsWithTag("Item_Tile");
        foreach (GameObject _target in _killList) Destroy(_target);

        //Draw Stance Icons
        if (GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].frontLine) ref_stanceFrame.GetComponent<Image>().sprite = ref_AggStanceIcon;
        if (!GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].frontLine) ref_stanceFrame.GetComponent<Image>().sprite = ref_DefStanceIcon;

        //This draws the PC's portrait
        portrait.GetComponent<Image>().sprite = GameManager.GAME.PC_Portrait[GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].portraitIndex];

        //Draws Party Money
        ref_money.text = GameManager.PARTY.money.ToString();

        //Draw Equipped Items that are in inventory
        GameObject _go = null;
        if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Head != null)
        {
            _go = Instantiate(ref_itemTile, ref_HeadSlot.transform);
            _go.GetComponent<ItemTileController>().item = GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Head;
            _go.GetComponent<ItemTileController>().UpdateItemTile();
        }
        if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Neck != null)
        {
            _go = Instantiate(ref_itemTile, ref_NeckSlot.transform);
            _go.GetComponent<ItemTileController>().item = GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Neck;
            _go.GetComponent<ItemTileController>().UpdateItemTile();
        }
        if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_LeftFinger != null)
        {
            _go = Instantiate(ref_itemTile, ref_LeftFingerSlot.transform);
            _go.GetComponent<ItemTileController>().item = GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_LeftFinger;
            _go.GetComponent<ItemTileController>().UpdateItemTile();
        }
        if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_RightFinger != null)
        {
            _go = Instantiate(ref_itemTile, ref_RightFingerSlot.transform);
            _go.GetComponent<ItemTileController>().item = GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_RightFinger;
            _go.GetComponent<ItemTileController>().UpdateItemTile();
        }
        if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_LeftHand != null)
        {
            _go = Instantiate(ref_itemTile, ref_LeftHandSlot.transform);
            _go.GetComponent<ItemTileController>().item = GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_LeftHand;
            _go.GetComponent<ItemTileController>().UpdateItemTile();
        }
        if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_RightHand != null)
        {
            _go = Instantiate(ref_itemTile, ref_RightHandSlot.transform);
            _go.GetComponent<ItemTileController>().item = GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_RightHand;
            _go.GetComponent<ItemTileController>().UpdateItemTile();
        }
        if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Torso != null)
        {
            _go = Instantiate(ref_itemTile, ref_TorsoSlot.transform);
            _go.GetComponent<ItemTileController>().item = GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Torso;
            _go.GetComponent<ItemTileController>().UpdateItemTile();
        }
        if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Legs != null)
        {
            _go = Instantiate(ref_itemTile, ref_LegsSlot.transform);
            _go.GetComponent<ItemTileController>().item = GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Legs;
            _go.GetComponent<ItemTileController>().UpdateItemTile();
        }
        if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Feet != null)
        {
            _go = Instantiate(ref_itemTile, ref_FeetSlot.transform);
            _go.GetComponent<ItemTileController>().item = GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Feet;
            _go.GetComponent<ItemTileController>().UpdateItemTile();
        }

        //Draw Bag Items that are in inventory
        for (int _i = 0; _i < 20; _i++)
        {
            if(GameManager.PARTY.bagInventory[_i] != null)
            {
                _go = Instantiate(ref_itemTile, ref_BagSlot[_i].transform);
                _go.GetComponent<ItemTileController>().item = GameManager.PARTY.bagInventory[_i];
                _go.GetComponent<ItemTileController>().UpdateItemTile();
            }
        }
    }

    public void ScreenToInventory()
    {
        //update Selected Character's Head Slot
        if (ref_HeadSlot.transform.childCount == 0) GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Head = null;
        if (ref_HeadSlot.transform.childCount > 0) GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Head = ref_HeadSlot.GetComponentInChildren<ItemTileController>().item;
        //update Selected Character's Neck Slot
        if (ref_NeckSlot.transform.childCount == 0) GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Neck = null;
        if (ref_NeckSlot.transform.childCount > 0) GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Neck = ref_NeckSlot.GetComponentInChildren<ItemTileController>().item;
        //update Selected Character's Left Finger Slot
        if (ref_LeftFingerSlot.transform.childCount == 0) GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_LeftFinger = null;
        if (ref_LeftFingerSlot.transform.childCount > 0) GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_LeftFinger = ref_LeftFingerSlot.GetComponentInChildren<ItemTileController>().item;
        //update Selected Character's Right Finger Slot
        if (ref_RightFingerSlot.transform.childCount == 0) GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_RightFinger = null;
        if (ref_RightFingerSlot.transform.childCount > 0) GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_RightFinger = ref_RightFingerSlot.GetComponentInChildren<ItemTileController>().item;
        //update Selected Character's Left Hand Slot
        if (ref_LeftHandSlot.transform.childCount == 0) GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_LeftHand = null;
        if (ref_LeftHandSlot.transform.childCount > 0) GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_LeftHand = ref_LeftHandSlot.GetComponentInChildren<ItemTileController>().item;
        //update Selected Character's Right Hand Slot
        if (ref_RightHandSlot.transform.childCount == 0) GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_RightHand = null;
        if (ref_RightHandSlot.transform.childCount > 0) GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_RightHand = ref_RightHandSlot.GetComponentInChildren<ItemTileController>().item;
        //update Selected Character's Torso Slot
        if (ref_TorsoSlot.transform.childCount == 0) GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Torso = null;
        if (ref_TorsoSlot.transform.childCount > 0) GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Torso = ref_TorsoSlot.GetComponentInChildren<ItemTileController>().item;
        //update Selected Character's Legs Slot
        if (ref_LegsSlot.transform.childCount == 0) GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Legs = null;
        if (ref_LegsSlot.transform.childCount > 0) GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Legs = ref_LegsSlot.GetComponentInChildren<ItemTileController>().item;
        //update Selected Character's Feet Slot
        if (ref_FeetSlot.transform.childCount == 0) GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Feet = null;
        if (ref_FeetSlot.transform.childCount > 0) GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].eq_Feet = ref_FeetSlot.GetComponentInChildren<ItemTileController>().item;
        //Update Party's bag slots
        for (int _i = 0; _i < 20; _i++)
        {
            if (ref_BagSlot[_i].transform.childCount ==0) GameManager.PARTY.bagInventory[_i] = null;
            if (ref_BagSlot[_i].transform.childCount > 0) GameManager.PARTY.bagInventory[_i] = ref_BagSlot[_i].GetComponentInChildren<ItemTileController>().item;
        }

        //Close the Loop! Call InventorytoScreen
        InventoryToScreen();
    }

    public void CloseInventoryScreen()
    {
        GetComponentInParent<ExploreController>().CloseInventoryScreen();
    }
    public void ChangeCharacterStance()
    {
        GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].frontLine = !GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].frontLine;
        InventoryToScreen();
    }
}
