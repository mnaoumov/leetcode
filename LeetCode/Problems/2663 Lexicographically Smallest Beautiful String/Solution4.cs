using System.Text;
using JetBrains.Annotations;

namespace LeetCode._2663_Lexicographically_Smallest_Beautiful_String;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-343/submissions/detail/941911130/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution4 : ISolution
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

                if (i + 2 < n && sb[i] == sb[i + 2])
                {
                    incrementIndex = i + 2;
                }
                else if (sb[i] == sb[i + 1])
                {
                    incrementIndex = i + 1;
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

        void IncrementWord(int i)
        {
            sb[i] = (char) (sb[i] + 1);

            for (var j = i + 1; j < n; j++)
            {
                sb[j] = 'a';
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

                IncrementWord(i);

                return true;
            }

            return false;
        }
    }
}
