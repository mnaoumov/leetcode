namespace LeetCode.Problems._2333_Minimum_Sum_of_Squared_Difference;

/// <summary>
/// https://leetcode.com/problems/minimum-sum-of-squared-difference/submissions/2168713817/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2)
    {
        var n = nums1.Length;

        var diffs = new SortedSet<int>();
        var counts = new Dictionary<int, int>();

        for (var i = 0; i < n; i++)
        {
            var diff = Math.Abs(nums1[i] - nums2[i]);

            if (diff == 0)
            {
                continue;
            }

            diffs.Add(diff);
            counts.TryAdd(diff, 0);
            counts[diff]++;
        }

        var k = k1 + k2;

        while (k > 0 && diffs.Count > 0)
        {
            var max = diffs.Max;
            var count = counts[max];
            diffs.Remove(max);
            counts.Remove(max);
            var max2 = diffs.Count > 0 ? diffs.Max : 0;
            var steps = Math.Min(k / count, max - max2);
            var rest = k - count * steps;

            if (steps == max - max2)
            {
                rest = 0;
            }

            k -= count * steps + rest;

            var next = max - steps;
            diffs.Add(next);
            counts.TryAdd(next, 0);
            counts[next] += count - rest;

            if (rest <= 0)
            {
                continue;
            }

            diffs.Add(next -1);
            counts.TryAdd(next - 1, 0);
            counts[next - 1] += rest;
        }

        return diffs.Sum(diff => 1L * diff * diff * counts[diff]);
    }
}