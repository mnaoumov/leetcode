namespace LeetCode.Problems._1140_Stone_Game_II;

/// <summary>
/// https://leetcode.com/submissions/detail/957450831/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int StoneGameII(int[] piles)
    {
        var sum = 0;
        var prefixSums = piles.Select(pile => sum += pile).Prepend(0).ToArray();

        var dp = new DynamicProgramming<(int index, int m, bool isAliceTurn), int>((key, recursiveFunc) =>
        {
            var (index, m, isAliceTurn) = key;

            if (index == piles.Length)
            {
                return 0;
            }

            var subResults = Enumerable.Range(1, Math.Min(2 * m, piles.Length - index))
                .Select(x => (isAliceTurn ? prefixSums[index + x] - prefixSums[index] : 0)
                             + recursiveFunc((index + x, Math.Max(m, x), !isAliceTurn)));

            return isAliceTurn ? subResults.Max() : subResults.Min();
        });

        return dp.GetOrCalculate((0, 1, true));
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
