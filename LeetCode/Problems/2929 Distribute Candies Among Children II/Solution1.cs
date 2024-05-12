using JetBrains.Annotations;

namespace LeetCode._2929_Distribute_Candies_Among_Children_II;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-117/submissions/detail/1096601185/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long DistributeCandies(int n, int limit)
    {
        if (n > limit * 3)
        {
            return 0;
        }

        var min = Math.Max(0, n - 2 * limit);
        var max = Math.Min(n, limit);

        var ans = 0L;

        for (var i = min; i <= max; i++)
        {
            ans += Math.Min(limit, n - i) - Math.Max(0, n - i - limit) + 1;
        }

        return ans;
    }
}
