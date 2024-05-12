using JetBrains.Annotations;

namespace LeetCode.Problems._0826_Most_Profit_Assigning_Work;

/// <summary>
/// https://leetcode.com/submissions/detail/936115936/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
    {
        var n = difficulty.Length;

        var jobs = difficulty.Zip(profit, (d, p) => (difficulty: d, profit: p, maxProfit: p)).OrderBy(job => job.difficulty)
            .ToArray();

        for (var i = 1; i < n; i++)
        {
            jobs[i].maxProfit = Math.Max(jobs[i - 1].maxProfit, jobs[i].profit);
        }

        var ans = 0;

        foreach (var ability in worker)
        {
            var low = 0;
            var high = jobs.Length - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (jobs[mid].difficulty <= ability)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            if (high >= 0)
            {
                ans += jobs[high].maxProfit;
            }
        }

        return ans;
    }
}
