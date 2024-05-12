using JetBrains.Annotations;

namespace LeetCode.Problems._0238_Product_of_Array_Except_Self;

/// <summary>
/// https://leetcode.com/submissions/detail/924348302/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var prefixProduct = 1;

        var n = nums.Length;
        var answer = new int[n];

        for (var i = 0; i < n; i++)
        {
            answer[i] = prefixProduct;
            prefixProduct *= nums[i];
        }

        var suffixProduct = 1;

        for (var i = n - 1; i >= 0; i--)
        {
            answer[i] *= suffixProduct;
            suffixProduct *= nums[i];
        }

        return answer;
    }
}
