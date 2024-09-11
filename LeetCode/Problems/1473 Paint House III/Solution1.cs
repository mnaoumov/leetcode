namespace LeetCode.Problems._1473_Paint_House_III;

/// <summary>
/// https://leetcode.com/submissions/detail/927279737/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinCost(int[] houses, int[][] cost, int m, int n, int target)
    {
        const int impossible = -1;

        var dp = new DynamicProgramming<(int index, int neighborhoodCountLeft, int previousNeighborhoodColor), int>((key, recursiveFunc) =>
        {
            var (index, neighborhoodCountLeft, previousNeighborhoodColor) = key;

            if (neighborhoodCountLeft < 0)
            {
                return impossible;
            }

            if (index == m)
            {
                return neighborhoodCountLeft == 0 ? 0 : impossible;
            }

            if (houses[index] != 0)
            {
                if (houses[index] != previousNeighborhoodColor)
                {
                    neighborhoodCountLeft--;
                }

                return recursiveFunc((index + 1, neighborhoodCountLeft, houses[index]));
            }

            var result = int.MaxValue;

            for (var color = 1; color <= n; color++)
            {
                if (houses[index] != 0 && houses[index] != color)
                {
                    continue;
                }

                var nextNeighborhoodCountLeft = color == previousNeighborhoodColor
                    ? neighborhoodCountLeft
                    : neighborhoodCountLeft - 1;

                var paintCost = houses[index] == 0 ? cost[index][color - 1] : 0;

                var nextCost = recursiveFunc((index + 1, nextNeighborhoodCountLeft, color));

                if (nextCost != impossible)
                {
                    result = Math.Min(result, paintCost + nextCost);
                }
            }

            return result == int.MaxValue ? impossible : result;
        });

        return dp.GetOrCalculate((0, target, -1));
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            _func = func;
        }

        public TValue GetOrCalculate(TKey key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                _cache[key] = value = _func(key, GetOrCalculate);
            }

            return value;
        }
    }
}
