using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public static class RankManager
{
    private static List<PlayerRank> rankEntries = new List<PlayerRank>();
    private static int maxEntries = 5; // 최대 저장할 랭킹 개수

    // 랭킹 데이터 초기화
    public static void InitializeRankData()
    {
        rankEntries.Clear(); // 초기화할 때 리스트 비우기
    }

    // 랭킹 데이터 저장
    public static void SaveRank()
    {
        // 순위 순으로 정렬
        rankEntries = rankEntries.OrderBy(entry => entry.rank).ToList();

        // 최대 개수만큼만 남기기
        if (rankEntries.Count > maxEntries)
        {
            rankEntries = rankEntries.GetRange(0, maxEntries);
        }

        // JSON으로 직렬화하여 저장
        string jsonData = JsonUtility.ToJson(new SerializableList<PlayerRank>(rankEntries));

        File.WriteAllText(Application.dataPath + "/SaveFile.json", jsonData);
    }

    // 랭킹 데이터 불러오기
    public static List<PlayerRank> LoadRank()
    {
        string filePath = Application.dataPath + "/SaveFile.json";

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            SerializableList<PlayerRank> loadedRanks = JsonUtility.FromJson<SerializableList<PlayerRank>>(jsonData);
            rankEntries = loadedRanks.list;
        }
        else
        {
            rankEntries.Clear(); // 저장된 데이터가 없을 경우 리스트 초기화
        }

        return rankEntries;
    }

    // 랭킹 데이터 추가
    public static void AddPlayerRank(int score)
    {
        // 새 랭킹 항목 생성
        PlayerRank newEntry = new PlayerRank(-1, score);

        // 기존 랭킹과 비교하여 삽입 위치 결정
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
            // 삽입 위치에 새 항목 삽입
            rankEntries.Insert(insertIndex, newEntry);

            // 순위 재설정
            UpdateRanks();

            // 최대 개수만큼만 남기기
            if (rankEntries.Count > maxEntries)
            {
                rankEntries = rankEntries.GetRange(0, maxEntries);
            }

            // 순위 재설정 후 저장
            SaveRank();
        }
        else if (rankEntries.Count == 0)
        {
            rankEntries.Insert(0, newEntry);
            UpdateRanks();
            SaveRank();
        }
        else
        {
            rankEntries.Insert(rankEntries.Count, newEntry);
            UpdateRanks();
            SaveRank();
        }
    }

    // 순위 재설정
    private static void UpdateRanks()
    {
        for (int i = 0; i < rankEntries.Count; i++)
        {
            rankEntries[i].rank = i + 1;
        }
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
