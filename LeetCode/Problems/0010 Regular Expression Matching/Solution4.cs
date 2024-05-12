#pragma warning disable
using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0010_Regular_Expression_Matching;

/// <summary>
/// https://leetcode.com/submissions/detail/808310678/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    private bool?[,] _resultsCache;
    private string _string;
    private string _pattern;

    public bool IsMatch(string s, string p)
    {
        _resultsCache = new bool?[s.Length + 1, p.Length + 1];
        _string = s;
        _pattern = p;
        return IsMatchCached(0, 0);
    }

    private bool IsMatchCached(int stringStartIndex, int patternStartIndex)
    {
        if (_resultsCache[stringStartIndex, patternStartIndex] is { } cachedResult)
        {
            return cachedResult;
        }

        var result = IsMatch(stringStartIndex, patternStartIndex);
        _resultsCache[stringStartIndex, patternStartIndex] = result;
        return result;
    }

    private bool IsMatch(int stringStartIndex, int patternStartIndex)
    {
        var isEndOfPattern = patternStartIndex == _pattern.Length;
        var isEndOfString = stringStartIndex == _string.Length;

        if (isEndOfPattern)
        {
            return isEndOfString;
        }

        var patternSymbol = _pattern[patternStartIndex];
        const char asteriskSymbol = '*';
        const char dotSymbol = '.';
        var hasAsterisk = patternStartIndex + 1 < _pattern.Length && _pattern[patternStartIndex + 1] == asteriskSymbol;
        var isMatchingSymbol = !isEndOfString && (patternSymbol == dotSymbol || patternSymbol == _string[stringStartIndex]);

        if (!hasAsterisk)
        {
            return isMatchingSymbol && IsMatchCached(stringStartIndex + 1, patternStartIndex + 1);
        }
        else
        {
            return IsMatchCached(stringStartIndex, patternStartIndex + 2) || isMatchingSymbol && IsMatchCached(stringStartIndex + 1, patternStartIndex);
        }
    }
}
