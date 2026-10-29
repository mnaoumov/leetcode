namespace LeetCode.Problems._3679_Minimum_Discards_to_Balance_Inventory;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-165/problems/minimum-discards-to-balance-inventory/submissions/1769432585/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinArrivalsToDiscard(int[] arrivals, int w, int m)
    {
        var counts = new Dictionary<int, int>();
        var ans = 0;

        for (var i = 0; i < arrivals.Length; i++)
        {
            var arrival = arrivals[i];
            counts.TryAdd(arrival, 0);
            counts[arrival]++;

            if (i - w >= 0)
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
        }

        return ans;
    }
}
