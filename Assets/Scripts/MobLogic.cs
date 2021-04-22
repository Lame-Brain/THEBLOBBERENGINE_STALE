using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobLogic : MonoBehaviour
{
    public Mob mob_template;
    public Mob.MobInstance mob_data;    

    [HideInInspector] public GameObject moveTarget;
    public NavMeshAgent agent;

    public void InitializeMob()
    {
        mob_data = new Mob.MobInstance(mob_template);
        mob_data.xCoord = transform.localPosition.x;
        mob_data.xCoord = transform.localPosition.z;
        if (transform.GetComponentInParent<Spawner>().Waypoint_List.Length > 0)
        {
            int _length = transform.GetComponentInParent<Spawner>().Waypoint_List.Length;
            int _r = Random.Range(0, _length);
            moveTarget = transform.GetComponentInParent<Spawner>().Waypoint_List[_r].gameObject;
            mob_data.wp_index = _r;        
            agent.SetDestination(moveTarget.transform.position);
            agent.isStopped = true;
        }
    }

    public void LoadMob(SaveMobLogicClass mob)
    {
        mob_data = new Mob.MobInstance(mob_template);
        mob_data.xCoord = mob.xCoord; mob_data.yCoord = mob.yCoord;
        mob_data.mob_HP = mob.mob_HP;            
        mob_data.mob_Poisoned = mob.mob_Poisoned;
        mob_data.mob_Cursed = mob.mob_Cursed;
        mob_data.mob_Blinded = mob.mob_Blinded;
        mob_data.mob_Slowed = mob.mob_Slowed;
        mob_data.mob_Weakened = mob.mob_Weakened;
        mob_data.mob_Stoned = mob.mob_Stoned;
        mob_data.mob_Frog = mob.mob_Frog;        
        moveTarget = transform.parent.GetComponent<Spawner>().Waypoint_List[mob.wp_index].gameObject;
        //mob_data.UpdateCoords(transform.position.x, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, moveTarget.transform.position) < 1)
        {
            if(moveTarget.tag == "Waypoint")
            {
                moveTarget = transform.parent.gameObject;
                agent.SetDestination(moveTarget.transform.position);
            }
            else
            {
                int _randomTarget = Random.Range(0, transform.GetComponentInParent<Spawner>().Waypoint_List.Length);
                moveTarget = transform.GetComponentInParent<Spawner>().Waypoint_List[_randomTarget].gameObject;
                mob_data.wp_index = _randomTarget;
                agent.SetDestination(moveTarget.transform.position);
            }
        }
    }

    public void TurnPasses()
    {
        StartCoroutine(_TurnBasedMovement(1));
    }

    IEnumerator _TurnBasedMovement(float n)
    {
        agent.isStopped = false;

        yield return new WaitForSeconds(n);

        agent.isStopped = true;
        //mob_data.UpdateCoords(transform.position.x, transform.position.z);
    }
}
