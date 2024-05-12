using JetBrains.Annotations;

namespace LeetCode.Problems._2478_Number_of_Beautiful_Partitions;

/// <summary>
/// https://leetcode.com/problems/number-of-beautiful-partitions/submissions/846690628/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    private const int Modulo = 1000000007;

    public int BeautifulPartitions(string s, int k, int minLength)
    {
        var primeDigitIndices = new HashSet<int>();

        for (var i = 0; i < s.Length; i++)
        {
            switch (s[i])
            {
                case '2':
                case '3':
                case '5':
                case '7':
                    primeDigitIndices.Add(i);
                    break;
            }
        }

        var dp = new DynamicProgramming<(int startIndex, int partsLeft), int>((key, recursiveFunc) =>
        {
            var (startIndex, partsLeft) = key;

            if (partsLeft == 0 || startIndex >= s.Length)
            {
                if (partsLeft == 0 && startIndex >= s.Length)
                {
                    return 1;
                }

                return 0;
            }

            if (!primeDigitIndices.Contains(startIndex))
            {
                return 0;
            }

            var result = 0;

            for (var endIndex = startIndex + minLength - 1; endIndex + (partsLeft - 1) * minLength < s.Length; endIndex++)
            {
                if (!primeDigitIndices.Contains(endIndex))
                {
                    result = (result + recursiveFunc((endIndex + 1, partsLeft - 1))) % Modulo;
                }
            }

            return result;
        });


        return dp.GetOrCalculate((0, k));
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
