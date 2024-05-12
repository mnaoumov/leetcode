using JetBrains.Annotations;

namespace LeetCode._0808_Soup_Servings;

/// <summary>
/// https://leetcode.com/submissions/detail/1073864429/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public double SoupServings(int n)
    {
        var dp = new DynamicProgramming<(int a, int b, Mode mode), double>((key, recursiveFunc) =>
        {
            var (a, b, mode) = key;

            if (a == 0)
            {
                var desiredMode = b == 0 ? Mode.ABSameTime : Mode.AFirst;
                return mode == desiredMode ? 1 : 0;
            }

            if (b == 0)
            {
                return 0;
            }

            return 0.25 * (Serve(100, 0) + Serve(75, 25) + Serve(50, 50) + Serve(25, 75));

            double Serve(int serveA, int serveB) => recursiveFunc((Math.Max(0, a - serveA), Math.Max(0, b - serveB), mode));
        });

        return dp.GetOrCalculate((n, n, Mode.AFirst)) + 0.5 * dp.GetOrCalculate((n, n, Mode.ABSameTime));
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

    private enum Mode
    {
        AFirst,
        // ReSharper disable once InconsistentNaming
        ABSameTime
    }
}
