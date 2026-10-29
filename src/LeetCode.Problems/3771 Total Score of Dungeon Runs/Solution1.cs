namespace LeetCode.Problems._3771_Total_Score_of_Dungeon_Runs;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-479/problems/total-score-of-dungeon-runs/submissions/1848855583/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long TotalScore(int hp, int[] damage, int[] requirement)
    {
        var n = damage.Length;
        var dp = new DynamicProgramming<(int roomNumber, int health), long>((key, getOrCalculate) =>
        {
            var (roomNumber, health) = key;

            if (roomNumber > n)
            {
                return 0;
            }

            health -= damage[roomNumber - 1];
            return (health >= requirement[roomNumber - 1] ? 1 : 0) + getOrCalculate((roomNumber + 1, health));
        });

        return Enumerable.Range(1, n).Select(i => dp.GetOrCalculate((i, hp))).Sum();
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
