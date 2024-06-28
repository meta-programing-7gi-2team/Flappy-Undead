using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll_Obstacle : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float leftBound = -10.0f;

    private void Update()
    {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        if (transform.position.z < leftBound)
        {
            ObstacleSpawner spawner = FindObjectOfType<ObstacleSpawner>();
            if (spawner != null)
            {
                spawner.ReturnObstacle(gameObject);
            }
        }
    }
}
