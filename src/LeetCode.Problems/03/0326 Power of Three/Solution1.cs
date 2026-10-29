namespace LeetCode.Problems._0326_Power_of_Three;

/// <summary>
/// https://leetcode.com/submissions/detail/923277207/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool IsPowerOfThree(int n)
    {
        if (n <= 0)
        {
            return false;
        }

        var log = Math.Log(n, 3);
        return Math.Abs(log - (int) log) < double.Epsilon;
    }
}
