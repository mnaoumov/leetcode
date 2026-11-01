namespace LeetCode.Problems._0441_Arranging_Coins;

/// <seealso href="https://leetcode.com/submissions/detail/926840255/"/>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int ArrangeCoins(int n) => (int) ((Math.Sqrt(1 + 8d * n) - 1) / 2);
}
