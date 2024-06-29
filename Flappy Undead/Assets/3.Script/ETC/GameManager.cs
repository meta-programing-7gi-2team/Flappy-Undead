using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPause; // 일시정지중에 모든게 멈춰야하므로 만들어둔 부분
    public Text CountdownText;

    private PlayerController playercontroller;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            playercontroller = FindObjectOfType<PlayerController>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator PlayCountdown()
    {
        playercontroller.PausePanel.SetActive(false);
        CountdownText.gameObject.SetActive(true);
        int count = 3;
        while (count > 0)
        {
            CountdownText.text = count.ToString();
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }

        CountdownText.text = "Go!";
        yield return new WaitForSecondsRealtime(0.5f);

        CountdownText.gameObject.SetActive(false);

        playercontroller.StartPlayerMovement();
    }

}
