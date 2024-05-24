using JetBrains.Annotations;

namespace LeetCode.Problems._0291_Word_Pattern_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1264544650/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool WordPatternMatch(string pattern, string s)
    {
        var n = s.Length;
        var mapping = new Dictionary<char, string>();
        var mappedStrings = new HashSet<string>();
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

            for (var nextSIndex = sIndex + 1; nextSIndex <= n; nextSIndex++)
            {
                mappedString = s[sIndex..nextSIndex];

                if (!mappedStrings.Add(mappedString))
                {
                    continue;
                }

                mapping[letter] = mappedString;

                if (Check(patternIndex + 1, nextSIndex))
                {
                    return true;
                }

                mapping.Remove(letter);
                mappedStrings.Remove(mappedString);
            }

            return false;
        }
    }
}
