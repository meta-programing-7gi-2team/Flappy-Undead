using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    [SerializeField] private Text Score_text;
    private void Update()
    {
        Score_text.text = string.Format("Score : {0}", GameManager.instance.Score);
    }
}
