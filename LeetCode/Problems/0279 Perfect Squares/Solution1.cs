using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0279_Perfect_Squares;

/// <summary>
/// https://leetcode.com/submissions/detail/197023413/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumSquares(int n)
    {
        var cache = new Dictionary<int, int>();
        return NumSquares(n, cache);
    }

    private int NumSquares(int n, Dictionary<int, int> cache)
    {
        if (!cache.ContainsKey(n))
        {
            cache[n] = NumSquaresInternal(n, cache);
        }

        return cache[n];
    }

    private int NumSquaresInternal(int n, Dictionary<int, int> cache)
    {
        if (n == 0)
        {
            return 0;
        }

        var result = int.MaxValue;
        for (int i = 1; i * i <= n; i++)
        {
            result = Math.Min(result, NumSquares(n - i * i, cache) + 1);
        }

        return result;
    }
}
