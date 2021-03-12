using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSheet_Controller : MonoBehaviour
{
    public Text ref_characterName, ref_characterClass, ref_XPtext, ref_strength, ref_dexterity, ref_intelligence, ref_wisdom, ref_charisma, ref_health, ref_wounds, ref_mana, ref_drain, ref_attack, ref_defense, ref_freePoints;
    public GameObject ref_portrait, ref_freePointPanel, ref_levelUpPanel;
    public Text ref_addStr, ref_addDex, ref_addIQ, ref_addWis, ref_addCha, ref_addHlth, ref_addMana;
    private int add_Str, add_Dex, add_IQ, add_Wis, add_Cha, add_Hlth, add_Mana;

    void Start()
    {
        UpdateCharacterSheet();
    }

    public void ModifyStats(string delta)
    {
        if (delta == "S+")
        {
            if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints > 0)
            {
                add_Str++;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints--;
            }
            UpdateCharacterSheet();
        }
        if (delta == "S-")
        {
            if (add_Str > 0)
            {
                add_Str--;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints++;
            }
            UpdateCharacterSheet();
        }
        if (delta == "D+")
        {
            if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints > 0)
            {
                add_Dex++;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints--;
            }
            UpdateCharacterSheet();
        }
        if (delta == "D-")
        {
            if (add_Dex > 0)
            {
                add_Dex--;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints++;
            }
            UpdateCharacterSheet();
        }
        if (delta == "I+")
        {
            if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints > 0)
            {
                add_IQ++;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints--;
            }
            UpdateCharacterSheet();
        }
        if (delta == "I-")
        {
            if (add_IQ > 0)
            {
                add_IQ--;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints++;
            }
            UpdateCharacterSheet();
        }
        if (delta == "W+")
        {
            if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints > 0)
            {
                add_Wis++;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints--;
            }
            UpdateCharacterSheet();
        }
        if (delta == "W-")
        {
            if (add_Wis > 0)
            {
                add_Wis--;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints++;
            }
            UpdateCharacterSheet();
        }
        if (delta == "C+")
        {
            if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints > 0)
            {
                add_Cha++;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints--;
            }
            UpdateCharacterSheet();
        }
        if (delta == "C-")
        {
            if (add_Cha > 0)
            {
                add_Cha--;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints++;
            }
            UpdateCharacterSheet();
        }
        if (delta == "H+")
        {
            if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints > 0)
            {
                add_Hlth++;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints--;
            }
            UpdateCharacterSheet();
        }
        if (delta == "H-")
        {
            if (add_Hlth > 0)
            {
                add_Hlth--;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints++;
            }
            UpdateCharacterSheet();
        }
        if (delta == "M+")
        {
            if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints > 0)
            {
                add_Mana++;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints--;
            }
            UpdateCharacterSheet();
        }
        if (delta == "M-")
        {
            if (add_Mana > 0)
            {
                add_Mana--;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints++;
            }
            UpdateCharacterSheet();
        }
    }

    public void UpdateCharacterSheet()
    {
        ref_portrait.GetComponent<Image>().sprite = GameManager.GAME.PC_Portrait[GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].portraitIndex];
        ref_characterName.text = GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].characterName;
        ref_characterClass.text = GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].type.ToString();
        ref_XPtext.text = "Level " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].xpLevel + " XP: " 
            + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].xpPoints + " of " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].xpNNL;
        ref_strength.text = "Strength: " + (GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].strength + add_Str);
        ref_dexterity.text = "Dexterity: " + (GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].dexterity + add_Dex);
        ref_intelligence.text = "Intelligence: " + (GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].intelligence + add_IQ);
        ref_wisdom.text = "Wisdom: " + (GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].wisdom + add_Wis);
        ref_charisma.text = "Charisma: " + (GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].charisma + add_Cha);
        ref_health.text = "Max Health: " + (GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].health + add_Hlth);
        ref_wounds.text = "Wounds: " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].wounds;
        ref_mana.text = "Mana: " + (GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].mana + add_Mana);
        ref_drain.text = "Mana Drained: " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].drain;
        ref_attack.text = "Attack Bonus: " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].attack;
        ref_defense.text = "Defense: " + GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].defense;

        if (GameManager.PARTY.PC[GetComponentInParent<ExploreController>().selected_Character].freePoints > 0) ref_freePointPanel.SetActive(true);

        if (ref_freePointPanel.activeSelf)
        {
            ref_addStr.text = add_Str.ToString();
            ref_addDex.text = add_Dex.ToString();
            ref_addIQ.text = add_IQ.ToString();
            ref_addWis.text = add_Wis.ToString();
            ref_addCha.text = add_Cha.ToString();
            ref_addHlth.text = add_Hlth.ToString();
            ref_addMana.text = add_Mana.ToString();
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

    public void UpdateAddPoints()
    {
        GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].strength += add_Str;
        GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].dexterity += add_Dex;
        GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].intelligence += add_IQ;
        GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].wisdom += add_Wis;
        GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].charisma += add_Cha;
        GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].health += add_Hlth;
        GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].mana += add_Mana;
        add_Str = 0; add_Dex = 0; add_IQ = 0; add_Wis = 0; add_Cha = 0; add_Hlth = 0; add_Mana = 0;
        ref_freePointPanel.SetActive(false);
        UpdateCharacterSheet();
    }

    public void LevelUpCharacter() //<--------------------------------------------------------------------------------------------------------------------!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    {
        if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].xpPoints >= GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].xpNNL)
        {
            GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].xpLevel++; //increase level
            GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].xpPoints -= GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].xpNNL; //reduce xp by the amount needed to level
            GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].xpNNL += (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].xpLevel * GameManager.RULES.NNL_perLevel); //increase NNL by current XP_NNL+(XP_Level * NNL_perLevel)
            if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].type == Character.characterClass.Fighter)
            {
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].health += GameManager.RULES.Fighter_Health;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].health += GameManager.RULES.Fighter_Mana;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].attack = GameManager.RULES.Fighter_Attack;
            }
            if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].type == Character.characterClass.Rogue)
            {
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].health += GameManager.RULES.Rogue_Health;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].health += GameManager.RULES.Rogue_Mana;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].attack = GameManager.RULES.Rogue_Attack;
            }
            if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].type == Character.characterClass.Cleric)
            {
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].health += GameManager.RULES.Cleric_Health;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].health += GameManager.RULES.Cleric_Mana;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].attack = GameManager.RULES.Cleric_Attack;
            }
            if (GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].type == Character.characterClass.Mage)
            {
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].health += GameManager.RULES.Mage_Health;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].health += GameManager.RULES.Mage_Mana;
                GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].attack = GameManager.RULES.Mage_Attack;
            }
            GameManager.PARTY.PC[GameManager.EXPLORE.selected_Character].freePoints += GameManager.RULES.FreePointsPerLevel;

            UpdateCharacterSheet();
        }
    }

    public void CloseCharacterSheet()
    {
        GameManager.EXPLORE.ClearAllScreens();
    }
    public void Navigate_Left()
    {
        int _c = GameManager.EXPLORE.selected_Character;
        GetComponentInParent<ExploreController>().ClearAllScreens();
        GetComponentInParent<ExploreController>().OpenInventoryScreen(_c);
    }
    public void Navigate_Right()
    {
        int _c = GameManager.EXPLORE.selected_Character;
        GetComponentInParent<ExploreController>().ClearAllScreens();
        GetComponentInParent<ExploreController>().OpenSpellCompendium(_c);
    }
}
