namespace LeetCode.Problems._2327_Number_of_People_Aware_of_a_Secret;

/// <summary>
/// https://leetcode.com/problems/number-of-people-aware-of-a-secret/submissions/1764486059/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int PeopleAwareOfSecret(int n, int delay, int forget)
    {
        var dp = new DynamicProgramming<(int day, int secretKnownDaysCount), int>((key, recursiveFunc) =>
        {
            var (day, secretKnownDaysCount) = key;

            if (day <= secretKnownDaysCount)
            {
                return 0;
            }

            if (day == 1)
            {
                return 1;
            }

            if (secretKnownDaysCount > 0)
            {
                return recursiveFunc((day - 1, secretKnownDaysCount - 1));
            }

            return Enumerable.Range(delay, forget - delay)
                .Select(secretKnownDaysCount2 => recursiveFunc((day - 1, secretKnownDaysCount2 - 1))).Sum();
        });

        return Enumerable.Range(0, forget)
            .Select(secretKnownDaysCount => dp.GetOrCalculate((n, secretKnownDaysCount))).Sum();
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
