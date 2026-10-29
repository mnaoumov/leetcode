namespace LeetCode.Problems._3478_Choose_K_Elements_With_Maximum_Sum;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-440/problems/choose-k-elements-with-maximum-sum/submissions/1567576215/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long[] FindMaxSum(int[] nums1, int[] nums2, int k)
    {
        var num1IndicesMap = nums1.Select((num, index) => (num, index)).GroupBy(x => x.num, x => x.index)
            .ToDictionary(g => g.Key, g => g.ToArray());
        var n = nums1.Length;
        var ans = new long[n];

        var pq = new PriorityQueue<int, int>();

        foreach (var num1 in num1IndicesMap.Keys.OrderBy(num1 => num1))
        {
            var maxSum = 0L;

            var maxValues = new List<int>();

            for (var i = 0; i < k; i++)
            {
                if (pq.Count == 0)
                {
                    break;
                }

                var maxValue = pq.Dequeue();
                maxValues.Add(maxValue);
                maxSum += maxValue;
            }

            foreach (var maxValue in maxValues)
            {
                pq.Enqueue(maxValue, -maxValue);
            }

            foreach (var num1Index in num1IndicesMap[num1])
            {
                ans[num1Index] = maxSum;
                var num2 = nums2[num1Index];
                pq.Enqueue(num2, -num2);
            }
        }

        return ans;
    }
}
