using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverEnable : MonoBehaviour
{
    [SerializeField] private Text highestScore;
    [SerializeField] private Text currentScore;
    private void OnEnable()
    {
        List<PlayerRank> loadedRanks = RankManager.LoadRank();
        int score = 0;
        foreach (PlayerRank ranking in loadedRanks)
        {
            if(ranking.rank.Equals(1))
            {
                score = ranking.score;
                break;
            }
        }
        highestScore.text = string.Format("최고 점수 : {0}", score);
        currentScore.text = string.Format("점수 : {0}", GameManager.instance.Score);
    }
}
