namespace LeetCode.Problems._3021_Alice_and_Bob_Playing_Flower_Game;

/// <seealso href="https://leetcode.com/problems/alice-and-bob-playing-flower-game/submissions/1751913467/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long FlowerGame(int n, int m) => 1L * (n / 2) * ((m + 1) / 2) + 1L * ((n + 1) / 2) * (m / 2);
}
