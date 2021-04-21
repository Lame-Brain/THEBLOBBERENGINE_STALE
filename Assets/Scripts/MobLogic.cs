using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobLogic : MonoBehaviour
{
    [SerializeField] private Mob mob_template;
    public Mob.MobInstance mob_data;

    [HideInInspector] public GameObject moveTarget;
    public NavMeshAgent agent;

    public void InitializeMob()
    {
        mob_data = new Mob.MobInstance(mob_template);
        mob_data.UpdateCoords(transform.position.x, transform.position.z);
        if(transform.GetComponentInParent<Spawner>().Waypoint_List.Length > 0)
        {
            moveTarget = transform.GetComponentInParent<Spawner>().Waypoint_List[Random.Range(0, transform.GetComponentInParent<Spawner>().Waypoint_List.Length)].gameObject;
            agent.SetDestination(moveTarget.transform.position);
            agent.isStopped = false;
        }
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
                moveTarget = transform.GetComponentInParent<Spawner>().Waypoint_List[Random.Range(0, transform.GetComponentInParent<Spawner>().Waypoint_List.Length)].gameObject;
                agent.SetDestination(moveTarget.transform.position);
            }
        }
    }
}
