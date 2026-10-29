namespace LeetCode.Problems._3040_Maximum_Number_of_Operations_With_the_Same_Score_II;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-124/submissions/detail/1177905277/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxOperations(int[] nums)
    {
        var dp = new DynamicProgramming<(int startIndex, int endIndex, int score), int>((key, recursiveFunc) =>
        {
            var (startIndex, endIndex, score) = key;

            if (startIndex >= endIndex)
            {
                return 0;
            }

            var ans = 0;

            if (nums[startIndex] + nums[startIndex + 1] == score)
            {
                ans = Math.Max(ans, 1 + recursiveFunc((startIndex + 2, endIndex, score)));
            }

            if (nums[startIndex] + nums[endIndex] == score)
            {
                ans = Math.Max(ans, 1 + recursiveFunc((startIndex + 1, endIndex - 1, score)));
            }

            if (nums[endIndex - 1] + nums[endIndex] == score)
            {
                ans = Math.Max(ans, 1 + recursiveFunc((startIndex, endIndex - 2, score)));
            }

            return ans;
        });

        var possibleScores = new[] { nums[0] + nums[1], nums[0] + nums[^1], nums[^2] + nums[^1] }.Distinct();
        return possibleScores.Max(score => dp.GetOrCalculate((0, nums.Length - 1, score)));
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
