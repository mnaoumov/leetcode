namespace LeetCode.Problems._3186_Maximum_Total_Damage_With_Spell_Casting;

/// <summary>
/// https://leetcode.com/problems/maximum-total-damage-with-spell-casting/submissions/1797812934/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MaximumTotalDamage(int[] power)
    {
        var counts = power.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        var keys = counts.Keys.OrderBy(x => x).ToArray();

        var dp = new DynamicProgramming<int, long>((index, getOrCalculate) =>
        {
            if (index == keys.Length)
            {
                return 0;
            }

            var ans = getOrCalculate(index + 1);
            var key = keys[index];
            var nextIndex = index + 1;

            while (nextIndex < keys.Length && keys[nextIndex] < key + 2)
            {
                nextIndex++;
            }

            ans = Math.Max(ans, 1L * counts[key] * key + getOrCalculate(nextIndex));
            return ans;
        });

        return dp.GetOrCalculate(0);
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
