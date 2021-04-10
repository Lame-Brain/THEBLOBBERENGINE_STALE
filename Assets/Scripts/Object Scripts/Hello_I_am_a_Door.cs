using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello_I_am_a_Door : MonoBehaviour
{
    public bool isOpen;
    public bool isLocked;
    public bool knownLocked;
    public float lock_level;
    public int IconIndex;
    public int SoundIndex;

    private void Start()
    {
        if (isOpen) gameObject.SetActive(true);
    }

    public void Interact_With_Me()
    {
        bool _interacted = false;
        if(!_interacted && isOpen) //Close the door
        {
            _interacted = true;
            transform.Find("Door").gameObject.SetActive(true);
            isOpen = false;
            //TO DO: play closing sound
        }

        if(!_interacted && !isOpen && !isLocked) //Open the Unlocked Door
        {
            _interacted = true;
            transform.Find("Door").gameObject.SetActive(false);
            isOpen = true;
            //TO DO: Play Opening sound
        }
        if(_interacted && !isOpen && isLocked) //Learn the door is locked
        {
            _interacted = true;
            knownLocked = true;
            //TO DO: play door rattle sound
        }
        //GameManager.PARTY.FinishInteracting();
    }
}
