using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2466_Count_Ways_To_Build_Good_Strings;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-91/submissions/detail/842001364/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int CountGoodStrings(int low, int high, int zero, int one)
    {
        var dp = new DynamicProgramming<int, int>((prefixLength, recursiveFunc) =>
        {
            if (prefixLength > high)
            {
                return 0;
            }

            var result = 0;

            if (low <= prefixLength)
            {
                result++;
            }

            result += recursiveFunc(prefixLength + zero) +
                      recursiveFunc(prefixLength + one);

            return result;
        });


        return dp.GetOrCalculate(0);
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
