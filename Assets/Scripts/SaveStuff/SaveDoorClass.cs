using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveDoorClass 
{
    public bool isOpen;
    public bool isLocked;
    public bool knownLocked;
    public float lock_level;
    public int IconIndex;
    public int SoundIndex;
    public int trapLevel, trapStrength, trapNum_Hit;
    public bool trapDark, trapPosion, trapStone, trapWeak, trapStrDisease, trapDexDisease, trapIQDisease, trapWisDisease, trapCharmDisease, trapHealthDisease;


    public SaveDoorClass(Hello_I_am_a_Door door)
    {
        this.isOpen = door.isOpen;
        this.isLocked = door.isLocked;
        this.knownLocked = door.knownLocked;
        this.IconIndex = door.IconIndex;
        this.SoundIndex = door.SoundIndex;
        this.trapLevel = door.trapLevel;
        this.trapNum_Hit = door.trapNum_Hit;
        this.trapStrength = door.trapStrength;
        this.trapDark = door.trapDark;
        this.trapPosion = door.trapPosion;
        this.trapStone = door.trapStone;
        this.trapWeak = door.trapWeak;
        this.trapStrDisease = door.trapStrDisease;
        this.trapDexDisease = door.trapDexDisease;
        this.trapIQDisease = door.trapIQDisease;
        this.trapWisDisease = door.trapWisDisease;
        this.trapCharmDisease = door.trapCharmDisease;
        this.trapHealthDisease = door.trapHealthDisease;
    }

    public Hello_I_am_a_Door LoadDoor(SaveDoorClass door)
    {
        Hello_I_am_a_Door _result = null;

        _result.isOpen = door.isOpen;
        _result.isLocked = door.isLocked;
        _result.knownLocked = door.knownLocked;
        _result.IconIndex = door.IconIndex;
        _result.SoundIndex = door.SoundIndex;
        _result.trapLevel = door.trapLevel;
        _result.trapNum_Hit = door.trapNum_Hit;
        _result.trapStrength = door.trapStrength;
        _result.trapDark = door.trapDark;
        _result.trapPosion = door.trapPosion;
        _result.trapStone = door.trapStone;
        _result.trapWeak = door.trapWeak;
        _result.trapStrDisease = door.trapStrDisease;
        _result.trapDexDisease = door.trapDexDisease;
        _result.trapIQDisease = door.trapIQDisease;
        _result.trapWisDisease = door.trapWisDisease;
        _result.trapCharmDisease = door.trapCharmDisease;
        _result.trapHealthDisease = door.trapHealthDisease;

        return _result;
    }
}
