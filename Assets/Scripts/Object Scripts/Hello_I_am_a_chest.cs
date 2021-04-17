using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello_I_am_a_chest : MonoBehaviour
{
    public Item[] inventory = new Item[16];
    public bool isLocked, isTrapped;
    public int lockLevel, trapLevel;
}
