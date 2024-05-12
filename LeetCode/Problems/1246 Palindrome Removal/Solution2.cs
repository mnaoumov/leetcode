using JetBrains.Annotations;

namespace LeetCode.Problems._1246_Palindrome_Removal;

/// <summary>
/// https://leetcode.com/submissions/detail/956177934/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinimumMoves(int[] arr)
    {
        var dp = new DynamicProgramming<(int i, int j), int>((key, recursiveFunc) =>
        {
            var (i, j) = key;

            if (j <= i)
            {
                return 1;
            }

            var ans = int.MaxValue;

            if (arr[i] == arr[j])
            {
                ans = recursiveFunc((i + 1, j - 1));
            }

            for (var k = i; k < j; k++)
            {
                ans = Math.Min(ans, recursiveFunc((i, k)) + recursiveFunc((k + 1, j)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, arr.Length - 1));
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
