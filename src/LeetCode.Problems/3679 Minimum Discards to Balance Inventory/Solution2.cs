namespace LeetCode.Problems._3679_Minimum_Discards_to_Balance_Inventory;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-165/problems/minimum-discards-to-balance-inventory/submissions/1769448406/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinArrivalsToDiscard(int[] arrivals, int w, int m)
    {
        var counts = new Dictionary<int, int>();
        var ans = 0;
        var discardedIndices = new HashSet<int>();

        for (var i = 0; i < arrivals.Length; i++)
        {
            var arrival = arrivals[i];
            counts.TryAdd(arrival, 0);
            counts[arrival]++;

            if (i - w >= 0 && !discardedIndices.Contains(i - w))
            {
                var oldArrival = arrivals[i - w];
                counts[oldArrival]--;
            }

            if (counts[arrival] <= m)
            {
                continue;
            }

            counts[arrival]--;
            ans++;
            discardedIndices.Add(i);
        }

        return ans;
    }
}
