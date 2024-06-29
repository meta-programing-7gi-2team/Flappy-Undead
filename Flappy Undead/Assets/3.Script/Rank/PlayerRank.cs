[System.Serializable]
public class PlayerRank
{
    public int playerName;
    public int score;

    public PlayerRank(int name, int score)
    {
        this.playerName = name;
        this.score = score;
    }
}
