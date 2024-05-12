using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0076_Minimum_Window_Substring;

/// <summary>
/// https://leetcode.com/submissions/detail/821335911/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution4 : ISolution
{
    public string MinWindow(string s, string t)
    {
        if (s.Length < t.Length)
        {
            return "";
        }

        var tLettersWithCountsCache = t.ToCharArray().GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

        var left = 0;
        var minWindowSize = int.MaxValue;
        const int notFound = -1;
        var minWindowStart = notFound;

        while (true)
        {
            while (left <= s.Length - t.Length && !tLettersWithCountsCache.ContainsKey(s[left]))
            {
                left++;
            }

            if (left > s.Length - t.Length)
            {
                break;
            }

            var right = left;

            var tLettersWithCounts = new Dictionary<char, int>(tLettersWithCountsCache);

            while (right < s.Length && right - left < minWindowSize - 1)
            {
                var letter = s[right];
                if (tLettersWithCounts.ContainsKey(letter))
                {
                    tLettersWithCounts[letter]--;
                    if (tLettersWithCounts[letter] == 0)
                    {
                        tLettersWithCounts.Remove(letter);

                        if (tLettersWithCounts.Count == 0)
                        {
                            minWindowSize = right - left + 1;
                            minWindowStart = left;
                            break;
                        }
                    }
                }

                right++;
            }

            left++;
        }

        if (minWindowStart == notFound)
        {
            return "";
        }

        return s.Substring(minWindowStart, minWindowSize);
    }
}
