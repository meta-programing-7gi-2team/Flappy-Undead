using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float scaleFactor = 1.2f;
    private Vector3 originalScale;
    private Color originalColor; // 원래 색상 저장용 변수

    [SerializeField] private AudioClip waitSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 마우스를 올렸을 때 해당 오브젝트의 transform 크기 증가
        transform.localScale = originalScale * scaleFactor;

        if (audioSource != null && waitSound != null)
        {
            audioSource.PlayOneShot(waitSound);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 마우스를 벗어났을 때 해당 오브젝트의 transform 크기 원래대로 복구
        transform.localScale = originalScale;
    }
}
