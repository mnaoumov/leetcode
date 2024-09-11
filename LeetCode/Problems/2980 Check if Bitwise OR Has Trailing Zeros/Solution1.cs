namespace LeetCode.Problems._2980_Check_if_Bitwise_OR_Has_Trailing_Zeros;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-378/submissions/detail/1132628431/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool HasTrailingZeros(int[] nums) => nums.Count(num => num % 2 == 0) >= 2;
}
