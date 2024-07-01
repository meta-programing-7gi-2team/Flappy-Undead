using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Loop : MonoBehaviour
{
    [SerializeField] private bool isBack = false; // �ڷ� �̵����� ����
    [SerializeField] private float panelSize = 20f; // �ڷ� �̵����� ����
    public float scrollSpeed = 2f; // �̵� �ӵ�
    public float panelDepth; // �г��� ���� ����

    private float startZ; // �г��� ���� ��ġ

    void Start()
    {
        // �г��� ���� ��ġ�� �����մϴ�.
        startZ = transform.position.z;
    }

    void Update()
    {
        if (GameManager.instance.isplayerjump)
            return;
        // �г��� �̵���ŵ�ϴ�.
        Vector3 direction = isBack ? Vector3.back : Vector3.forward;
        transform.Translate(direction * scrollSpeed * Time.deltaTime);

        // �г��� ��踦 �Ѿ�� ���ġ�մϴ�.
        if (transform.position.z < startZ - panelDepth)
        {
            RepositionPanel();
        }
    }

    void RepositionPanel()
    {
        // �г��� �ݴ��� ���� ���ġ�մϴ�.
        transform.position = new Vector3(transform.position.x, transform.position.y, panelSize);
    }
}
