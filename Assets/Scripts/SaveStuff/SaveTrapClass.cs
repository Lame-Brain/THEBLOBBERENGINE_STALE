using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveTrapClass
{
    public int trapLevel, trapStrength, trapNum_Hit;
    public bool trapDark, trapPosion, trapStone, trapWeak, trapStrDisease, trapDexDisease, trapIQDisease, trapWisDisease, trapCharmDisease, trapHealthDisease;

    public SaveTrapClass(GridNode _gn)
    {
        this.trapLevel = _gn.trapLevel;
        this.trapStrength = _gn.trapStrength;
        this.trapNum_Hit = _gn.trapNum_Hit;
        this.trapDark = _gn.trapDark;
        this.trapPosion = _gn.trapPosion;
        this.trapStone = _gn.trapStone;
        this.trapWeak = _gn.trapWeak;
        this.trapStrDisease = _gn.trapStrDisease;
        this.trapDexDisease = _gn.trapDexDisease;
        this.trapIQDisease = _gn.trapIQDisease;
        this.trapWisDisease = _gn.trapWisDisease;
        this.trapCharmDisease = _gn.trapCharmDisease;
        this.trapHealthDisease = _gn.trapHealthDisease;
    }
}
