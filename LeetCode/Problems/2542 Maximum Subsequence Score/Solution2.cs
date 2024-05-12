using JetBrains.Annotations;

namespace LeetCode.Problems._2542_Maximum_Subsequence_Score;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-96/submissions/detail/882494451/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MaxScore(int[] nums1, int[] nums2, int k)
    {
        var orderedNums2 = nums2.Select((num, index) => (num, index)).GroupBy(x => x.num, x => x.index).OrderByDescending(g => g.Key);

        var pq1 = new PriorityQueue<int, int>();
        var sum1 = 0L;
        var result = long.MinValue;

        foreach (var group in orderedNums2)
        {
            var min2 = group.Key;

            foreach (var index in group)
            {
                pq1.Enqueue(nums1[index], nums1[index]);
                sum1 += nums1[index];

                if (pq1.Count > k)
                {
                    sum1 -= pq1.Dequeue();
                }
            }

            if (pq1.Count < k)
            {
                continue;
            }

            result = Math.Max(result, min2 * sum1);
        }

        return result;
    }
}
