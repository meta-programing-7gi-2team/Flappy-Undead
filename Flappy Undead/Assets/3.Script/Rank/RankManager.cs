using UnityEngine;
using System.Collections.Generic;
using System.IO;

public static class RankManager
{
    private static string filePath = Application.persistentDataPath + "/rankData.json";

    public static void SaveRank(List<PlayerRank> ranks)
    {
        string jsonData = JsonUtility.ToJson(new SerializableList<PlayerRank>(ranks));
        File.WriteAllText(filePath, jsonData);
    }

    public static List<PlayerRank> LoadRank()
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            SerializableList<PlayerRank> ranks = JsonUtility.FromJson<SerializableList<PlayerRank>>(jsonData);
            return ranks.list;
        }
        else
        {
            return new List<PlayerRank>();
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
