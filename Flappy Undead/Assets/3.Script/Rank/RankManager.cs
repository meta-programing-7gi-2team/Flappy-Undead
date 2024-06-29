using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class RankManager
{
    private static List<PlayerRank> rankEntries = new List<PlayerRank>();
    private static int maxEntries = 5; // �ִ� ������ ��ŷ ����

    // ��ŷ ������ �ʱ�ȭ
    public static void InitializeRankData()
    {
        rankEntries.Clear(); // �ʱ�ȭ�� �� ����Ʈ ����
    }

    // ��ŷ ������ ����
    public static void SaveRank()
    {
        // ���� ������ ����
        rankEntries = rankEntries.OrderBy(entry => entry.rank).ToList();

        // �ִ� ������ŭ�� �����
        if (rankEntries.Count > maxEntries)
        {
            rankEntries = rankEntries.GetRange(0, maxEntries);
        }

        // JSON���� ����ȭ�Ͽ� ����
        string jsonData = JsonUtility.ToJson(new SerializableList<PlayerRank>(rankEntries));
        PlayerPrefs.SetString("RankData", jsonData);
        PlayerPrefs.Save();
    }

    // ��ŷ ������ �ҷ�����
    public static List<PlayerRank> LoadRank()
    {
        if (PlayerPrefs.HasKey("RankData"))
        {
            string jsonData = PlayerPrefs.GetString("RankData");
            SerializableList<PlayerRank> loadedRanks = JsonUtility.FromJson<SerializableList<PlayerRank>>(jsonData);
            rankEntries = loadedRanks.list;
        }
        else
        {
            rankEntries.Clear(); // ����� �����Ͱ� ���� ��� ����Ʈ �ʱ�ȭ
        }

        return rankEntries;
    }

    // ��ŷ ������ �߰�
    public static void AddPlayerRank(int score)
    {
        // �� ��ŷ �׸� ����
        PlayerRank newEntry = new PlayerRank(-1, score);

        // ���� ��ŷ�� ���Ͽ� ���� ��ġ ����
        int insertIndex = -1;
        for (int i = 0; i < rankEntries.Count; i++)
        {
            if (score > rankEntries[i].score)
            {
                insertIndex = i;
                break;
            }
        }

        if (insertIndex != -1)
        {
            // ���� ��ġ�� �� �׸� ����
            rankEntries.Insert(insertIndex, newEntry);

            // ���� �缳��
            UpdateRanks();

            // �ִ� ������ŭ�� �����
            if (rankEntries.Count > maxEntries)
            {
                rankEntries = rankEntries.GetRange(0, maxEntries);
            }

            // ���� �缳�� �� ����
            SaveRank();
        }
        else if(rankEntries.Count == 0)
        {
            rankEntries.Insert(0, newEntry);
            UpdateRanks();
            SaveRank();
        }
    }

    // ���� �缳��
    private static void UpdateRanks()
    {
        for (int i = 0; i < rankEntries.Count; i++)
        {
            rankEntries[i].rank = i + 1;
        }
    }

    // ��ŷ ������ �ʱ�ȭ (��� ����)
    public static void ClearRankData()
    {
        rankEntries.Clear();
        PlayerPrefs.DeleteKey("RankData");
        PlayerPrefs.Save();
    }

    [System.Serializable]
    private class SerializableList<T>
    {
        public List<T> list;

        public SerializableList(List<T> l)
        {
            list = l;
        }
    }
}
