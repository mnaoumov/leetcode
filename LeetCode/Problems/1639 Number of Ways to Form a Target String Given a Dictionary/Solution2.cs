namespace LeetCode.Problems._1639_Number_of_Ways_to_Form_a_Target_String_Given_a_Dictionary;

/// <summary>
/// https://leetcode.com/submissions/detail/934409493/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int NumWays(string[] words, string target)
    {
        const int mod = 1_000_000_007;

        var letterIndicesMap = new Dictionary<char, SortedSet<int>>();
        var counts = new Dictionary<(char letter, int index), int>();

        foreach (var word in words)
        {
            for (var i = 0; i < word.Length; i++)
            {
                var letter = word[i];
                letterIndicesMap.TryAdd(letter, new SortedSet<int>());
                letterIndicesMap[letter].Add(i);
                counts[(letter, i)] = counts.GetValueOrDefault((letter, i)) + 1;
            }
        }

        if (target.Any(letter => !letterIndicesMap.ContainsKey(letter)))
        {
            return 0;
        }

        var dp = new DynamicProgramming<(int targetLetterIndex, int minWordLetterIndex), int>((key, recursiveFunc) =>
        {
            var (targetLetterIndex, minWordLetterIndex) = key;

            if (targetLetterIndex == target.Length)
            {
                return 1;
            }

            var letter = target[targetLetterIndex];
            return letterIndicesMap[letter].GetViewBetween(minWordLetterIndex, int.MaxValue).Aggregate(0,
                (current, wordLetterIndex) => (int) ((current + 1L * counts[(letter, wordLetterIndex)] *
                    recursiveFunc((targetLetterIndex + 1, wordLetterIndex + 1))) % mod));
        });

        return dp.GetOrCalculate((0, 0));
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
