using JetBrains.Annotations;

namespace LeetCode._0525_Contiguous_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1204835816/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindMaxLength(int[] nums)
    {
        var n = nums.Length;

        var prefixOneCount = 0;
        var map = new Dictionary<int, int>
        {
            [0] = 0
        };

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            prefixOneCount += nums[i];
            var val = 2 * prefixOneCount - i - 1;

            if (map.TryGetValue(val, out var index))
            {
                ans = Math.Max(ans, i + 1 - index);
            }
            else
            {
                map[val] = i + 1;
            }
        }

        return ans;
    }
}
