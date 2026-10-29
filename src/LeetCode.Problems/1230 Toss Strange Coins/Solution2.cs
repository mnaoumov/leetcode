namespace LeetCode.Problems._1230_Toss_Strange_Coins;

/// <summary>
/// https://leetcode.com/submissions/detail/938742448/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public double ProbabilityOfHeads(double[] prob, int target)
    {
        var dp = new DynamicProgramming<(int index, int headsCount), double>((key, recursiveFunc) =>
        {
            var (index, headsCount) = key;

            if (index + headsCount > prob.Length)
            {
                return 0;
            }

            if (index == prob.Length)
            {
                return 1;
            }

            return (headsCount > 0 ? prob[index] * recursiveFunc((index + 1, headsCount - 1)) : 0)
                   + (1 - prob[index]) * recursiveFunc((index + 1, headsCount));
        });

        return dp.GetOrCalculate((0, target));
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
