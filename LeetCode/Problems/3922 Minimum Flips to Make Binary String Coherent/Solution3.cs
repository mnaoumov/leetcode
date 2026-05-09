namespace LeetCode.Problems._1018202_Minimum_Flips_to_Make_Binary_String_Coherent;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-182/problems/minimum-flips-to-make-binary-string-coherent/submissions/1998966930/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution3 : ISolution
{
    public int MinFlips(string s)
    {
        var n = s.Length;

        var zeroCount = s.Count(digit => digit == '0');
        var oneCount = n - zeroCount;

        return Math.Min(zeroCount, Math.Max(0, oneCount - ((s[0] == '1' && s[^1] == '1') ? 2 : 1)));
    }
}
