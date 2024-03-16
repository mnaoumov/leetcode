using JetBrains.Annotations;

namespace LeetCode._3080_Mark_Elements_on_Array_by_Performing_Queries;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-126/submissions/detail/1205362304/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long[] UnmarkedSumArray(int[] nums, int[][] queries)
    {
        var n = nums.Length;
        var m = queries.Length;

        var ans = new long[m];

        var usedIndices = new HashSet<int>();

        var sortedIndices = new PriorityQueue<int, (int num, int index)>();

        for (var i = 0; i < n; i++)
        {
            sortedIndices.Enqueue(i, (nums[i], i));
        }

        for (var j = 0; j < m; j++)
        {
            var index = queries[j][0];
            var k = queries[j][1];

            var markedSum = 0L;

            if (usedIndices.Add(index))
            {
                markedSum += nums[index];
            }

            var newMarkedCount = 0;

            while (sortedIndices.Count > 0 && newMarkedCount < k)
            {
                var minIndex = sortedIndices.Dequeue();

                if (!usedIndices.Add(minIndex))
                {
                    continue;
                }

                markedSum += nums[minIndex];
                newMarkedCount++;
            }

            ans[j] = (j > 0 ? ans[j - 1] : nums.Select(num => (long) num).Sum()) - markedSum;
        }

        return ans;
    }
}
