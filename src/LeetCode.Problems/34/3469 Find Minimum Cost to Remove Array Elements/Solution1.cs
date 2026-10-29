namespace LeetCode.Problems._3469_Find_Minimum_Cost_to_Remove_Array_Elements;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-151/problems/find-minimum-cost-to-remove-array-elements/submissions/1559275290/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public int MinCost(int[] nums)
    {
        var dp = new DynamicProgramming<string, int>((numsStr, recursiveFunc) =>
        {
            var list = numsStr.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            if (list.Count < 3)
            {
                return list.Max();
            }

            var ans = int.MaxValue;
            var rest = list.Skip(3).ToList();

            for (var i = 0; i < 3; i++)
            {
                var max = Enumerable.Range(0, 3).Except(new[] { i }).Select(j => list[j]).Max();
                rest.Insert(0, list[i]);
                ans = Math.Min(ans, max + recursiveFunc(NumsToString(rest)));
                rest.RemoveAt(0);
            }

            return ans;
        });

        return dp.GetOrCalculate(NumsToString(nums));

        static string NumsToString(IEnumerable<int> arr) => string.Join(',', arr);
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
