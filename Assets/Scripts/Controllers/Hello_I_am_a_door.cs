using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello_I_am_a_door : MonoBehaviour
{
    public bool doorOpen, knownLocked;
    public float lockValue;
    public int IconIndex;

    private void Start()
    {
        if (doorOpen) transform.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!knownLocked) IconIndex = 27;
        if (knownLocked) IconIndex = 30;
    }

    public void InteractWithMe()
    {
        if (lockValue == 0)
        {
            doorOpen = true;
            transform.gameObject.SetActive(false);
        }
    }
}
