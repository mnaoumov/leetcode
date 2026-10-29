namespace LeetCode.Problems._3478_Choose_K_Elements_With_Maximum_Sum;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-440/problems/choose-k-elements-with-maximum-sum/submissions/1567587130/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long[] FindMaxSum(int[] nums1, int[] nums2, int k)
    {
        var num1IndicesMap = nums1.Select((num, index) => (num, index)).GroupBy(x => x.num, x => x.index)
            .ToDictionary(g => g.Key, g => g.ToArray());
        var n = nums1.Length;
        var ans = new long[n];

        var topK = new PriorityQueue<int, int>();
        var topKSum = 0L;

        foreach (var num1 in num1IndicesMap.Keys.OrderBy(num1 => num1))
        {
            var nextTopKSum = topKSum;
            foreach (var num1Index in num1IndicesMap[num1])
            {
                ans[num1Index] = topKSum;
                var num2 = nums2[num1Index];
                topK.Enqueue(num2, num2);
                nextTopKSum += num2;

                if (topK.Count > k)
                {
                    nextTopKSum -= topK.Dequeue();
                }
            }

            topKSum = nextTopKSum;
        }

        return ans;
    }
}
