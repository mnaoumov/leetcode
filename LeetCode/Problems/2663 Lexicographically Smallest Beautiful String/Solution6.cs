using System.Text;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2663_Lexicographically_Smallest_Beautiful_String;

/// <summary>
/// https://leetcode.com/submissions/detail/941918881/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution6 : ISolution
{
    public string SmallestBeautifulString(string s, int k)
    {
        var sb = new StringBuilder(s);
        var maxLetter = (char) ('a' + k - 1);
        var n = s.Length;

        if (!TryIncrement(n - 1))
        {
            return "";
        }

        while (true)
        {
            var hasPalindromes = false;

            for (var i = 0; i < n - 1; i++)
            {
                int incrementIndex;

                if (sb[i] == sb[i + 1])
                {
                    incrementIndex = i + 1;
                }
                else if (i + 2 < n && sb[i] == sb[i + 2])
                {
                    incrementIndex = i + 2;
                }
                else
                {
                    continue;
                }

                if (!TryIncrement(incrementIndex))
                {
                    return "";
                }

                hasPalindromes = true;
                break;
            }

            if (!hasPalindromes)
            {
                return sb.ToString();
            }
        }

        bool TryIncrement(int lastIndex)
        {
            for (var i = lastIndex; i >= 0; i--)
            {
                if (sb[i] == maxLetter)
                {
                    continue;
                }

                sb[i] = (char) (sb[i] + 1);

                if (k == 2 && i <= n - 3)
                {
                    return false;
                }

                var letterIndex = 0;

                for (var j = i + 1; j < n; j++)
                {
                    sb[j] = (char) ('a' + letterIndex);
                    letterIndex = (letterIndex + 1) % k;
                }

                return true;
            }

            return false;
        }
    }
}
