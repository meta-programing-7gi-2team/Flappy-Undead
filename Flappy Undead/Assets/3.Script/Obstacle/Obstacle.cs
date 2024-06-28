using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Text score;

   private void OnTriggerEnter(Collider other)
   {
        if (other.tag == "Player")
        {
            //score.text=
        }

        if(other.tag == "Score_Zone")
        {

        }
   }

}
