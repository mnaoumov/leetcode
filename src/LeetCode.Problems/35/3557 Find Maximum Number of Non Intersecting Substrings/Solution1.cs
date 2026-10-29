namespace LeetCode.Problems._3557_Find_Maximum_Number_of_Non_Intersecting_Substrings;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-157/problems/find-maximum-number-of-non-intersecting-substrings/submissions/1643167750/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxSubstrings(string word)
    {
        var letterIndicesMap = new Dictionary<char, List<int>>();

        var n = word.Length;

        for (var i = 0; i < n; i++)
        {
            var letter = word[i];
            letterIndicesMap.TryAdd(letter, new List<int>());
            letterIndicesMap[letter].Add(i);
        }

        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
        {
            if (index == n)
            {
                return 0;
            }

            var ans = recursiveFunc(index + 1);


            var letter = word[index];
            var letterIndices = letterIndicesMap[letter];
            var indexOfIndex = letterIndices.BinarySearch(index + 3);
            if (indexOfIndex < 0)
            {
                indexOfIndex = ~indexOfIndex;
            }

            if (indexOfIndex == letterIndices.Count)
            {
                return ans;
            }

            var nextIndex = letterIndices[indexOfIndex];
            ans = Math.Max(ans, 1 + recursiveFunc(nextIndex + 1));
            return ans;
        });

        return dp.GetOrCalculate(0);
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
