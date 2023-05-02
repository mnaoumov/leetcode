using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0152_Maximum_Product_Subarray;

/// <summary>
/// https://leetcode.com/submissions/detail/198324673/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaxProduct(int[] nums)
    {
        var n = nums.Length;
        if (n == 0)
        {
            return 0;
        }

        var maxSuffixProducts = new int[n];
        var minSuffixProducts = new int[n];

        maxSuffixProducts[n - 1] = nums[n - 1];
        minSuffixProducts[n - 1] = nums[n - 1];
        var result = nums[n - 1];

        for (int i = n - 2; i >= 0; i--)
        {
            var value = nums[i];
            maxSuffixProducts[i] = Math.Max(value, value * (value >= 0 ? maxSuffixProducts : minSuffixProducts)[i + 1]);
            minSuffixProducts[i] = Math.Min(value, value * (value >= 0 ? minSuffixProducts : maxSuffixProducts)[i + 1]);

            result = Math.Max(result, maxSuffixProducts[i]);
        }

        return result;
    }
}
