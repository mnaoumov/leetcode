namespace LeetCode.Problems._1872_Stone_Game_VIII;

/// <summary>
/// https://leetcode.com/problems/stone-game-viii/submissions/2118134127/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int StoneGameVIII(int[] stones)
    {
        var n = stones.Length;
        var sums = new int[n + 1];

        for (var i = 0; i < n; i++)
        {
            sums[i + 1] = sums[i] + stones[i];
        }

        var dp = new DynamicProgramming<(int index, bool isAliceTurn), int>((key, getOrCalculate) =>
        {
            var (index, isAliceTurn) = key;

            if (index == n)
            {
                return 0;
            }

            var ans = isAliceTurn ? int.MinValue : int.MaxValue;

            if (index != 0)
            {
                ans = sums[index + 1] * (isAliceTurn ? 1 : -1) + getOrCalculate((index + 1, !isAliceTurn));
            }

            if (index + 1 < n)
            {
                var nextAns = getOrCalculate((index + 1, isAliceTurn));
                ans = isAliceTurn ? Math.Max(ans, nextAns) : Math.Min(ans, nextAns);
            }

            return ans;
        });

        return dp.GetOrCalculate((0, true));
    }

    private sealed class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
