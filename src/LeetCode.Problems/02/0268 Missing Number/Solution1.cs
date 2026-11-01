namespace LeetCode.Problems._0268_Missing_Number;

/// <seealso href="https://leetcode.com/submissions/detail/856307358/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MissingNumber(int[] nums)
    {
        var n = nums.Length;
        return n * (n + 1) / 2 - nums.Sum();
    }
}
