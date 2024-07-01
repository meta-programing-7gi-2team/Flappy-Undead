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
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Canvas rankRegistrationCanvas;
    [SerializeField] private GameObject HP_1;
    [SerializeField] private GameObject HP_2;
    [SerializeField] private GameObject HP_3;

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

    private void Start()
    {
        if (Health >= 1)
        {
            HP_1.SetActive(true);
        }
        if (Health >= 2)
        {
            HP_2.SetActive(true);
        }
        if (Health >= 3)
        {
            HP_3.SetActive(true);
        }
    }

    private void Update()
    {
        if (GameManager.instance.isPause) return;
        if (GameManager.instance.isRankReg && !GameManager.instance.isRankRegClose)
        {
            if (!rankRegistrationCanvas.gameObject.activeSelf)
            {
                rankRegistrationCanvas.gameObject.SetActive(true);
            }
            return;
        }
        if(GameManager.instance.isRankRegClose)
        {
            if (rankRegistrationCanvas.gameObject.activeSelf)
            {
                rankRegistrationCanvas.gameObject.SetActive(false);
                GameManager.instance.isPause = true;
            }
        }
        if (GameManager.instance.isGameOver)
        {
            if (!gameOver.gameObject.activeSelf)
            {
                gameOver.gameObject.SetActive(true);
                GameManager.instance.isGameOver = false;
            }
            return;
        }


        if (Input.GetMouseButtonDown(0))
        {
            Jump();
            if (GameManager.instance.isplayerjump)
            {
                GameManager.instance.isplayerjump = false;
                player_rid.isKinematic = false;
            }
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

        if (Health < 1) HP_1.SetActive(false);

        if (Health < 2) HP_2.SetActive(false);

        if (Health < 3) HP_3.SetActive(false);

        if (Health <= 0)
        {
            Dead();
            return;
        }
        player_au.PlayOneShot(hitClip);
    }
    public void Dead()
    {
        GameManager.instance.isGameOver = true;
        player_au.PlayOneShot(deathClip);
        Time.timeScale = 0f;
    }

    public void GameOver_C()
    {
        gameOver.SetActive(false);
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Score_Zone")) // 점수 획득
        {
            //TODO: 점수 2배 획득 캐릭터 설정 필요\
            if(data.Type.Equals(CharType.Axe))
                GameManager.instance.AddScore(2);
            else
                GameManager.instance.AddScore(1);
        }
        if (other.CompareTag("Obstacle")) // 장애물에 닿았을 시 피 감소
        {
            //TODO: 커진 상황에서 Health 감소가 일어나지 않게 조건 추가 필요
            if (transform.tag.Equals("Super") || transform.tag.Equals("Invisible")) return;
            OnDamage();
        }
        if (other.CompareTag("Floor")) // 바닥에 닿았을 시 게임오버
        {
            if (transform.tag.Equals("Super")) return;
            HP_1.SetActive(false);
            HP_2.SetActive(false);
            HP_3.SetActive(false);
            Time.timeScale = 0f;
            GameManager.instance.isGameOver = true;
        }
    }
}