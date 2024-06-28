using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //private 


   private void OnTriggerEnter(Collider other)
   {
        if (other.tag == "Player")
        {

        }
   }

}
