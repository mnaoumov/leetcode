namespace LeetCode.Problems._2333_Minimum_Sum_of_Squared_Difference;

/// <summary>
/// https://leetcode.com/problems/minimum-sum-of-squared-difference/submissions/2168678480/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2)
    {
        var pq = new PriorityQueue<int, int>();
        var n = nums1.Length;

        for (var i = 0; i < n; i++)
        {
            var diff = Math.Abs(nums1[i] - nums2[i]);
            if (diff > 0)
            {
                pq.Enqueue(diff, -diff);
            }
        }

        for (var i = 0; i < k1 + k2; i++)
        {
            if (pq.Count == 0)
            {
                break;
            }
            var diff = pq.Dequeue();
            diff--;
            if (diff > 0)
            {
                pq.Enqueue(diff, -diff);
            }
        }

        var ans = 0L;
        while (pq.Count > 0)
        {
            var diff = pq.Dequeue();
            ans += 1L * diff * diff;
        }

        return ans;
    }
}