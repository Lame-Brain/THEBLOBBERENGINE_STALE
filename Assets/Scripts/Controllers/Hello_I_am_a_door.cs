using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello_I_am_a_door : MonoBehaviour
{
    public bool doorOpen;
    public float lockValue;
    public int IconIndex;

    public void InteractWithMe()
    {
        doorOpen = true;
        transform.gameObject.SetActive(false);
    }
}
