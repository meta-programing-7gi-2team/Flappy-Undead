using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private int initialObstacles = 7;
    [SerializeField] private int poolCount = 15;
    [SerializeField] private float spawnInterval = 2.0f;
    private Queue<GameObject> poolQueue;
    private float timer = 0;

    private void Start()
    {
        InitializePool();
        for (int i = 0; i < initialObstacles; i++)
        {
            SpawnObstacle();
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnInterval)
        {
            SpawnObstacle();
            timer = 0;
        }
    }

    private void InitializePool()
    {
        poolQueue = new Queue<GameObject>();

        for (int i = 0; i < poolCount; i++)
        {
            GameObject obj = Instantiate(obstaclePrefab);
            obj.SetActive(false);
            poolQueue.Enqueue(obj);
        }
    }

    private void SpawnObstacle()
    {
        if (poolQueue.Count > 0)
        {
            GameObject obstacle = poolQueue.Dequeue();
            obstacle.transform.position = new Vector3(0, 0, -2.2f);
            obstacle.SetActive(true);
        }
        else
        {
            GameObject obstacle = Instantiate(obstaclePrefab);
            obstacle.transform.position = new Vector3(0, 0, -2.2f);
        }
    }

    public void ReturnObstacle(GameObject obstacle)
    {
        obstacle.SetActive(false);
        poolQueue.Enqueue(obstacle);
    }
}
