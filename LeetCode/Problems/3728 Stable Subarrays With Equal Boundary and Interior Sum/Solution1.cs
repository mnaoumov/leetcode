namespace LeetCode.Problems._3728_Stable_Subarrays_With_Equal_Boundary_and_Interior_Sum;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-473/problems/stable-subarrays-with-equal-boundary-and-interior-sum/submissions/1811791823/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long CountStableSubarrays(int[] capacity)
    {
        var prefixSum = 0L;

        var counts = new Dictionary<(int value, long prefixSum), int>();

        var ans = 0L;

        for (var i = 0; i < capacity.Length; i++)
        {
            var value = capacity[i];
            prefixSum += value;
            ans += counts.GetValueOrDefault((value, prefixSum - 2 * value));

            if (value == 0 && i > 0 && capacity[i - 1] == 0)
            {
                ans--;
            }

            counts.TryAdd((value, prefixSum), 0);
            counts[(value, prefixSum)]++;
        }

        return ans;
    }
}
