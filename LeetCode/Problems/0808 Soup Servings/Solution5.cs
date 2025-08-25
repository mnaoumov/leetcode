namespace LeetCode.Problems._0808_Soup_Servings;

/// <summary>
/// https://leetcode.com/problems/soup-servings/submissions/1727438814/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public double SoupServings(int n)
    {
        var m = (n + 24) / 25;

        if (m >= 1000)
        {
            return 1;
        }

        var dp = new DynamicProgramming<(int a, int b), (double aFinishedFirstProbability, double aAndBBothFinishedProbability)>((key, recursiveFunc) =>
        {
            var (a, b) = key;

            if (a <= 0 && b <= 0)
            {
                return (0, 1);
            }

            if (a <= 0)
            {
                return (1, 0);
            }

            if (b <= 0)
            {
                return (0, 0);
            }

            var res1 = recursiveFunc((a - 4, b));
            var res2 = recursiveFunc((a - 3, b - 1));
            var res3 = recursiveFunc((a - 2, b - 2));
            var res4 = recursiveFunc((a - 1, b - 3));
            return (
                0.25 * (res1.aFinishedFirstProbability + res2.aFinishedFirstProbability +
                        res3.aFinishedFirstProbability + res4.aFinishedFirstProbability),
                0.25 * (res1.aAndBBothFinishedProbability + res2.aAndBBothFinishedProbability +
                        res3.aAndBBothFinishedProbability + res4.aAndBBothFinishedProbability)
            );
        });

        var res = dp.GetOrCalculate((m, m));
        return res.aFinishedFirstProbability + res.aAndBBothFinishedProbability / 2;
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
