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
            Debug.Log("�浹");
        }

        if(other.tag == "Score_Zone")
        {
            Debug.Log("���ھ� �浹");
        }
   }

}
