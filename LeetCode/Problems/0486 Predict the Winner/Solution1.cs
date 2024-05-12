using JetBrains.Annotations;

namespace LeetCode.Problems._0486_Predict_the_Winner;

/// <summary>
/// https://leetcode.com/submissions/detail/954840875/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool PredictTheWinner(int[] nums)
    {
        var dp = new DynamicProgramming<(int minIndex, int maxIndex, int player1Score, bool isFirstPlayer), int>((key, recursiveFunc) =>
        {
            var (minIndex, maxIndex, player1Score, isFirstPlayer) = key;

            if (minIndex > maxIndex)
            {
                return player1Score;
            }

            return isFirstPlayer
                ? Math.Max(
                    recursiveFunc((minIndex + 1, maxIndex, player1Score + nums[minIndex], false)),
                    recursiveFunc((minIndex, maxIndex - 1, player1Score + nums[maxIndex], false))
                )
                : Math.Min(
                    recursiveFunc((minIndex + 1, maxIndex, player1Score, true)),
                    recursiveFunc((minIndex, maxIndex - 1, player1Score, true))
                );
        });

        var player1Score = dp.GetOrCalculate((0, nums.Length - 1, 0, true));
        return player1Score >= nums.Sum() - player1Score;
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
