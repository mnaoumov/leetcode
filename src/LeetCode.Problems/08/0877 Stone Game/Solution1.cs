namespace LeetCode.Problems._0877_Stone_Game;

/// <summary>
/// https://leetcode.com/problems/stone-game/submissions/2091075668/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public bool StoneGame(int[] piles)
    {
        var dp = new DynamicProgramming<(int firstAvailablePileIndex, int pilesLeftCount, int currentPlayerScore, int otherPlayerScore), bool>((key, getOrCalculate) =>
        {
            var (firstAvailablePileIndex, pilesLeftCount, currentPlayerScore, otherPlayerScore) = key;

            if (pilesLeftCount == 0)
            {
                return currentPlayerScore >= otherPlayerScore;
            }

            var takeFirstResult = !getOrCalculate((firstAvailablePileIndex + 1, pilesLeftCount - 1, otherPlayerScore,
                currentPlayerScore + piles[firstAvailablePileIndex]));

            var takeLastResult = !getOrCalculate((firstAvailablePileIndex, pilesLeftCount - 1, otherPlayerScore,
                currentPlayerScore + piles[firstAvailablePileIndex + pilesLeftCount - 1]));

            return takeFirstResult || takeLastResult;
        });

        return dp.GetOrCalculate((0, piles.Length, 0, 0));
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
