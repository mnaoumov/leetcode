namespace LeetCode.Problems._0260_Single_Number_III;

/// <summary>
/// https://leetcode.com/submissions/detail/926892044/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] SingleNumber(int[] nums)
    {
        var xor = nums.Aggregate(0, (current, num) => current ^ num);
        var xorMin = nums.Where(num => num < (num ^ xor)).Aggregate(0, (current, num) => current ^ num);
        return new[] { xorMin, xorMin ^ xor };
    }
}
