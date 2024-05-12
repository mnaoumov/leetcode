using JetBrains.Annotations;

namespace LeetCode.Problems._2790_Maximum_Number_of_Groups_With_Increasing_Length;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-355/submissions/detail/1001447265/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaxIncreasingGroups(IList<int> usageLimits)
    {
        var pq = new PriorityQueue<(int num, int limit), int>();
        var n = usageLimits.Count;

        for (var i = 0; i < n; i++)
        {
            pq.Enqueue((i, usageLimits[i]), -usageLimits[i]);
        }

        var ans = 0;

        while (pq.Count > ans)
        {
            ans++;

            var entriesToAdd = new List<(int num, int limit)>();

            for (var i = 0; i < ans; i++)
            {
                var (num, limit) = pq.Dequeue();

                if (limit > 1)
                {
                    entriesToAdd.Add((num, limit - 1));
                }
            }

            foreach (var (num, limit) in entriesToAdd)
            {
                pq.Enqueue((num, limit), -limit);
            }
        }

        return ans;
    }
}
