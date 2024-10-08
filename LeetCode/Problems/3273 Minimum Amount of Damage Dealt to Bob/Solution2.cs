namespace LeetCode.Problems._3273_Minimum_Amount_of_Damage_Dealt_to_Bob;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-138/submissions/detail/1374329349/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public long MinDamage(int power, int[] damage, int[] health)
    {
        var n = damage.Length;
        
        var dp = new DynamicProgramming<string, long>((killedEnemiesStr, recursiveFunc) =>
        {
            var killedEnemies = killedEnemiesStr.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();

            if (killedEnemies.Count == n)
            {
                return 0;
            }

            var ans = long.MaxValue;

            var totalDamage = 0L;

            for (var i = 0; i < n; i++)
            {
                if (killedEnemies.Contains(i))
                {
                    continue;
                }

                totalDamage += damage[i];
            }

            for (var i = 0; i < n; i++)
            {
                if (!killedEnemies.Add(i))
                {
                    continue;
                }

                var hitsCount = (health[i] + power - 1) / power;

                var nextKilledEnemiesStr = string.Join(' ', killedEnemies.OrderBy(x => x));
                ans = Math.Min(ans, totalDamage * hitsCount + recursiveFunc(nextKilledEnemiesStr));
                killedEnemies.Remove(i);
            }

            return ans;
        });

        return dp.GetOrCalculate("");
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
