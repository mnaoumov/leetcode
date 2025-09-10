namespace LeetCode.Problems._3021_Alice_and_Bob_Playing_Flower_Game;

/// <summary>
/// https://leetcode.com/problems/alice-and-bob-playing-flower-game/submissions/1751913467/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long FlowerGame(int n, int m) => 1L * (n / 2) * ((m + 1) / 2) + 1L * ((n + 1) / 2) * (m / 2);
}
