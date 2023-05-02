using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0010_Regular_Expression_Matching;

/// <summary>
/// https://leetcode.com/submissions/detail/200403164/
/// </summary>
[SkipSolution(SkipSolutionReason.RuntimeError)]
[UsedImplicitly]
public class Solution1 : ISolution
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
        } while (patternSymbol == anyModifier || (sIndex < s.Length && patternSymbol == s[sIndex]));

        return false;
    }
}
