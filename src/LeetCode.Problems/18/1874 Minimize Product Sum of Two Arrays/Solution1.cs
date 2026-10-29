namespace LeetCode.Problems._1874_Minimize_Product_Sum_of_Two_Arrays;

/// <summary>
/// https://leetcode.com/problems/minimize-product-sum-of-two-arrays/submissions/1849691170/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinProductSum(int[] nums1, int[] nums2)
    {
        nums1 = nums1.OrderByDescending(x => x).ToArray();
        nums2 = nums2.OrderBy(x => x).ToArray();
        return nums1.Zip(nums2, (a, b) => a * b).Sum();
    }
}
