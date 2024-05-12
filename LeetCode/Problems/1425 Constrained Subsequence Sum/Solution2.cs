using JetBrains.Annotations;

namespace LeetCode.Problems._1425_Constrained_Subsequence_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/1080899093/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int ConstrainedSubsetSum(int[] nums, int k)
    {
        var pq = new PriorityQueue<(int index, int sum), int>();
        var ans = int.MinValue;

        for (var i = nums.Length - 1; i >= 0; i--)
        {
            var num = nums[i];
            var maxSum = num;
            while (pq.Count > 0 && pq.Peek().index > i + k)
            {
                pq.Dequeue();
            }

            if (pq.Count > 0)
            {
                maxSum = num + Math.Max(0, pq.Peek().sum);
            }

            pq.Enqueue((i, maxSum), -maxSum);
            ans = Math.Max(ans, maxSum);
        }

        return ans;
    }
}
