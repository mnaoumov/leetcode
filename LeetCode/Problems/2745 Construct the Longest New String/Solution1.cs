using JetBrains.Annotations;

namespace LeetCode.Problems._2745_Construct_the_Longest_New_String;

/// <summary>
/// https://leetcode.com/submissions/detail/978573665/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestString(int x, int y, int z)
    {
        var dp = new DynamicProgramming<(int aaCount, int bbCount, int abCount, char lastLetter), int>((key, recursiveFunc) =>
        {
            var (aaCount, bbCount, abCount, lastLetter) = key;
            var ans = 0;

            if (aaCount > 0 && lastLetter != 'A')
            {
                ans = Math.Max(ans, 2 + recursiveFunc((aaCount - 1, bbCount, abCount, 'A')));
            }

            if (bbCount > 0 && lastLetter != 'B')
            {
                ans = Math.Max(ans, 2 + recursiveFunc((aaCount, bbCount - 1, abCount, 'B')));
            }

            if (abCount > 0 && lastLetter != 'A')
            {
                ans = Math.Max(ans, 2 + recursiveFunc((aaCount, bbCount, abCount - 1, 'B')));
            }

            return ans;
        });

        return dp.GetOrCalculate((x, y, z, default));
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
