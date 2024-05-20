using JetBrains.Annotations;

namespace LeetCode.Problems._3152_Special_Array_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-398/submissions/detail/1261764608/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool[] IsArraySpecial(int[] nums, int[][] queries)
    {
        var n = nums.Length;

        var diffParitySums = new int[n];

        for (var i = 1; i < n; i++)
        {
            var diffParity = Math.Abs(nums[i] - nums[i - 1]) % 2;
            diffParitySums[i] = diffParitySums[i - 1] + diffParity;
        }

        return queries.Select(query => IsSubarraySpecial(query[0], query[1])).ToArray();

        bool IsSubarraySpecial(int from, int to) => diffParitySums[to] - diffParitySums[from] == to - from;
    }
}
