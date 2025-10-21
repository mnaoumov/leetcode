namespace LeetCode.Problems._0656_Coin_Path;

/// <summary>
/// https://leetcode.com/problems/coin-path/submissions/1802119878/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IList<int> CheapestJump(int[] coins, int maxJump)
    {
        var n = coins.Length;
        const int impossible = int.MaxValue;
        var dp = new DynamicProgramming<int, (int cost, int[] path)>((index, getOrCalculate) =>
        {
            var enterCost = coins[index - 1];
            
            if (index == n)
            {
                return (enterCost, new[] { n });
            }

            if (enterCost == -1)
            {
                return (impossible, Array.Empty<int>());
            }

            var cost = impossible;
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
