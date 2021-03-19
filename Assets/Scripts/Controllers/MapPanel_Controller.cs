using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPanel_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CloseMapScreen()
    {
        GetComponentInParent<ExploreController>().ClearAllScreens();
    }
    public void Navigate_Left()
    {
        int _c = GameManager.EXPLORE.selected_Character;
        GetComponentInParent<ExploreController>().ClearAllScreens();
        GetComponentInParent<ExploreController>().OpenSpellCompendium(_c);
    }
    public void Navigate_Right()
    {
        int _c = GameManager.EXPLORE.selected_Character;
        GetComponentInParent<ExploreController>().ClearAllScreens();
        GetComponentInParent<ExploreController>().OpenInventoryScreen(_c);
    }
    public void ShowCloseTooltip()
    {
        Tooltip.ShowToolTip_Static("Close the Map");
    }
    public void ShowLeftArrowToolTip()
    {
        Tooltip.ShowToolTip_Static("Go to Spell Compendium");
    }
    public void ShowRightArrowToolTip()
    {
        Tooltip.ShowToolTip_Static("Go to Inventory");
    }
    public void HideLeftArrowToolTip()
    {
        Tooltip.HideToolTip_Static();
    }
}
