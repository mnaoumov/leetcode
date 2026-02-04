namespace LeetCode.Problems._1244_Design_A_Leaderboard;

[PublicAPI]
public interface ILeaderboard
{
    void AddScore(int playerId, int score);
    // ReSharper disable once InconsistentNaming
    int Top(int K);
    void Reset(int playerId);
}
