using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0010_Regular_Expression_Matching;

/// <summary>
/// https://leetcode.com/submissions/detail/200404558/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public bool IsMatch(string s, string p)
    {
        return IsMatch(s, p, 0, 0);
    }

    private bool IsMatch(string s, string p, int sIndex, int pIndex)
    {
        if (pIndex == p.Length)
        {
            return sIndex == s.Length;
        }

        const char anyModifier = '.';
        const char multipleModifier = '*';

        var patternSymbol = p[pIndex];
        var hasMultipleModifier = pIndex + 1 < p.Length && p[pIndex + 1] == multipleModifier;

        if (!hasMultipleModifier)
        {
            return sIndex < s.Length && (patternSymbol == anyModifier || patternSymbol == s[sIndex]) &&
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
