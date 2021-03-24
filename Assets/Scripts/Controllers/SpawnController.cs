using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject ref_mobPF;
    public int minTimeToSpawn, maxTimeToSpawn, MaxNumberOfSpawns, startingNumberOfSpawns;
    public float offsetRadius;
    public int wanderingMonster_MinPackSize, wanderingMonster_MaxPackSize;
    public float WanderingMonster_Frequency;

    private int timer, alarm;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetAlarm();
        for (int _i = 0; _i < startingNumberOfSpawns; _i++) SpawnMob();
        
    }

    private void SpawnMob()
    {         
        if((transform.childCount - 1) < MaxNumberOfSpawns && (Vector3.Distance(transform.position, player.transform.position) > 15f)) //Wont Spawn if the player is too close, or there are too many spawns already
            Instantiate(ref_mobPF, new Vector3(transform.position.x + Random.Range(0f, offsetRadius), 1.4f, transform.position.x + Random.Range(0f, offsetRadius)), Quaternion.identity, transform);
    }
    private void SetAlarm()
    {
        timer = 0;
        alarm = Random.Range(minTimeToSpawn, maxTimeToSpawn);
    }

    public void TurnPasses()
    {
        timer++;
        if(timer > alarm)
        {
            SetAlarm();
            SpawnMob();
        }
    }
}
