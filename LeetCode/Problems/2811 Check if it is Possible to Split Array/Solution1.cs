using JetBrains.Annotations;

namespace LeetCode.Problems._2811_Check_if_it_is_Possible_to_Split_Array;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-357/submissions/detail/1013423327/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool CanSplitArray(IList<int> nums, int m)
    {
        var runningSum = 0;
        var runningSums = nums.Select(num => runningSum += num).ToArray();

        var n = nums.Count;

        var dp = new DynamicProgramming<(int from, int to), bool>((key, recursiveFunc) =>
        {
            var (from, to) = key;

            if (to - from == 1)
            {
                return true;
            }

            var sum = runningSums[to - 1] - (from == 0 ? 0 : runningSums[from - 1]);

            if (sum < m)
            {
                return false;
            }

            for (var splitIndex = from + 1; splitIndex < to; splitIndex++)
            {
                if (recursiveFunc((from, splitIndex)) && recursiveFunc((splitIndex, to)))
                {
                    return true;
                }
            }

            return false;
        });

        return dp.GetOrCalculate((0, n));
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
