namespace LeetCode.Problems._3654_Minimum_Sum_After_Divisible_Sum_Deletions;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-463/problems/minimum-sum-after-divisible-sum-deletions/submissions/1738014056/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public long MinArraySum(int[] nums, int k)
    {
        var dp = new DynamicProgramming<string, long>((arrStr, recursiveFunc) =>
        {
            var arr = arrStr.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var ans = arr.Select(x => (long) x).Sum();

            var prefixSumRemainderIndicesMap = Enumerable.Range(0, k).Select(_ => new List<int>()).ToArray();
            prefixSumRemainderIndicesMap[0].Add(-1);
            var prefixSumRemainder = 0;

            for (var index = 0; index < arr.Length; index++)
            {
                prefixSumRemainder += arr[index];
                prefixSumRemainder %= k;

                // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
                foreach (var previousIndex in prefixSumRemainderIndicesMap[prefixSumRemainder])
                {
                    var newArrStr = string.Join(' ', arr.Take(previousIndex + 1).Concat(arr.Skip(index + 1)));
                    var newMin = recursiveFunc(newArrStr);
                    ans = Math.Min(ans, newMin);
                }

                prefixSumRemainderIndicesMap[prefixSumRemainder].Add(index);
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
