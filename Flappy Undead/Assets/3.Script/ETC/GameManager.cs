using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPause; // �Ͻ������߿� ���� ������ϹǷ� ������ �κ�
    public bool Normal;
    public bool Witch;
    public bool Axe;
    public bool Horn;
    public bool isGameOver = false;
    public bool isRankReg = false;
    public bool isRankRegClose = false;
    public bool isplayerjump = false;
    public int Score { get; private set; } // ����

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
