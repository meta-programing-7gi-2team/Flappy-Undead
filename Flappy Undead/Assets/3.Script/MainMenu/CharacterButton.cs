using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterButton : MonoBehaviour
{
    private FadeManager fade;

    public GameObject Character;

    private void Start()
    {
        fade = FindObjectOfType<FadeManager>();
    }

    public void Character_Open()
    {
        Character.SetActive(true);
    }

    public void Character_Exit()
    {
        Character.SetActive(false);
    }

    public void SelectNormal()
    {
        GameManager.instance.Normal = true;
        fade.FadeOut();
        StartCoroutine(GameMove_co());
    }

    public void SelectWitch()
    {
        GameManager.instance.Witch = true;
        fade.FadeOut();
        StartCoroutine(GameMove_co());
    }

    public void SelectAxe()
    {
        GameManager.instance.Axe = true;
        fade.FadeOut();
        StartCoroutine(GameMove_co());
    }

    public void SelectHorn()
    {
        GameManager.instance.Horn = true;
        fade.FadeOut();
        StartCoroutine(GameMove_co());
    }

    private IEnumerator GameMove_co()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainScene");
    }
}
