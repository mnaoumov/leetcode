using JetBrains.Annotations;

namespace LeetCode._0152_Maximum_Product_Subarray;

/// <summary>
/// https://leetcode.com/problems/maximum-product-subarray/submissions/848228338/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution5 : ISolution
{
    public int MaxProduct(int[] nums)
    {
        var result = nums[^1];
        var maxProduct = nums[^1];
        var minProduct = nums[^1];

        for (var i = nums.Length - 2; i >= 0; i--)
        {
            var num = nums[i];
            maxProduct = num >= 0 ? num * Math.Max(1, maxProduct) : num * minProduct;
            minProduct = num >= 0 ? num * Math.Min(1, minProduct) : num * maxProduct;
            result = Math.Max(result, maxProduct);
        }

        return result;
    }
}
