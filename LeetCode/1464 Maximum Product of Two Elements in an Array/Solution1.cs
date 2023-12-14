using JetBrains.Annotations;

namespace LeetCode._1464_Maximum_Product_of_Two_Elements_in_an_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1117613840/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxProduct(int[] nums)
    {
        Array.Sort(nums);
        return (nums[^1] - 1) * (nums[^2] - 1);
    }
}
