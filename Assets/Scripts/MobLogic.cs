using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobLogic : MonoBehaviour
{
    [SerializeField] private Mob mob_template;
    public Mob.MobInstance mob_data;

    public void InitializeMob()
    {
        mob_data = new Mob.MobInstance(mob_template);
        mob_data.UpdateCoords(transform.position.x, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
