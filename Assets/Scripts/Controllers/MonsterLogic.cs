using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterLogic : MonoBehaviour
{
    [Header("Navigation Stuff")]
    public NavMeshAgent agent;
    public GameObject wayPoint;

    [Header("Stats")]
    public string NPC_Name;
    public int wounds;
    public int health;
    public int initBonus;
    public int bonusToHit;
    public int minDamage;
    public int maxDamage;
    public int defenseValue;

    public int monsterFaceIndex;
    public string monsterState;
    public string orders;
    private Animator ref_Animator;
    private int ordersIndex;
    private bool attackingPlayer;
    private float distanceToTarget;
    private float distanceToPlayer;


    private void Start()
    {
        ref_Animator = gameObject.GetComponentInChildren<Animator>();
        monsterState = "Awaiting Update";
        orders = "Awaiting Orders";
        GetNextWayPoint();
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, wayPoint.transform.position);
        distanceToPlayer = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        if (distanceToPlayer < 15f) attackingPlayer = true;
        if (distanceToPlayer > 15f) attackingPlayer = false;
        if (distanceToPlayer < 6) GameManager.EXPLORE.OpenBattleScreen();
    }

    private void GetNextWayPoint()
    {
        GameObject _wpm = transform.GetComponentInParent<SpawnController>().ref_AssignedWaypointCluster[Random.Range(0, transform.GetComponentInParent<SpawnController>().ref_AssignedWaypointCluster.Length)];
        if(_wpm.transform.childCount > 0) wayPoint = _wpm.transform.GetChild(Random.Range(0, _wpm.transform.childCount)).gameObject;
        agent.SetDestination(_wpm.transform.position);
        agent.isStopped = true;
    }

    public void TurnPasses()
    {
        if (monsterState == "Awaiting Update")
        {
            if(orders == "Awaiting Orders")
            {
                if (wayPoint == null || (Vector3.Distance(transform.position, wayPoint.transform.position) < 1.1f)) GetNextWayPoint();
                orders = wayPoint.GetComponent<WaypointController>().command[ordersIndex];
            }

            if (orders == "Pass Turn")
            {
                monsterState = "Finishing Orders";
            }

            if(orders == "Move To WayPoint")
            {
                monsterState = "Following Orders";
                agent.SetDestination(wayPoint.transform.position);
                agent.isStopped = true;
            }

            if (orders == "Go Home")
            {
                wayPoint = transform.parent.gameObject;
                orders = "Awaiting Update";
                monsterState = "Following Orders";
                agent.SetDestination(wayPoint.transform.position);
                agent.isStopped = true;
            }

            if(orders == "Attack Player")
            {
                wayPoint = GameObject.FindGameObjectWithTag("Player");
                orders = "Awaiting Update";
                monsterState = "Following Orders";
                agent.SetDestination(wayPoint.transform.position);
                agent.isStopped = true;
            }
        }

        if(monsterState == "Following Orders")
        {
            agent.isStopped = false;
            StartCoroutine(MoveForTime(1));
        }

        if(monsterState == "Finishing Orders")
        {
            ordersIndex++;
            if (wayPoint.GetComponent<WaypointController>() != null && ordersIndex > wayPoint.GetComponent<WaypointController>().command.Length)
            {
                monsterState = "Awaiting Update";
                ordersIndex = 0;
            }
            if(wayPoint.GetComponent<WaypointController>() == null)
            {
                wayPoint = null;
                monsterState = "Awaiting Update";
                ordersIndex = 0;
            }
        }

        IEnumerator MoveForTime(float n)
        {
            if (attackingPlayer) agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);

            ref_Animator.SetInteger("actorState", 1);

            yield return new WaitForSeconds(n);
            agent.isStopped = true;
            ref_Animator.SetInteger("actorState", 0);

            if (Vector3.Distance(transform.position, wayPoint.transform.position) < .5f)
            {
                monsterState = "Finishing Orders";
                orders = "Awaiting Orders";
                transform.rotation = wayPoint.transform.rotation;
            }
        }
    }
}
