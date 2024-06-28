using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll_Obstacle : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;

    private void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
    }




}
