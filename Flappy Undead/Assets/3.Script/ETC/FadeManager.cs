using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    [SerializeField] private bool isFadeIn;
    [SerializeField] private GameObject panel;
    private bool isFadeing = false;

    private void Start()
    {
        if (!panel)
        {
            Debug.LogError("Fade를 진행할 Panel이 없습니다.");
        }
        if (isFadeIn)
        {
            panel.SetActive(true);
            StartCoroutine(FadeIn_Co());
        }
        else
        {
            panel.SetActive(false);
        }
    }

    public void FadeIn()
    {
        if (!isFadeing)
        {
            isFadeing = true;
            panel.SetActive(true);
            StartCoroutine(FadeIn_Co());
        }
    }

    public void FadeOut()
    {
        if (!isFadeing)
        {
            isFadeing = true;
            panel.SetActive(true);
            StartCoroutine(FadeOut_Co());
        }
    }

    private IEnumerator FadeIn_Co()
    {
        float elapsedTime = 0f;
        float fadeTime = 1f;

        while (elapsedTime <= fadeTime)
        {
            panel.GetComponent<CanvasRenderer>().SetAlpha(Mathf.Lerp(1f, 0f, elapsedTime / fadeTime));

            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        isFadeing = false;
        panel.SetActive(false);
        yield break;
    }

    private IEnumerator FadeOut_Co()
    {
        float elapsedTime = 0f;
        float fadeTime = 1f;

        while (elapsedTime <= fadeTime)
        {
            panel.GetComponent<CanvasRenderer>().SetAlpha(Mathf.Lerp(0f, 1f, elapsedTime / fadeTime));

            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        isFadeing = false;
        yield break;
    }
}
