using JetBrains.Annotations;

namespace LeetCode._1416_Restore_The_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/938601962/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int NumberOfArrays(string s, int k)
    {
        const int modulo = 1_000_000_007;
        var n = s.Length;

        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
        {
            if (index == n)
            {
                return 1;
            }

            if (s[index] == '0')
            {
                return 0;
            }

            var number = 0;
            var result = 0;

            for (var i = index; i < n; i++)
            {
                var digit = s[i] - '0';
                number = number * 10 + digit;

                if (number > k)
                {
                    break;
                }

                result = (result + recursiveFunc(i + 1)) % modulo;
            }

            return result;
        });

        return dp.GetOrCalculate(0);
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            _func = func;
        }

        public TValue GetOrCalculate(TKey key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                _cache[key] = value = _func(key, GetOrCalculate);
            }

            return value;
        }
    }
}
