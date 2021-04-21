using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner: MonoBehaviour
{
    public GameObject ref_MobPF;
    public int initialSpawnNumber, minSpawnTime, maxSpawnTime, minSpawnNumber, maxSpawnNumber;
    public float minSpawnDistribution, maxSpawnDistribution;

    public Waypoint[] Waypoint_List;

    [SerializeField] public int timer;

    private void Start()
    {
        GameObject _go = null;
        //Spawn Initial Mobs
        for(int _i = 0; _i < initialSpawnNumber; _i++)
        {
            float _xAdjust = Random.Range(minSpawnDistribution * 2 - minSpawnDistribution, maxSpawnDistribution * 2 - maxSpawnDistribution);
            float _yAdjust = Random.Range(minSpawnDistribution * 2 - minSpawnDistribution, maxSpawnDistribution * 2 - maxSpawnDistribution);
            _go = Instantiate(ref_MobPF, transform);
            _go.GetComponent<MobLogic>().InitializeMob();
            _go.transform.position = new Vector3(_go.transform.position.x + _xAdjust, _go.transform.position.y, _go.transform.position.z + _yAdjust);
        }
    }
}
