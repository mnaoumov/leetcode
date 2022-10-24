using JetBrains.Annotations;

namespace LeetCode._0044_Wildcard_Matching;

/// <summary>
/// https://leetcode.com/submissions/detail/829022433/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
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

                    return p[pIndex] == AnyAmountSymbol && IsMatchIndexed(sIndex, pIndex + 1);
                }

                if (pIndex >= p.Length)
                {
                    return false;
                }

                var pSymbol = p[pIndex];
                var sSymbol = s[sIndex];

                return pSymbol switch
                {
                    AnyAmountSymbol => IsMatchIndexed(sIndex, pIndex + 1) || IsMatchIndexed(sIndex + 1, pIndex),
                    SingleSymbol => IsMatchIndexed(sIndex + 1, pIndex + 1),
                    _ => pSymbol == sSymbol && IsMatchIndexed(sIndex + 1, pIndex + 1)
                };
            }
        }

    }
}