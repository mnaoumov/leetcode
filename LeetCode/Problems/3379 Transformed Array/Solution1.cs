namespace LeetCode.Problems._3379_Transformed_Array;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-427/submissions/detail/1473090331/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] ConstructTransformedArray(int[] nums)
    {
        var n = nums.Length;
        return nums.Select((num, index) => nums[((index + num) % n + n) % n]).ToArray();
    }
}
