namespace LeetCode.Problems._1039_Minimum_Score_Triangulation_of_Polygon;

/// <summary>
/// https://leetcode.com/problems/minimum-score-triangulation-of-polygon/submissions/1785902296/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinScoreTriangulation(int[] values)
    {
        var dp = new DynamicProgramming<(int startIndex, int endIndex), int>((key, getOrCalculate) =>
        {
            var (startIndex, endIndex) = key;

            if (endIndex - startIndex < 2)
            {
                return 0;
            }

            var ans = int.MaxValue;

            for (var splitIndex = startIndex + 1; splitIndex < endIndex; splitIndex++)
            {
                ans = Math.Min(ans, values[startIndex] * values[splitIndex] * values[endIndex] +  getOrCalculate((startIndex, splitIndex)) + getOrCalculate((splitIndex, endIndex)));
            }

            return ans;
        });

        var n = values.Length;
        return dp.GetOrCalculate((0, n - 1));
    }

    private static string ToString(IEnumerable<int> values) => string.Join(' ', values);

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
