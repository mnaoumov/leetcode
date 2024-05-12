using System.Text;
using JetBrains.Annotations;

namespace LeetCode._2663_Lexicographically_Smallest_Beautiful_String;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-343/submissions/detail/941897167/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public string SmallestBeautifulString(string s, int k)
    {
        var sb = new StringBuilder(s);
        var maxLetter = (char) ('a' + k - 1);
        var n = s.Length;

        while (true)
        {
            var canIncrease = false;

            for (var i = n - 1; i >= 0; i--)
            {
                if (sb[i] == maxLetter)
                {
                    continue;
                }

                sb[i] = (char) (sb[i] + 1);

                for (var j = i + 1; j < n; j++)
                {
                    sb[j] = 'a';
                }

                canIncrease = true;
                break;
            }

            if (!canIncrease)
            {
                return "";
            }

            if (!Enumerable.Range(0, n - 1).Any(HasPalindromeStartingAt))
            {
                return sb.ToString();
            }

            continue;

            bool HasPalindromeStartingAt(int index) => index + 1 < n && sb[index] == sb[index + 1] || index + 2 < n && sb[index] == sb[index + 2];
        }
    }
}
