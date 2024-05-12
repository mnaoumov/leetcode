using JetBrains.Annotations;

namespace LeetCode._2928_Distribute_Candies_Among_Children_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-117/submissions/detail/1096581279/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int DistributeCandies(int n, int limit)
    {
        var ans = 0;

        for (var i = 0; i <= limit; i++)
        {
            for (var j = 0; j <= limit; j++)
            {
                var k = n - i - j;

                if (0 <= k && k <= limit)
                {
                    ans++;
                }
            }
        }

        return ans;
    }
}
