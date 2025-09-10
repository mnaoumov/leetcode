namespace LeetCode.Problems._3677_Count_Binary_Palindromic_Numbers;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public int CountBinaryPalindromes(long n)
    {
        var maxLength = Convert.ToString(n, 2).Length;

        return Enumerable.Range(1, maxLength - 1).Select(length => CountBinaryPalindromes(length)).Sum();
    }
}
