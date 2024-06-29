using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveColliderPosition : MonoBehaviour
{
    void Start()
    {
        // ����: GameObject�� Mesh ��ġ ����
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        // Mesh�� ��ġ�� ����
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] += new Vector3(0f, 0.5f, 0f);
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds(); // Bounds ���� (�ʿ��� ���)
    }
}
