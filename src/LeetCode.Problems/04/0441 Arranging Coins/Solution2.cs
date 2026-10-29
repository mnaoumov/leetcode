namespace LeetCode.Problems._0441_Arranging_Coins;

/// <summary>
/// https://leetcode.com/submissions/detail/926840255/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int ArrangeCoins(int n) => (int) ((Math.Sqrt(1 + 8d * n) - 1) / 2);
}
