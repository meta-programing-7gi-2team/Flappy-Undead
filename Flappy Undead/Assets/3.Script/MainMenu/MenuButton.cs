using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public GameObject Ranking_;
    public bool Rankingbutten;

    public void Ranking()
    {
        if(Rankingbutten)
        {
            Ranking_.SetActive(false);
            Rankingbutten = false;
        }
        else
        {
            Ranking_.SetActive(true);
            Rankingbutten = true;
        }
    }

    public void Ranking_Exit()
    {

        Ranking_.SetActive(false);
        Rankingbutten = false;
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
