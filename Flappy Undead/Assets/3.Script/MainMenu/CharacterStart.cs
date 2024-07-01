using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStart : MonoBehaviour
{
    [SerializeField] private GameObject Normal;
    [SerializeField] private GameObject Witch;
    [SerializeField] private GameObject Axe;
    [SerializeField] private GameObject Horn;
    private PlayerController player;

    private void Start()
    {
        if (GameManager.instance.Normal)
        {
            Normal.SetActive(true);
            Witch.SetActive(false);
            Axe.SetActive(false);
            Horn.SetActive(false);
            player = FindObjectOfType<PlayerController>();
            player.player_rid.isKinematic = true;
            GameManager.instance.isplayerjump = true;
        }

        if (GameManager.instance.Witch) 
        {
            Normal.SetActive(false);
            Witch.SetActive(true);
            Axe.SetActive(false);
            Horn.SetActive(false);
            player = FindObjectOfType<PlayerController>();
            player.player_rid.isKinematic = true;
            GameManager.instance.isplayerjump = true;
        }

        if (GameManager.instance.Axe)
        {
            Normal.SetActive(false);
            Witch.SetActive(false);
            Axe.SetActive(true);
            Horn.SetActive(false);
            player = FindObjectOfType<PlayerController>();
            player.player_rid.isKinematic = true;
            GameManager.instance.isplayerjump = true;
        }

        if (GameManager.instance.Horn)
        {
            Normal.SetActive(false);
            Witch.SetActive(false);
            Axe.SetActive(false);
            Horn.SetActive(true);
            player = FindObjectOfType<PlayerController>();
            player.player_rid.isKinematic = true;
            GameManager.instance.isplayerjump = true;
        }

    }
}
