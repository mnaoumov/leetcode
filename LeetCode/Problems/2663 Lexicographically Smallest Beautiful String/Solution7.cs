using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._2663_Lexicographically_Smallest_Beautiful_String;

/// <summary>
/// https://leetcode.com/submissions/detail/941933500/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution7 : ISolution
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
                var couldSetLetter = false;

                while (true)
                {
                    if (sb[i] == maxLetter)
                    {
                        break;
                    }

                    sb[i] = (char) (sb[i] + 1);

                    switch (i)
                    {
                        case >= 1 when sb[i - 1] == sb[i]:
                        case >= 2 when sb[i - 2] == sb[i]:
                            continue;
                    }

                    couldSetLetter = true;
                    break;
                }

                if (!couldSetLetter)
                {
                    continue;
                }

                for (var j = i + 1; j < n; j++)
                {
                    sb[j] = 'a';
                }

                return true;
            }

            return false;
        }
    }
}
