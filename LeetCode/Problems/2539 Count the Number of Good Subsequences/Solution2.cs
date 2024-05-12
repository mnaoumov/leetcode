using JetBrains.Annotations;

namespace LeetCode.Problems._2539_Count_the_Number_of_Good_Subsequences;

/// <summary>
/// https://leetcode.com/submissions/detail/880984098/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int CountGoodSubsequences(string s)
    {
        const int modulo = 1_000_000_007;

        var factorialDp = new DynamicProgramming<int, int>((k, recursiveFunc) =>
        {
            if (k == 1)
            {
                return 1;
            }

            return (int) (1L * k * recursiveFunc(k - 1) % modulo);
        });

        var inverseDp = new DynamicProgramming<int, int>((k, recursiveFunc) =>
        {
            if (k == 1)
            {
                return 1;
            }

            return (int) ((2 * modulo - 1L * (modulo / k) * recursiveFunc(modulo % k) % modulo) % modulo);
        });

        var inverseFactorialDp = new DynamicProgramming<int, int>((k, recursiveFunc) =>
        {
            if (k <= 1)
            {
                return 1;
            }

            return (int) (1L * Inverse(k) * recursiveFunc(k - 1) % modulo);
        });

        var letterCounts = s.GroupBy(letter => letter).Select(g => g.Count()).ToArray();
        var maxLetterCount = letterCounts.Max();
        var result = 0;

        for (var equalLetterCount = 1; equalLetterCount <= maxLetterCount; equalLetterCount++)
        {
            var prod = letterCounts.Where(letterCount => letterCount >= equalLetterCount).Aggregate(1L, (current, letterCount) => current * (1 + Choose(letterCount, equalLetterCount)) % modulo);
            result = (result + (int) prod - 1) % modulo;
        }

        return result;

        int Choose(int m, int k)
        {
            long result2 = Factorial(m);
            result2 = result2 * InverseFactorial(k) % modulo;
            result2 = result2 * InverseFactorial(m - k) % modulo;
            return (int) result2;
        }

        int Factorial(int k) => factorialDp.GetOrCalculate(k);
        int InverseFactorial(int k) => inverseFactorialDp.GetOrCalculate(k);
        int Inverse(int k) => inverseDp.GetOrCalculate(k);
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
