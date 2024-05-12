using JetBrains.Annotations;

namespace LeetCode._2533_Number_of_Good_Binary_Strings;

/// <summary>
/// https://leetcode.com/submissions/detail/879643842/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int GoodBinaryStrings(int minLength, int maxLength, int oneGroup, int zeroGroup)
    {
        const int modulo = 1_000_000_007;

        var dp = new DynamicProgramming<(int minLength, int maxLength), int>(
            (key, recursiveFunc) =>
            {
                var (minLength2, maxLength2) = key;

                if (maxLength2 < 0)
                {
                    return 0;
                }

                var startWithOnes = recursiveFunc((minLength2 - oneGroup, maxLength2 - oneGroup));
                var startWithZeros = recursiveFunc((minLength2 - zeroGroup, maxLength2 - zeroGroup));

                return (startWithOnes + startWithZeros + (minLength2 <= 0 ? 1 : 0)) % modulo;
            });

        return dp.GetOrCalculate((minLength, maxLength));
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
