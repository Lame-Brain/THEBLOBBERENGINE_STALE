using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Spell")]
public class Spell : ScriptableObject
{
    public string spellName;
    public string spellInvoke;
    public string spellDescription;
    public int spellLevel;
    [Header ("Targets: 0 = self, 1 = party, 2 = single target, 3 = all enemies")]
    public int target;
    [Header("spell tags")]
    public bool Holy;
    public bool Arcane;
    public bool Light;
    public bool Fire;
    public bool Ice;
    public bool Shock;
    public bool Poison;
    public bool Life;
    public bool Void;
}
