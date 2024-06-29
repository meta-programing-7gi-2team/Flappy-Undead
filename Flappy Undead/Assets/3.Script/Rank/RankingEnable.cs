using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingEnable : MonoBehaviour
{
    [SerializeField] private Text _1st_Text;
    [SerializeField] private Text _2nd_Text;
    [SerializeField] private Text _3rd_Text;
    [SerializeField] private Text _4th_Text;
    [SerializeField] private Text _5th_Text;
    private void OnEnable()
    {
        List<PlayerRank> loadedRanks = RankManager.LoadRank();

        foreach (PlayerRank rank in loadedRanks)
        {
            switch(rank.playerName)
            {
                case 1:
                    _1st_Text.text = string.Format("{0}.{1}", rank.playerName, rank.score);
                    break;
                case 2:
                    _2nd_Text.text = string.Format("{0}.{1}", rank.playerName, rank.score);
                    break;
                case 3:
                    _3rd_Text.text = string.Format("{0}.{1}", rank.playerName, rank.score);
                    break;
                case 4:
                    _4th_Text.text = string.Format("{0}.{1}", rank.playerName, rank.score);
                    break;
                case 5:
                    _5th_Text.text = string.Format("{0}.{1}", rank.playerName, rank.score);
                    break;
            }
        }
    }
}
