using JetBrains.Annotations;

namespace LeetCode.Problems._0291_Word_Pattern_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1264532057/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool WordPatternMatch(string pattern, string s)
    {
        var n = s.Length;
        var mapping = new Dictionary<char, string>();
        return Check(0, 0);

        bool Check(int patternIndex, int sIndex)
        {
            if (patternIndex == pattern.Length)
            {
                return sIndex == n;
            }

            var letter = pattern[patternIndex];

            if (mapping.TryGetValue(letter, out var mappedString))
            {
                var nextSIndex = sIndex + mappedString.Length;

                if (nextSIndex > n)
                {
                    return false;
                }

                return s[sIndex..nextSIndex] == mappedString && Check(patternIndex + 1, nextSIndex);
            }

            for (var nextSIndex = patternIndex + 1; nextSIndex <= n; nextSIndex++)
            {
                mapping[letter] = s[sIndex..nextSIndex];

                if (Check(patternIndex + 1, nextSIndex))
                {
                    return true;
                }

                mapping.Remove(letter);
            }

            return false;
        }
    }
}
