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
    }
}
