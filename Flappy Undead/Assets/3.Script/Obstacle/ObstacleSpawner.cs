using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;

    [SerializeField] private float timeDiff;
    [SerializeField] private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1)
        {
            Instantiate(obstaclePrefab);
            timer = 0;
        }
    }

   //private void SpawnObstacle()
   //{
   //    float yOffset = Random.Range(-heightOffset, heightOffset);
   //    Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + yOffset, 0);
   //    Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
   //}





}
