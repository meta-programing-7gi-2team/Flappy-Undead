using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverButton : MonoBehaviour
{
    private FadeManager fade;
    private PlayerController player;

    private void Start()
    {
        fade = FindObjectOfType<FadeManager>();
        player = FindObjectOfType<PlayerController>();
    }

    public void Menu()
    {
        GameManager.instance.Normal = false;
        GameManager.instance.Witch = false;
        GameManager.instance.Axe = false;
        GameManager.instance.Horn = false;
        player.GameOver_C();
        StartCoroutine(MenuMove_co());
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Rank()
    {
        if(!GameManager.instance.isRankReg)
        {
            GameManager.instance.isRankReg = true;
            RankManager.AddPlayerRank(GameManager.instance.Score);
        }
    }
    public void Rank_Close()
    {
        GameManager.instance.isRankRegClose = true;
    }

    private IEnumerator MenuMove_co()
    {
        fade.FadeOut();
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameMenu");
    }
}
