using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Loop : MonoBehaviour
{
    public GameObject[] tiles;
    public float tileWidth;
    private Transform playerTransform;
    private Vector3 lastTileEnd;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        lastTileEnd = tiles[tiles.Length - 1].transform.position + new Vector3(tileWidth, 0, 0);
    }
    void Update()
    {
        if (playerTransform.position.x > lastTileEnd.x - (tiles.Length * tileWidth))
        {
            RepositionTile();
        }
    }
    void RepositionTile()
    {
        GameObject firstTile = tiles[0];
        Vector3 newPosition = lastTileEnd;
        firstTile.transform.position = newPosition;
        lastTileEnd = newPosition + new Vector3(tileWidth, 0, 0);

        // 리스트를 순환시킵니다.
        for (int i = 0; i < tiles.Length - 1; i++)
        {
            tiles[i] = tiles[i + 1];
        }
        tiles[tiles.Length - 1] = firstTile;
    }
}
