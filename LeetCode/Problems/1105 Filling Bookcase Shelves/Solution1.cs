using JetBrains.Annotations;

namespace LeetCode.Problems._1105_Filling_Bookcase_Shelves;

/// <summary>
/// https://leetcode.com/submissions/detail/1339015684/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinHeightShelves(int[][] books, int shelfWidth)
    {
        var n = books.Length;

        var dp = new DynamicProgramming<(int index, int usedWidth, int usedHeight), int>((key, recursiveFunc) =>
        {
            var (index, usedWidth, usedHeight) = key;

            if (index == n)
            {
                return usedHeight;
            }

            var book = books[index];
            var thickness = book[0];
            var height = book[1];

            var ans = height + recursiveFunc((index + 1, thickness, height));

            var newUsedWidth = thickness + usedWidth;

            if (newUsedWidth <= shelfWidth)
            {
                ans = Math.Min(ans, recursiveFunc((index + 1, newUsedWidth, Math.Max(usedHeight, height))));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0, 0));
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
