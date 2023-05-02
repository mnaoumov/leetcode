using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0128_Longest_Consecutive_Sequence;

/// <summary>
/// https://leetcode.com/submissions/detail/199789573/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int LongestConsecutive(int[] nums)
    {
        var result = 0;

        var ranges = new Dictionary<int, (int left, int right)>();

        foreach (var num in nums)
        {
            if (ranges.ContainsKey(num))
            {
                continue;
            }

            var left = num;
            var right = num;

            if (ranges.ContainsKey(num + 1))
            {
                right = ranges[num + 1].right;
            }

            if (ranges.ContainsKey(num - 1))
            {
                left = ranges[num - 1].left;
            }

            ranges[num] = ranges[left] = ranges[right] = (left, right);

            result = Math.Max(result, right - left + 1);
        }

        return result;
    }
}
