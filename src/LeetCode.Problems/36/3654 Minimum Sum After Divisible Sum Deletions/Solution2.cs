namespace LeetCode.Problems._3654_Minimum_Sum_After_Divisible_Sum_Deletions;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-463/problems/minimum-sum-after-divisible-sum-deletions/submissions/1738003190/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public long MinArraySum(int[] nums, int k)
    {
        var dp = new DynamicProgramming<string, long>((arrStr, recursiveFunc) =>
        {
            var arr = arrStr.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var ans = arr.Select(x => (long)x).Sum();

            var remainderIndices = Enumerable.Range(0, k).Select(_ => new List<int>()).ToArray();
            remainderIndices[0].Add(-1);
            var prefixSum = 0;

            for (var index = 0; index < arr.Length; index++)
            {
                prefixSum += arr[index];
                prefixSum %= k;

                ans = remainderIndices[prefixSum]
                    .Select(previousIndex => string.Join(' ', arr.Take(previousIndex).Concat(arr.Skip(index + 1))))
                    .Select(recursiveFunc)
                    .Prepend(ans)
                    .Min();
            }

            return ans;
        });

        return dp.GetOrCalculate(string.Join(' ', nums));
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
