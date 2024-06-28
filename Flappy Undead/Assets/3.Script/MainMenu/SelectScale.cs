using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float scaleFactor = 1.2f;
    private Vector3 originalScale;
    private Color originalColor; // ���� ���� ����� ����

    [SerializeField] private AudioClip waitSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // ���콺�� �÷��� �� �ش� ������Ʈ�� transform ũ�� ����
        transform.localScale = originalScale * scaleFactor;

        if (audioSource != null && waitSound != null)
        {
            audioSource.PlayOneShot(waitSound);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // ���콺�� ����� �� �ش� ������Ʈ�� transform ũ�� ������� ����
        transform.localScale = originalScale;
    }
}
