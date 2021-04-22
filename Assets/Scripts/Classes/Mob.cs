using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Monster")]
public class Mob : ScriptableObject
{
    public enum Behavior { aggresive, disinterested, defensive }
    public enum Flavor {  wanderer, monster_nest, NPC }
    public string mob_Name;
    public Behavior mob_Behavior;
    public Flavor mob_Flavor;
    public int mob_Level, mob_XP_Reward;
    public int mob_Max_HP;
    public int mob_Attack, mob_Min_Damage, mob_Max_Damage, mob_Defense; //Standard attack and defense

    public float breath_Chance; //<--- Breath attacks damage the whole party
    public int breath_Min_Damage, breath_Max_Damage;

    public float inflict_Chance; //<--- Chance that mob inflicts a condition on a succesful attacks.

    public bool inflict_Curse; //These are the conditons that can be inflicted.
    public bool inflict_Poison;
    public bool inflict_Paralyze;
    public bool inflict_Stone;
    public bool inflict_Frog;
    public bool inflict_Weak;
    public bool inflict_Slow;
    public bool inflict_ManaSever;
    public bool inflict_STR_Disease;
    public bool inflict_DEX_Disease;
    public bool inflict_IQ_Disease;
    public bool inflict_WIS_Disease;
    public bool inflict_Charm_Disease;
    public bool inflict_Health_Disease;

    public int mob_Graphic_index, mob_Ambient_index, mob_AttackSound_index, mob_DefendSound_index;


    [System.Serializable]
    public class MobInstance
    {
        public Mob mob;
        public float xCoord, yCoord;
        public int mob_HP;
        //Mob Conditions work differently than character conditons
        public bool mob_Poisoned; //Mob loses health each round in battle
        public bool mob_Cursed; //Mob gets 25% penalty to attack and damage
        public bool mob_Blinded; //Mob gets 50% penalty to attack
        public bool mob_Slowed; //Mob gets penalty to initiative rolls
        public bool mob_Weakened; //Mob gets 50% penalty damage
        public bool mob_Stoned;
        public bool mob_Frog;
        public int wp_index;

        public MobInstance(Mob _mob)
        {
            this.mob = _mob;
            this.xCoord = 0; this.yCoord = 0;
            this.mob_HP = this.mob.mob_Max_HP;
            this.mob_Poisoned = false;
            this.mob_Cursed = false;
            this.mob_Blinded = false;
            this.mob_Slowed = false;
            this.mob_Weakened = false;
            this.mob_Stoned = false;
            this.mob_Frog = false;
            this.wp_index = 0;            
        }
/*        public void UpdateCoords(float x, float y)
        {
            this.xCoord = x;
            this.yCoord = y;
        } */
    }
}
