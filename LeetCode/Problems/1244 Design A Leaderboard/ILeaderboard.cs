namespace LeetCode.Problems._1244_Design_A_Leaderboard;

[PublicAPI]
public interface ILeaderboard
{
    public void AddScore(int playerId, int score);
    // ReSharper disable once InconsistentNaming
    public int Top(int K);
    public void Reset(int playerId);
}
