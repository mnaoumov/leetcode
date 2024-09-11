namespace LeetCode.Problems._0258_Add_Digits;

/// <summary>
/// https://leetcode.com/submissions/detail/924648111/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int AddDigits(int num)
    {
        return num % 9;
    }
}
