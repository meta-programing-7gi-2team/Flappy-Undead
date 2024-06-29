using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    private PlayerController playercontroller;

    public GameObject PausePanel;
    public Text CountdownText;
    public FadeManager fade;

    private void Start()
    {
        playercontroller = FindObjectOfType<PlayerController>();
        fade = FindObjectOfType<FadeManager>();
    }

    public void Play()
    {
        StartCoroutine(playercontroller.PlayCountdown());
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        playercontroller.player_rid.isKinematic = false;
        GameManager.instance.isPause = false;
    }

    public void Menu()
    {
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
