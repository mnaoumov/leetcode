using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1025_Divisor_Game;

/// <summary>
/// https://leetcode.com/submissions/detail/926846485/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool DivisorGame(int n)
    {
        var dp = new DynamicProgramming<int, bool>((number, recursiveFunc) =>
        {
            if (number == 1)
            {
                return false;
            }

            for (var i = 1; i < number; i++)
            {
                if (number % i != 0)
                {
                    continue;
                }

                if (!recursiveFunc(number - i))
                {
                    continue;
                }

                return false;
            }

            return true;
        });

        return dp.GetOrCalculate(n);
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
