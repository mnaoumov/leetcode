

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0010_Regular_Expression_Matching;

/// <summary>
/// https://leetcode.com/submissions/detail/200403768/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool IsMatch(string s, string p)
    {
        return IsMatch(s, p, 0, 0);
    }

    private bool IsMatch(string s, string p, int sIndex, int pIndex)
    {
        if (sIndex == s.Length || pIndex == p.Length)
        {
            return sIndex == s.Length && pIndex == p.Length;
        }

        const char anyModifier = '.';
        const char multipleModifier = '*';

        var patternSymbol = p[pIndex];
        var hasMultipleModifier = pIndex + 1 < p.Length && p[pIndex + 1] == multipleModifier;

        if (!hasMultipleModifier)
        {
            return (patternSymbol == anyModifier || patternSymbol == s[sIndex]) &&
                   IsMatch(s, p, sIndex + 1, pIndex + 1);
        }

        sIndex--;
        do
        {
            sIndex++;
            if (IsMatch(s, p, sIndex, pIndex + 2))
            {
                return true;
            }
        } while (sIndex < s.Length && (patternSymbol == anyModifier || patternSymbol == s[sIndex]));

        return false;
    }
}
