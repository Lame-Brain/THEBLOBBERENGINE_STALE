using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveChestClass
{
    public int xCoord, yCoord;
    public float rotX, rotY, rotZ, rotW;
    public SaveItemClass[] inventory = new SaveItemClass[16];
}
