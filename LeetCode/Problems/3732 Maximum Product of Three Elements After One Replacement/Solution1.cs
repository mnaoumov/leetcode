namespace LeetCode.Problems._3732_Maximum_Product_of_Three_Elements_After_One_Replacement;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-474/problems/maximum-product-of-three-elements-after-one-replacement/submissions/1818202988/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaxProduct(int[] nums)
    {
        nums = nums.OrderByDescending(num => Math.Abs(num)).ToArray();

        var ans = 1L * Math.Abs(nums[0]) * Math.Abs(nums[1]) * 100_000;
        return ans;
    }
}
