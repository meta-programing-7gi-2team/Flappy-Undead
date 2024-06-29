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
}
