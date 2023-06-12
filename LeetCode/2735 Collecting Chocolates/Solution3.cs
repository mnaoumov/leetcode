using JetBrains.Annotations;

namespace LeetCode._2735_Collecting_Chocolates;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-349/submissions/detail/968564801/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public long MinCost(int[] nums, int x)
    {
        var n = nums.Length;

        var bestCosts = nums.Select(num => (long) num).ToArray();
        var ans = bestCosts.Sum();

        for (var i = 1; i < n; i++)
        {
            if (ans <= 1L * i * x)
            {
                break;
            }

            for (var j = 0; j < n; j++)
            {
                bestCosts[j] = Math.Min(bestCosts[j], nums[(j - i + n) % n]);
            }

            ans = Math.Min(ans, 1L * i * x + bestCosts.Sum());
        }

        return ans;
    }
}
