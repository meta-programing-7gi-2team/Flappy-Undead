using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    private PlayerController playercontroller;
    private GameObject hero; // ��� ������Ʈ

    public GameObject PausePanel;
    public Text CountdownText;
    public FadeManager fade;

    private void Start()
    {
        playercontroller = FindObjectOfType<PlayerController>();
        hero = GameObject.FindGameObjectWithTag("Hero"); // ��� ������Ʈ
        fade = FindObjectOfType<FadeManager>();
        GameManager.instance.ResetScore();
        GameManager.instance.isGameOver = false;
    }

    public void Play()
    {
        if(!GameManager.instance.isGameOver)
        {
            StartCoroutine(playercontroller.PlayCountdown());
        }    
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        playercontroller.player_rid.isKinematic = false;
        GameManager.instance.isPause = false;
        GameManager.instance.ResetScore();
        GameManager.instance.isGameOver = false;
    }

    public void Menu()
    {
        //TODO: �ִϸ��̼� ������ ���� �ʿ�
        playercontroller.player_rid.isKinematic = false;
        GameManager.instance.isPause = false;
        GameManager.instance.Normal = false;
        GameManager.instance.Witch = false;
        GameManager.instance.Axe = false;
        GameManager.instance.Horn = false;
        Time.timeScale = 1f;
        fade.FadeOut();
        StartCoroutine(MenuMove_co());
    }

    private IEnumerator MenuMove_co()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameMenu");
    }

}
