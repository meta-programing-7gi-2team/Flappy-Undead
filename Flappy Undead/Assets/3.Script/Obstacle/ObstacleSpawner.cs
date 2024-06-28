using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private int poolCount = 4;
    [SerializeField] private float TimeSpawn_Min = 1.25f;
    [SerializeField] private float TimeSpawn_Max = 2.25f;
    private float TimeSpawn;

    [SerializeField] private float X_Pos = 0f;

    [SerializeField] private float Ypos_min = -0.7f;
    [SerializeField] private float Ypos_max = 0.5f;

    [SerializeField] private float Z_Start_Pos = 0f;
    [SerializeField] private float Z_Spawn_Interval = 2.0f;

    private GameObject[] Obstacles;
    private int Current_arr_index = 0;

    private Vector3 PoolPosition = new Vector3(0, -25f, 0);
    private float LastSpawnTime;
    private float Z_Pos;

    private void Start()
    {
        Obstacles = new GameObject[poolCount];

        for(int i=0; i<Obstacles.Length; i++)
        {
            Obstacles[i] = Instantiate(obstaclePrefab, PoolPosition, Quaternion.identity);
        }
        LastSpawnTime = 0;
        TimeSpawn = 0;
        Z_Pos = Z_Start_Pos;
}

    private void Update()
    {
        if (Time.time >= LastSpawnTime + TimeSpawn)
        {
            LastSpawnTime = Time.time;
            TimeSpawn = Random.Range(TimeSpawn_Min, TimeSpawn_Max);

            float Ypos = Random.Range(Ypos_min, Ypos_max);

            Obstacles[Current_arr_index].SetActive(false);
            Obstacles[Current_arr_index].SetActive(true);

            Obstacles[Current_arr_index].transform.position = new Vector3(X_Pos, Ypos, Z_Pos);
            Z_Pos += Z_Spawn_Interval;
            Current_arr_index++;
            if (Current_arr_index >= poolCount)
            {
                Current_arr_index = 0;
            }
        }
    }
}
