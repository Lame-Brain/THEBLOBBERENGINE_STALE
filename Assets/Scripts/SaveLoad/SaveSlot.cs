using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveSlot
{
    [System.Serializable]
    public struct serialItem
    {
        public string genericName, fullName, description, lore;
        public InventoryItem.slotType slot;
        public InventoryItem.equipType type;
        public bool identified, magical, fragile, twoHanded, active;
        public int minDamage, maxDamage, fullCharges, maxDuration, quality;
        public int currentCharges, currentDuration;
        public float defense, critMultiplier, value;
        public int itemIconIndex;

        public serialItem(InventoryItem i)
        {
            genericName = "";
            fullName = "";
            description = "";
            lore = "";
            slot = 0;
            type = 0;
            identified = false;
            magical = false;
            fragile = false;
            twoHanded = false;
            active = false;
            minDamage = 0;
            maxDamage = 0;
            fullCharges = 0;
            maxDuration = 0;
            quality = 0;
            currentCharges = 0;
            currentDuration = 0;
            defense = 0;
            critMultiplier = 0;
            value = 0;
            itemIconIndex = 0;
            if (i != null)
            {
                genericName = i.genericName;
                fullName = i.fullName;
                description = i.description;
                lore = i.lore;
                slot = i.slot;
                type = i.type;
                identified = i.identified;
                magical = i.magical;
                fragile = i.fragile;
                twoHanded = i.twoHanded;
                active = i.active;
                minDamage = i.minDamage;
                maxDamage = i.maxDamage;
                fullCharges = i.fullCharges;
                maxDuration = i.maxDuration;
                quality = i.quality;
                currentCharges = i.currentCharges;
                currentDuration = i.currentDuration;
                defense = i.defense;
                critMultiplier = i.critMultiplier;
                value = i.value;
                itemIconIndex = i.itemIconIndex;
            }
        }
    }
    [System.Serializable]
    public struct serialCharacter
    {
        public string characterName;
        public Character.characterClass type;
        public int xpLevel, xpPoints, xpNNL, freePoints;
        public int strength, dexterity, intelligence, wisdom, charisma;
        public float health, wounds, mana, drain, defense, attack;
        public int portraitIndex;
        public serialItem eq_Head, eq_Neck, eq_LeftFinger, eq_RightFinger, eq_LeftHand, eq_RightHand, eq_Torso, eq_Legs, eq_Feet;

        public serialCharacter(int n)
        {
            characterName = GameManager.PARTY.PC[n].characterName;
            type = GameManager.PARTY.PC[n].type;
            xpLevel = GameManager.PARTY.PC[n].xpLevel; xpPoints = GameManager.PARTY.PC[n].xpPoints; xpNNL = GameManager.PARTY.PC[n].xpNNL; freePoints = GameManager.PARTY.PC[n].freePoints;
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
            eq_Head = new serialItem(GameManager.PARTY.PC[n].eq_Head);
            eq_Neck = new serialItem(GameManager.PARTY.PC[n].eq_Neck);
            eq_LeftFinger = new serialItem(GameManager.PARTY.PC[n].eq_LeftFinger);
            eq_RightFinger = new serialItem(GameManager.PARTY.PC[n].eq_RightFinger);
            eq_LeftHand = new serialItem(GameManager.PARTY.PC[n].eq_LeftHand);
            eq_RightHand = new serialItem(GameManager.PARTY.PC[n].eq_RightHand);
            eq_Torso = new serialItem(GameManager.PARTY.PC[n].eq_Torso);
            eq_Legs = new serialItem(GameManager.PARTY.PC[n].eq_Legs);
            eq_Feet = new serialItem(GameManager.PARTY.PC[n].eq_Feet); 
        }
    }
    [System.Serializable]
    public struct serialParty
    {
        public serialCharacter[] PC;
        public int money; 
        public int light;
        public serialItem[] bagInventory;

        public serialParty(int n)
        {
            PC = new serialCharacter[4];
            for(int _i = 0; _i < 4; _i++)
            {
                PC[_i] = new serialCharacter(_i);
            }
            money = GameManager.PARTY.money;
            light = GameManager.PARTY.light;
            bagInventory = new serialItem[20];
            for(int _i = 0; _i < 20; _i++)
            {
                bagInventory[_i] = new serialItem(GameManager.PARTY.bagInventory[_i]);
            }
        }
    }
    public serialParty party = new serialParty(0);
    public int x_coor, y_coor, face;

    //TO DO: level node inventory
    //TO DO: treasure chest inventory
    //TO DO: Monsters
}