using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0044_Wildcard_Matching;

/// <summary>
/// https://leetcode.com/submissions/detail/814705661/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    private const char AnyAmountSymbol = '*';
    private const char SingleSymbol = '?';
    private bool?[,] _cache = null!;
    public bool IsMatch(string s, string p)
    {
        _cache = new bool?[s.Length + 1, p.Length + 1];
        return IsMatchIndexed(0, 0);

        bool IsMatchIndexed(int sIndex, int pIndex)
        {
            if (_cache[sIndex, pIndex] is not { } result)
            {
                _cache[sIndex, pIndex] = result = Impl();
            }

            return result;

            bool Impl()
            {
                if (sIndex >= s.Length)
                {
                    if (pIndex >= p.Length)
                    {
                        return true;
                    }

                    if (p[pIndex] == AnyAmountSymbol)
                    {
                        return IsMatchIndexed(sIndex, pIndex + 1);
                    }

                    return false;
                }

                if (pIndex >= p.Length)
                {
                    return false;
                }

                var pSymbol = p[pIndex];
                var sSymbol = s[sIndex];

                switch (pSymbol)
                {
                    case AnyAmountSymbol:
                        return IsMatchIndexed(sIndex, pIndex + 1) || IsMatchIndexed(sIndex + 1, pIndex);
                    case SingleSymbol:
                        return IsMatchIndexed(sIndex + 1, pIndex + 1);
                    default:
                        return pSymbol == sSymbol && IsMatchIndexed(sIndex + 1, pIndex + 1);
                }
            }
        }

    }
}
