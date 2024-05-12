using JetBrains.Annotations;

namespace LeetCode._2533_Number_of_Good_Binary_Strings;

/// <summary>
/// https://leetcode.com/submissions/detail/879641751/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    private const int Modulo = 1_000_000_007;

    public int GoodBinaryStrings(int minLength, int maxLength, int oneGroup, int zeroGroup)
    {
        var dp = new DynamicProgramming<(int minLength, int maxLength, int startingGroup, int otherGroup), int>(
            (key, recursiveFunc) =>
            {
                var (minLength2, maxLength2, startingGroup, otherGroup) = key;
                var result = minLength2 <= 0 && 0 <= maxLength2 ? 1 : 0;

                if (maxLength2 < startingGroup)
                {
                    return result;
                }

                for (var prefixLength = startingGroup; prefixLength <= maxLength2; prefixLength += startingGroup)
                {
                    result = (result + recursiveFunc((minLength2 - prefixLength, maxLength2 - prefixLength, otherGroup,
                        startingGroup))) % Modulo;
                }

                return result;
            });

        return dp.GetOrCalculate((minLength, maxLength, oneGroup, zeroGroup)) +
               dp.GetOrCalculate((minLength, maxLength, zeroGroup, oneGroup));
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
