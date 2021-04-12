using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_UI_Controller : MonoBehaviour
{
    public Canvas TOPLEVEL;
    public Canvas UI_INVENTORY_REF;

    [HideInInspector]public GameObject ThisInventoryOverlay;
    // Start is called before the first frame update
    void Start()
    {
        //Singleton Pattern
        if (GameManager.EXPLORE == null)
        {
            GameManager.EXPLORE = this;
            DontDestroyOnLoad(GameManager.EXPLORE);
        }
        else { Destroy(this); }

        
    }

    public void OpenInventory(int _selectedCharacter)
    {
        ThisInventoryOverlay = Instantiate(UI_INVENTORY_REF).gameObject;
    }

}
