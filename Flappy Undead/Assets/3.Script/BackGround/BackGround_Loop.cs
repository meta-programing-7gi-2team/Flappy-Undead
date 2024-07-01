using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Loop : MonoBehaviour
{
    [SerializeField] private bool isBack = false; // 뒤로 이동할지 여부
    [SerializeField] private float panelSize = 20f; // 뒤로 이동할지 여부
    public float scrollSpeed = 2f; // 이동 속도
    public float panelDepth; // 패널의 깊이 길이

    private float startZ; // 패널의 시작 위치

    void Start()
    {
        // 패널의 시작 위치를 설정합니다.
        startZ = transform.position.z;
    }

    void Update()
    {
        if (GameManager.instance.isplayerjump)
            return;
        // 패널을 이동시킵니다.
        Vector3 direction = isBack ? Vector3.back : Vector3.forward;
        transform.Translate(direction * scrollSpeed * Time.deltaTime);

        // 패널이 경계를 넘어가면 재배치합니다.
        if (transform.position.z < startZ - panelDepth)
        {
            RepositionPanel();
        }
    }

    void RepositionPanel()
    {
        // 패널을 반대쪽 경계로 재배치합니다.
        transform.position = new Vector3(transform.position.x, transform.position.y, panelSize);
    }
}
