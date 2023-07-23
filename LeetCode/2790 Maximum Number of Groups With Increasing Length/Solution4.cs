using JetBrains.Annotations;

namespace LeetCode._2790_Maximum_Number_of_Groups_With_Increasing_Length;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-355/submissions/detail/1001477960/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution4 : ISolution
{
    public int MaxIncreasingGroups(IList<int> usageLimits)
    {
        var limitCounts = usageLimits.GroupBy(limit => limit).ToDictionary(g => g.Key, g => g.Count());

        var limitsPq = new PriorityQueue<int, int>();
        var n = usageLimits.Count;
        var total = n;

        foreach (var limit in limitCounts.Keys)
        {
            limitsPq.Enqueue(limit, -limit);
        }

        var ans = 0;

        while (total > ans)
        {
            ans++;

            var unassignedSize = ans;

            var updates = new List<(int limit, int amount)>();

            while (unassignedSize > 0)
            {
                var limit = limitsPq.Dequeue();
                var count = limitCounts[limit];
                var take = Math.Min(count, unassignedSize);

                limitCounts[limit] -= take;
                unassignedSize -= take;

                if (limit > 1)
                {
                    updates.Add((limit - 1, take));
                }
                else
                {
                    total -= take;
                }

                if (count > take)
                {
                    limitsPq.Enqueue(limit, -limit);
                }
                else
                {
                    limitCounts.Remove(limit);
                }
            }

            foreach (var (limit, amount) in updates)
            {
                if (!limitCounts.ContainsKey(limit))
                {
                    limitCounts[limit] = 0;
                    limitsPq.Enqueue(limit, -limit);
                }

                limitCounts[limit] += amount;
            }
        }

        return ans;
    }
}
