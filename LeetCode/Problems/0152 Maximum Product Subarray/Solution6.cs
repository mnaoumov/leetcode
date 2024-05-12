using JetBrains.Annotations;

namespace LeetCode.Problems._0152_Maximum_Product_Subarray;

/// <summary>
/// https://leetcode.com/problems/maximum-product-subarray/submissions/848230500/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public int MaxProduct(int[] nums)
    {
        var result = nums[^1];
        var maxProduct = nums[^1];
        var minProduct = nums[^1];

        for (var i = nums.Length - 2; i >= 0; i--)
        {
            var num = nums[i];
            var options = new[] { num, num * maxProduct, num * minProduct };

            maxProduct = options.Max();
            minProduct = options.Min();

            result = Math.Max(result, maxProduct);
        }

        return result;
    }
}
