using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0076_Minimum_Window_Substring;

/// <summary>
/// https://leetcode.com/submissions/detail/821667964/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public string MinWindow(string s, string t)
    {
        if (s.Length < t.Length)
        {
            return "";
        }

        var tLettersWithCounts = t.ToCharArray().GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

        var left = 0;
        var right = -1;
        var minWindowSize = int.MaxValue;
        const int notFound = -1;
        var minWindowStart = notFound;
        var lettersToFindCount = tLettersWithCounts.Count;

        while (true)
        {
            while (left <= s.Length - t.Length && !tLettersWithCounts.ContainsKey(s[left]))
            {
                left++;
            }

            if (left > s.Length - t.Length)
            {
                break;
            }

            if (lettersToFindCount == 0)
            {
                var windowSize = right - left;
                if (windowSize < minWindowSize)
                {
                    minWindowSize = windowSize;
                    minWindowStart = left;
                }
            }
            else
            {
                if (right < left)
                {
                    right = left;
                }

                while (right < s.Length && right - left < minWindowSize - 1)
                {
                    var letter = s[right];
                    if (tLettersWithCounts.ContainsKey(letter))
                    {
                        tLettersWithCounts[letter]--;
                        if (tLettersWithCounts[letter] == 0)
                        {
                            lettersToFindCount--;

                            if (lettersToFindCount == 0)
                            {
                                minWindowSize = right - left + 1;
                                minWindowStart = left;
                                right++;
                                break;
                            }
                        }
                    }

                    right++;
                }
            }

            tLettersWithCounts[s[left]]++;
            if (tLettersWithCounts[s[left]] == 1)
            {
                lettersToFindCount++;
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
