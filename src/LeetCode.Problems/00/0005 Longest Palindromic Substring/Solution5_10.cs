// ReSharper disable All
#pragma warning disable
namespace LeetCode.Problems._0005_Longest_Palindromic_Substring;

/// <seealso href="https://leetcode.com/submissions/detail/147572623/">Submission</seealso>
/// <seealso href="https://leetcode.com/submissions/detail/815930675/">Submission</seealso>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution5_10 : ISolution
{
    public string LongestPalindrome(string s)
    {
        var max = "";
        var n = s.Length;
        for (int l = 1; l <= 2 * n - 3; l++)
        {
            for (int i = l / 2, j = l - i; i >= 0 && j < n; i--, j++)
            {
                if (s[i] != s[j])
                    break;
                var potentialMax = s.Substring(i, j - i + 1);
                if (max.Length < potentialMax.Length)
                    max = potentialMax;
            }
        }

        return max;
    }
}
