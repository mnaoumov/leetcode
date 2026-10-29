namespace LeetCode.Problems._1182_Shortest_Distance_to_Target_Color;

/// <summary>
/// https://leetcode.com/submissions/detail/942733660/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> ShortestDistanceColor(int[] colors, int[][] queries)
    {
        const int impossible = int.MaxValue;

        var dp = new DynamicProgramming<(int index, int color, int direction), int>((key, recursiveFunc) =>
        {
            var (index, color, direction) = key;

            if (index < 0 || index >= colors.Length)
            {
                return impossible;
            }

            if (colors[index] == color)
            {
                return 0;
            }

            var subResult = recursiveFunc((index + direction, color, direction));

            if (subResult == impossible)
            {
                return impossible;
            }

            return 1 + subResult;
        });

        return queries.Select(Answer).ToArray();

        int Answer(int[] query)
        {
            var ans = Math.Min(dp.GetOrCalculate((query[0], query[1], 1)), dp.GetOrCalculate((query[0], query[1], -1)));
            return ans == impossible ? -1 : ans;
        }
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
