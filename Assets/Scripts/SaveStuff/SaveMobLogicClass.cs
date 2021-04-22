using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveMobLogicClass 
{
    public float xCoord, yCoord;
    public int mob_HP;
    public bool mob_Poisoned;
    public bool mob_Cursed;
    public bool mob_Blinded;
    public bool mob_Slowed; 
    public bool mob_Weakened;
    public bool mob_Stoned;
    public bool mob_Frog;
    public int wp_index;

    public SaveMobLogicClass(MobLogic mob)
    {
        this.xCoord = mob.mob_data.xCoord;
        this.yCoord = mob.mob_data.yCoord;
        this.mob_HP = mob.mob_data.mob_HP;
        this.mob_Poisoned = mob.mob_data.mob_Poisoned;
        this.mob_Cursed = mob.mob_data.mob_Cursed;
        this.mob_Blinded = mob.mob_data.mob_Blinded;
        this.mob_Slowed = mob.mob_data.mob_Slowed;
        this.mob_Weakened = mob.mob_data.mob_Weakened;
        this.mob_Stoned = mob.mob_data.mob_Stoned;
        this.mob_Frog = mob.mob_data.mob_Frog;
        this.wp_index = mob.mob_data.wp_index;
    }

}
