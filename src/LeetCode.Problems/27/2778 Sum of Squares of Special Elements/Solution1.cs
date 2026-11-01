namespace LeetCode.Problems._2778_Sum_of_Squares_of_Special_Elements;

/// <seealso href="https://leetcode.com/contest/weekly-contest-354/submissions/detail/995480060/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SumOfSquares(int[] nums)
    {
        var n = nums.Length;
        return nums.Where((_, i) => n % (i + 1) == 0).Sum(num => num * num);
    }
}
