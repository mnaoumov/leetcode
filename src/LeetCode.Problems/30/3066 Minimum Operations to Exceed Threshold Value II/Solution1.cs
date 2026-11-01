namespace LeetCode.Problems._3066_Minimum_Operations_to_Exceed_Threshold_Value_II;

/// <seealso href="https://leetcode.com/problems/minimum-operations-to-exceed-threshold-value-ii/submissions/1541157324/"/>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int MinOperations(int[] nums, int k)
    {
        var pq = new PriorityQueue<int, int>();

        foreach (var num in nums)
        {
            pq.Enqueue(num, num);
        }

        var ans = 0;

        while (true)
        {
            var x = pq.Dequeue();

            if (x >= k)
            {
                return ans;
            }

            var y = pq.Dequeue();
            var z = x * 2 + y;
            pq.Enqueue(z, z);
            ans++;
        }
    }
}
