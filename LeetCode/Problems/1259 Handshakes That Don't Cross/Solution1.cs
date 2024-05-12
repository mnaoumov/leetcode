using JetBrains.Annotations;

namespace LeetCode.Problems._1259_Handshakes_That_Don_t_Cross;

/// <summary>
/// https://leetcode.com/submissions/detail/902646800/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int NumberOfWays(int numPeople)
    {
        var dp = new DynamicProgramming<int, int>((n, recursiveFunc) =>
        {
            if (n == 0)
            {
                return 1;
            }

            var result = 0;

            for (var i = 2; i <= n; i += 2)
            {
                result += recursiveFunc(i - 2) * recursiveFunc(n - i);
            }

            return result;
        });

        return dp.GetOrCalculate(numPeople);
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
