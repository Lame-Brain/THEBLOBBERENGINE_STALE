using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveSlot
{
    [System.Serializable]
    public struct serialCharacter
    {
        public string characterName;
        public Character.characterClass type;
        public int xpLevel, xpPoints, xpNNL;
        public int strength, dexterity, intelligence, wisdom, charisma;
        public float health, wounds, mana, drain, defense, attack;
        public int portraitIndex;
        public InventoryItem eq_Head, eq_Neck, eq_LeftFinger, eq_RightFinger, eq_LeftHand, eq_RightHand, eq_Legs, eq_Feet;

        public serialCharacter(int n)
        {
            characterName = GameManager.PARTY.PC[n].characterName;
            type = GameManager.PARTY.PC[n].type;
            xpLevel = GameManager.PARTY.PC[n].xpLevel; xpPoints = GameManager.PARTY.PC[n].xpPoints; xpNNL = GameManager.PARTY.PC[n].xpNNL;
            strength = GameManager.PARTY.PC[n].strength;
            dexterity = GameManager.PARTY.PC[n].dexterity;
            intelligence = GameManager.PARTY.PC[n].intelligence;
            wisdom = GameManager.PARTY.PC[n].wisdom;
            charisma = GameManager.PARTY.PC[n].charisma;
            health = GameManager.PARTY.PC[n].health;
            wounds = GameManager.PARTY.PC[n].wounds;
            mana = GameManager.PARTY.PC[n].mana;
            drain = GameManager.PARTY.PC[n].drain;
            defense = GameManager.PARTY.PC[n].defense;
            attack = GameManager.PARTY.PC[n].attack;
            portraitIndex = GameManager.PARTY.PC[n].portraitIndex;
            eq_Head = GameManager.PARTY.PC[n].eq_Head;
            eq_Neck = GameManager.PARTY.PC[n].eq_Neck;
            eq_LeftFinger = GameManager.PARTY.PC[n].eq_LeftFinger;
            eq_RightFinger = GameManager.PARTY.PC[n].eq_RightFinger;
            eq_LeftHand = GameManager.PARTY.PC[n].eq_LeftHand;
            eq_RightHand = GameManager.PARTY.PC[n].eq_RightHand;
            eq_Legs = GameManager.PARTY.PC[n].eq_Legs;
            eq_Feet = GameManager.PARTY.PC[n].eq_Feet; 
        }
    }
    [System.Serializable]
    public struct serialParty
    {
        public serialCharacter[] PC;
        public int money; 
        public int light;
        public InventoryItem[] bagInventory;

        public serialParty(int n)
        {
            PC = new serialCharacter[4];
            for(int _i = 0; _i < 4; _i++)
            {
                PC[_i] = new serialCharacter(_i);
            }
            money = GameManager.PARTY.money;
            light = GameManager.PARTY.light;
            bagInventory = new InventoryItem[20];
            for(int _i = 0; _i < 20; _i++)
            {
                bagInventory[_i] = GameManager.PARTY.bagInventory[_i];
            }
        }
    }

    public serialParty party = new serialParty(0);
    public int x_coor, y_coor, face;

    //level node inventory
    //treasure chest inventory
    //Monsters
}



/*Things to save
 * PC Name
 * PC Class
 * PC Level
 * PC XP
 * PC XP_NNL
 * PC Strength
 * PC Dexterity
 * PC Intelligence
 * PC Wisdom
 * PC Charisma
 * PC Health
 * PC Wounds
 * PC Mana
 * PC Drain
 * PC Defense
 * PC Attack
 * PC Portrait
 * PC head
 * PC neck
 * PC left finger
 * PC right finger
 * PC left hand
 * PC right hand
 * PC legs
 * PC feet 
 * (x4)
 * Party Wealth
 * Party Light
 * Party Inventory
 * Array of Node Inventory by level
 * Array of Treasure Chest Inventory by level
 * Monster Name
 * Monster Level
 * Monster Health
 * Monster Wounds
 * Monster Defense
 * Monster Attack
 * Monster Portrait
 * Monster Left Hand
 * Monster Right Hand
 * (repeat for each monster on current level)
 * (repeat for each boss that is still active)
 */
