using JetBrains.Annotations;

namespace LeetCode._2790_Maximum_Number_of_Groups_With_Increasing_Length;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int MaxIncreasingGroups(IList<int> usageLimits)
    {
        var pq = new PriorityQueue<(int num, int limit), int>();
        var n = usageLimits.Count;

        var low = 1;
        var high = n;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);
            //if (CanMake)
        }

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
