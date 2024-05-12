using JetBrains.Annotations;

namespace LeetCode.Problems._1561_Maximum_Number_of_Coins_You_Can_Get;

/// <summary>
/// https://leetcode.com/submissions/detail/1105256842/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxCoins(int[] piles)
    {
        piles = piles.OrderByDescending(x => x).ToArray();

        var n = piles.Length / 3;
        return Enumerable.Range(0, n).Sum(i => piles[2 * i + 1]);
    }
}
