namespace LeetCode.Problems._2911_Minimum_Changes_to_Make_K_Semi_palindromes;

/// <summary>
/// https://leetcode.com/submissions/detail/1081078991/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinimumChanges(string s, int k)
    {
        var changesDp = new DynamicProgramming<(int start, int end), int>((key, _) =>
        {
            var (start, end) = key;

            if (start == end)
            {
                return int.MaxValue;
            }

            var len = end - start + 1;

            var ans = int.MaxValue;

            for (var d = 1; d <= len / 2; d++)
            {
                if (len % d != 0)
                {
                    continue;
                }

                var changesCount = 0;
                
                for (var j = 0; j < d; j++)
                {
                    var n = len / d;

                    for (var m = 0; m < n / 2; m++)
                    {
                        if (s[start + j + m * d] != s[start + j + (n - m - 1) * d])
                        {
                            changesCount++;
                        }
                    }
                }

                ans = Math.Min(ans, changesCount);
            }

            return ans;
        });


        var dp = new DynamicProgramming<(int start, int end, int partsCount), int>((key, recursiveFunc) =>
        {
            var (start, end, partsCount) = key;

            if (partsCount == 1)
            {
                return changesDp.GetOrCalculate((start, end));
            }

            var ans = int.MaxValue;

            for (var i = start + 1; i <= end - 2 * partsCount + 2; i++)
            {
                ans = Math.Min(ans, changesDp.GetOrCalculate((start, i)) + recursiveFunc((i + 1, end, partsCount - 1)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, s.Length - 1, k));
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
