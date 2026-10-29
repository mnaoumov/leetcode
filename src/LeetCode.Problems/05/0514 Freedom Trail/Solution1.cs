namespace LeetCode.Problems._0514_Freedom_Trail;

/// <summary>
/// https://leetcode.com/submissions/detail/1242874256/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindRotateSteps(string ring, string key)
    {
        var n = ring.Length;

        var letterIndices = Enumerable.Range(0, n).GroupBy(i => ring[i]).ToDictionary(g => g.Key, g => g.ToArray());

        var dp = new DynamicProgramming<(int ringIndex, int keyIndex), int>((dpKey, recursiveFunc) =>
        {
            var (ringIndex, keyIndex) = dpKey;

            if (keyIndex == key.Length)
            {
                return 0;
            }

            var letter = key[keyIndex];

            var ans = int.MaxValue;

            foreach (var ringLetterIndex in letterIndices[letter])
            {
                var ringDistance = Math.Abs(ringLetterIndex - ringIndex);
                ringDistance = Math.Min(ringDistance, n - ringDistance);
                ans = Math.Min(ans, ringDistance + 1 + recursiveFunc((ringLetterIndex, keyIndex + 1)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0));
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

