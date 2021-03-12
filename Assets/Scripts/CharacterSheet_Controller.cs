using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSheet_Controller : MonoBehaviour
{
    public Text ref_characterName, ref_characterClass, ref_XPtext, ref_strength, ref_dexterity, ref_intelligence, ref_wisdom, ref_charisma, ref_health, ref_wounds, ref_mana, ref_drain, ref_attack, ref_defense, ref_freePoints;
    public GameObject ref_portrait, ref_freePointPanel, ref_levelUpPanel;

    public void ModifyStats(string delta)
    {
        if (delta == "S+")
        {
        }
        if (delta == "S-")
        {
        }
        if (delta == "D+")
        {
        }
        if (delta == "D-")
        {
        }
        if (delta == "I+")
        {
        }
        if (delta == "I-")
        {
        }
        if (delta == "W+")
        {
        }
        if (delta == "W-")
        {
        }
        if (delta == "C+")
        {
        }
        if (delta == "C-")
        {
        }
        if (delta == "H+")
        {
        }
        if (delta == "H-")
        {
        }
        if (delta == "M+")
        {
        }
        if (delta == "M-")
        {
        }
    }

    public void UpdateCharacterSheet()
    {
        ref_portrait.GetComponent<Image>().sprite = GameManager.GAME.PC_Portrait[GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].portraitIndex];
        ref_characterName.text = GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].characterName;
        ref_characterClass.text = GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].type.ToString();
        ref_XPtext.text = "Level " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].xpLevel + " XP: " 
            + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].xpPoints + " of " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].xpNNL;
        ref_strength.text = "Strength: " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].strength;
        ref_dexterity.text = "Dexterity: " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].dexterity;
        ref_intelligence.text = "Intelligence: " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].intelligence;
        ref_wisdom.text = "Wisdom: " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].wisdom;
        ref_charisma.text = "Charisma: " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].charisma;
        ref_health.text = "Max Health: " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].health;
        ref_wounds.text = "Wounds: " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].wounds;
        ref_mana.text = "Mana: " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].mana;
        ref_drain.text = "Mana Drained: " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].drain;
        ref_attack.text = "Attack Bonus: " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].attack;
        ref_defense.text = "Defense: " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].defense;

        if(GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].freePoints < 1)
        {
            ref_freePointPanel.SetActive(false);
            GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].freePoints = 0;
        }

        if(GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].freePoints > 0)
        {
            ref_freePointPanel.SetActive(true);
            ref_freePoints.text = "Points to be Assigned: " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].freePoints;
        }

        if (GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].xpPoints < GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].xpNNL)
        {
            ref_levelUpPanel.SetActive(false);
        }

        if (GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].xpPoints >= GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].xpNNL)
        {
            ref_levelUpPanel.SetActive(true);
        }
    }
}
