#pragma warning disable

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0312_Burst_Balloons;

/// <summary>
/// https://leetcode.com/submissions/detail/199940932/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MaxCoins(int[] nums)
    {
        var n = nums.Length;
        var cache = new int?[n, n];
        return MaxCoins(nums, 0, n - 1, cache);
    }

    private int MaxCoins(int[] nums, int start, int end, int?[,] cache)
    {
        if (start > end)
        {
            return 0;
        }

        if (cache[start, end] != null)
        {
            return cache[start, end].Value;
        }

        var max = int.MinValue;

        for (int i = start; i <= end; i++)
        {
            var value = MaxCoins(nums, start, i - 1, cache) +
                        Get(nums, start - 1) * Get(nums, i) * Get(nums, end + 1) +
                        MaxCoins(nums, i + 1, end, cache);
            if (value > max)
            {
                max = value;
            }
        }

        cache[start, end] = max;
        return max;
    }

    private static int Get(int[] nums, int i)
    {
        if (0 <= i && i < nums.Length)
        {
            return nums[i];
        }
        else
        {
            return 1;
        }
    }
}
