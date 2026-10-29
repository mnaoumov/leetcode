namespace LeetCode.Problems._0960_Delete_Columns_to_Make_Sorted_III;

/// <summary>
/// https://leetcode.com/problems/delete-columns-to-make-sorted-iii/submissions/1862782501/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinDeletionSize(string[] strs)
    {
        const int noIndex = -1;
        var m = strs[0].Length;
        var dp = new DynamicProgramming<(int index, int lastIndex), int>((key, getOrCalculate) =>
        {
            var (index, lastIndex) = key;

            if (index == m)
            {
                return 0;
            }

            var ans = getOrCalculate((index + 1, lastIndex));

            if (lastIndex == noIndex ||
                strs.All(s => s[index] >= s[lastIndex]))
            {
                ans = Math.Max(ans, 1 + getOrCalculate((index + 1, index)));
            }

            return ans;
        });

        return m - dp.GetOrCalculate((0, 0));
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
