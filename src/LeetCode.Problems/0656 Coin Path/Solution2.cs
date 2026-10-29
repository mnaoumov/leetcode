namespace LeetCode.Problems._0656_Coin_Path;

/// <summary>
/// https://leetcode.com/problems/coin-path/submissions/1802123175/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<int> CheapestJump(int[] coins, int maxJump)
    {
        const int impossible = -1;

        if (coins[^1] == impossible)
        {
            return Array.Empty<int>();
        }

        var n = coins.Length;
        var dp = new DynamicProgramming<int, (int cost, int[] path)>((index, getOrCalculate) =>
        {
            var enterCost = coins[index - 1];
            
            if (index == n)
            {
                return (enterCost, new[] { n });
            }

            if (enterCost == impossible)
            {
                return (impossible, Array.Empty<int>());
            }

            var cost = int.MaxValue;
            var path = Array.Empty<int>();

            for (var k = 1; k <= Math.Min(n - index, maxJump); k++)
            {
                var (nextCost, nextPath) = getOrCalculate(index + k);

                if (nextCost == impossible || enterCost + nextCost >= cost)
                {
                    continue;
                }

                cost = enterCost + nextCost;
                path = nextPath.Prepend(index).ToArray();
            }

            if (cost == int.MaxValue)
            {
                cost = impossible;
            }

            return (cost, path);
        });

        return dp.GetOrCalculate(1).path;
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
