using JetBrains.Annotations;

namespace LeetCode.Problems._2615_Sum_of_Distances;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-340/submissions/detail/930450112/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long[] Distance(int[] nums)
    {
        var n = nums.Length;

        var groups = Enumerable.Range(0, n).GroupBy(i => nums[i])
            .Select(g => g.OrderBy(i => i).Select(i => (long) i).ToArray());

        var result = new long[n];

        foreach (var group in groups)
        {
            var sum = group.Select(i => i).Sum();
            var k = group.Length;
            var runningSum = 0L;

            for (var i = 0; i < group.Length; i++)
            {
                runningSum += group[i];
                result[group[i]] = sum + (2 * i + 2 - k) * group[i] - 2 * runningSum;
            }
        }

        return result;
    }
}
