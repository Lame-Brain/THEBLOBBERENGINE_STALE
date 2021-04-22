using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner: MonoBehaviour
{
    public GameObject ref_MobPF;
    public int initialSpawnNumber, minSpawnTime, maxSpawnTime, minSpawnNumber, maxSpawnNumber;
    public float SpawnDistribution;

    public Waypoint[] Waypoint_List;

    [SerializeField] public int timer;

    public void InitialSpawn()
    {
        GameObject _go = null;
        //Spawn Initial Mobs
        for (int _i = 0; _i < initialSpawnNumber; _i++)
        {
            float _xAdjust = (Random.Range(0, SpawnDistribution) * 2) - SpawnDistribution;
            float _yAdjust = (Random.Range(0, SpawnDistribution) * 2) - SpawnDistribution;
            _go = Instantiate(ref_MobPF, transform);
            _go.GetComponent<MobLogic>().InitializeMob();
            _go.transform.localPosition = new Vector3(_xAdjust, _go.transform.position.y, _yAdjust);
            _go.GetComponent<MobLogic>().mob_data.xCoord = _xAdjust;
            _go.GetComponent<MobLogic>().mob_data.yCoord = _yAdjust;
            Debug.Log("Placed mob here: " + _xAdjust + ", " + _yAdjust);
        }
    }
}
