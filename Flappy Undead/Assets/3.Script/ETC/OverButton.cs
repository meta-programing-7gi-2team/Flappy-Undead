using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverButton : MonoBehaviour
{
    private FadeManager fade;

    private void Start()
    {
        fade = FindObjectOfType<FadeManager>();
    }

    public void Menu()
    {
        GameManager.instance.Normal = false;
        GameManager.instance.Witch = false;
        GameManager.instance.Axe = false;
        GameManager.instance.Horn = false;
        Time.timeScale = 1f;
        fade.FadeOut();
        StartCoroutine(MenuMove_co());
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
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameMenu");
    }
}
