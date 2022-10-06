namespace LeetCode._0044_Wildcard_Matching;

/// <summary>
/// https://leetcode.com/submissions/detail/208757970/
/// </summary>
public class BadSolution1Lte : ISolution
{
    public bool IsMatch(string s, string p)
    {
        return IsMatch(s, p, 0, 0);
    }

    private bool IsMatch(string s, string p, int sIndex, int pIndex)
    {
        const char singleWildcardSymbol = '?';
        const char multipleWildcardSymbol = '*';

        if (pIndex == p.Length)
        {
            return sIndex == s.Length;
        }
        var patternSymbol = p[pIndex];

        if (patternSymbol == multipleWildcardSymbol)
        {
            for (int afterWildcardIndex = sIndex; afterWildcardIndex <= s.Length; afterWildcardIndex++)
            {
                if (IsMatch(s, p, afterWildcardIndex, pIndex + 1))
                {
                    return true;
                }
            }

            return false;
        }
        else
        {
            return sIndex < s.Length && (s[sIndex] == patternSymbol || patternSymbol == singleWildcardSymbol) &&
                   IsMatch(s, p, sIndex + 1, pIndex + 1);
        }
    }
}