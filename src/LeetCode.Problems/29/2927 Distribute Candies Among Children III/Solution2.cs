namespace LeetCode.Problems._2927_Distribute_Candies_Among_Children_III;

/// <summary>
/// https://leetcode.com/problems/distribute-candies-among-children-iii/submissions/1650214345/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long DistributeCandies(int n, int limit)
    {
        var extra = limit + 1;
        return F(n) - 3 * F(n - extra) + 3 * F(n - 2 * extra) - F(n - 3 * extra);
    }

    private static long F(long m) => m < 0 ? 0 : (m + 1) * (m + 2) / 2;
}
