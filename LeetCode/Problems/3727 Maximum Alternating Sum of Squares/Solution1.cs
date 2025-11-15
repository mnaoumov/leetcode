namespace LeetCode.Problems._3727_Maximum_Alternating_Sum_of_Squares;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-473/problems/maximum-alternating-sum-of-squares/submissions/1811778208/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaxAlternatingSum(int[] nums)
    {
        var squares = nums.Select(num => 1L * num * num).OrderByDescending(x => x).ToArray();
        var n = nums.Length;
        var middle = (n + 1) / 2;
        return squares.Take(middle).Sum() - squares.Skip(middle).Sum();
    }
}
