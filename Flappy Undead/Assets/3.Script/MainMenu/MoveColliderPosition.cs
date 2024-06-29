using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveColliderPosition : MonoBehaviour
{
    void Start()
    {
        // 예시: GameObject의 Mesh 위치 변경
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        // Mesh의 위치를 조정
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] += new Vector3(0f, 0.5f, 0f);
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds(); // Bounds 재계산 (필요한 경우)
    }
}
