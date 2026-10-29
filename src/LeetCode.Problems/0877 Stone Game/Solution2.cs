namespace LeetCode.Problems._0877_Stone_Game;

/// <summary>
/// https://leetcode.com/problems/stone-game/submissions/2091085995/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool StoneGame(int[] piles)
    {
        var dp = new DynamicProgramming<(int firstAvailablePileIndex, int pilesLeftCount), int>((key, getOrCalculate) =>
        {
            var (firstAvailablePileIndex, pilesLeftCount) = key;

            if (pilesLeftCount == 0)
            {
                return 0;
            }

            var takeFirstScoreDiff = piles[firstAvailablePileIndex]
                                     - getOrCalculate((firstAvailablePileIndex + 1, pilesLeftCount - 1));

            var takeLastScoreDiff = piles[firstAvailablePileIndex + pilesLeftCount - 1]
                                    - getOrCalculate((firstAvailablePileIndex, pilesLeftCount - 1));

            return Math.Max(takeFirstScoreDiff, takeLastScoreDiff);
        });

        return dp.GetOrCalculate((0, piles.Length)) >= 0;
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