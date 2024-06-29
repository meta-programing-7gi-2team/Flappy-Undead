using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class PlayerController : MonoBehaviour
{
    public Player_Data data;
    public float Speed = 5f;
    public int Health = 2;

    public Rigidbody player_rid;
    public AudioSource player_au;
    private PauseButton pause;

    public AudioClip jumpClip;
    public AudioClip hitClip;
    public AudioClip deathClip;

    private void Awake()
    {
        player_rid = GetComponent<Rigidbody>();
        player_au = GetComponent<AudioSource>();
        TryGetComponent(out pause);

        Speed = data.Speed;
        Health = data.Health;
    }

    private void Update()
    {
        if (GameManager.instance.isPause) return;

        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause.PausePanel.activeSelf)
            {
                pause.PausePanel.SetActive(true);
                player_rid.isKinematic = true;
                GameManager.instance.isPause = true;
                Time.timeScale = 0f;
            }
        }
    }
    public void Jump()
    {
        player_rid.velocity = Vector3.up * Speed;
        player_au.PlayOneShot(jumpClip);
    }
    public void OnDamage()
    {
        Health--;
        if(Health <= 0)
        {
            Dead();
            return;
        }
        player_au.PlayOneShot(hitClip);
    }
    public void Dead()
    {
        player_au.PlayOneShot(deathClip);
    }

    public IEnumerator PlayCountdown()
    {
        pause.PausePanel.SetActive(false);
        pause.CountdownText.gameObject.SetActive(true);
        int count = 3;
        while (count > 0)
        {
            pause.CountdownText.text = count.ToString();
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }

        pause.CountdownText.text = "Go!";
        yield return new WaitForSecondsRealtime(0.5f);

        pause.CountdownText.gameObject.SetActive(false);
    
        StartPlayerMovement();
    }

    public void StartPlayerMovement()
    {
        player_rid.isKinematic = false;
        GameManager.instance.isPause = false;
        Time.timeScale = 1f;
    }
}