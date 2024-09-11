namespace LeetCode.Problems._1548_The_Most_Similar_Path_in_a_Graph;

/// <summary>
/// https://leetcode.com/submissions/detail/936005704/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> MostSimilar(int n, int[][] roads, string[] names, string[] targetPath)
    {
        var adjCities = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var road in roads)
        {
            adjCities[road[0]].Add(road[1]);
            adjCities[road[1]].Add(road[0]);
        }

        var dp = new DynamicProgramming<(int cityIndex, int targetPathIndex), (int distance, IEnumerable<int> path)>(
            (key, recursiveFunc) =>
            {
                var (cityIndex, targetPathIndex) = key;

                if (targetPathIndex == targetPath.Length)
                {
                    return (0, Enumerable.Empty<int>());
                }

                var (distance, path) = adjCities[cityIndex].Select(adjCity => recursiveFunc((adjCity, targetPathIndex + 1)))
                    .MinBy(x => x.distance);

                return (distance + (names[cityIndex] == targetPath[targetPathIndex] ? 0 : 1), path.Prepend(cityIndex));
            });

        return Enumerable.Range(0, n).Select(cityIndex => dp.GetOrCalculate((cityIndex, 0))).MinBy(x => x.distance).path.ToArray();
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
