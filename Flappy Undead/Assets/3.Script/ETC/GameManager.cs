using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPause; // 일시정지중에 모든게 멈춰야하므로 만들어둔 부분
    public bool Normal;
    public bool Witch;
    public bool Axe;
    public bool Horn;
    public bool isGameOver = false;
    public bool isRankReg = false;
    public bool isRankRegClose = false;
    public bool isplayerjump = false;
    public int Score { get; private set; } // 점수

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ResetScore()
    {
        Score = 0;
    }
    public void AddScore(int score)
    {
        this.Score += score;
    }
}
