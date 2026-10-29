namespace LeetCode.Problems._3180_Maximum_Total_Reward_Using_Operations_I;

/// <summary>
/// https://leetcode.com/submissions/detail/1282336706/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaxTotalReward(int[] rewardValues)
    {
        Array.Sort(rewardValues);

        var dp = new DynamicProgramming<(int index, int totalReward), int>((key, recursiveFunc) =>
        {
            var (index, totalReward) = key;

            if (index == rewardValues.Length)
            {
                return totalReward;
            }

            var ans = recursiveFunc((index + 1, totalReward));

            if (rewardValues[index] > totalReward)
            {
                ans = Math.Max(ans, recursiveFunc((index + 1, totalReward + rewardValues[index])));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0));
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
