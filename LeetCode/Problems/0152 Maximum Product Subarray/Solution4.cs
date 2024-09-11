
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0152_Maximum_Product_Subarray;

/// <summary>
/// https://leetcode.com/submissions/detail/198326456/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int MaxProduct(int[] nums)
    {
        var n = nums.Length;
        if (n == 0)
        {
            return 0;
        }

        var lastMaxSuffixProduct = nums[n - 1];
        var lastMinSuffixProduct = nums[n - 1];
        var globalMaxProduct = nums[n - 1];

        for (int i = n - 2; i >= 0; i--)
        {
            var value = nums[i];
            var nextMax = Math.Max(value, value * (value >= 0 ? lastMaxSuffixProduct : lastMinSuffixProduct));
            var nextMin = Math.Min(value, value * (value >= 0 ? lastMinSuffixProduct : lastMaxSuffixProduct));
            lastMaxSuffixProduct = nextMax;
            lastMinSuffixProduct = nextMin;
            globalMaxProduct = Math.Max(globalMaxProduct, lastMaxSuffixProduct);
        }

        return globalMaxProduct;
    }
}
