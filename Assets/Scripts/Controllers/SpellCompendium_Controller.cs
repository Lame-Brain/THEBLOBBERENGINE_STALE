using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCompendium_Controller : MonoBehaviour
{
    public GameObject ref_Portrait;
    public Text ref_NameText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSpellCompendiumScreen();
    }

    public void UpdateSpellCompendiumScreen()
    {
        ref_Portrait.GetComponent<Image>().sprite = GameManager.GAME.PC_Portrait[GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].portraitIndex];
        ref_NameText.text = GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].characterName;
    }

    public void CloseSpellCompendium()
    {
        GetComponentInParent<ExploreController>().ClearAllScreens();
    }
    public void Navigate_Left()
    {
        int _c = GameManager.EXPLORE.selected_Character;
        GetComponentInParent<ExploreController>().ClearAllScreens();
        GetComponentInParent<ExploreController>().OpenCharacterSheetScreen(_c);
    }
    public void Navigate_Right()
    {
        int _c = GameManager.EXPLORE.selected_Character;
        GetComponentInParent<ExploreController>().ClearAllScreens();
        GetComponentInParent<ExploreController>().OpenMapSheet(_c);
    }
}
