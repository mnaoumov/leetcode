using JetBrains.Annotations;

namespace LeetCode._2431_Maximize_Total_Tastiness_of_Purchased_Fruits;

/// <summary>
/// https://leetcode.com/submissions/detail/895683275/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxTastiness(int[] price, int[] tastiness, int maxAmount, int maxCoupons)
    {
        var dp = new DynamicProgramming<(int index, int amountLeft, int couponsLeft), int>((key, recursiveFunc) =>
        {
            var (index, amountLeft, couponsLeft) = key;

            if (index == price.Length || amountLeft == 0)
            {
                return 0;
            }

            var fullPrice = price[index];

            var result = recursiveFunc((index + 1, amountLeft, couponsLeft));

            if (fullPrice <= amountLeft)
            {
                result = Math.Max(result, tastiness[index] + recursiveFunc((index + 1, amountLeft - fullPrice, couponsLeft)));
            }

            var halfPrice = fullPrice / 2;

            if (halfPrice <= amountLeft && couponsLeft > 0)
            {
                result = Math.Max(result,
                    tastiness[index] + recursiveFunc((index + 1, amountLeft - halfPrice, couponsLeft - 1)));
            }

            return result;
        });

        return dp.GetOrCalculate((0, maxAmount, maxCoupons));
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
