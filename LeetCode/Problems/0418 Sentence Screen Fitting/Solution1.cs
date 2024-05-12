using JetBrains.Annotations;

namespace LeetCode._0418_Sentence_Screen_Fitting;

/// <summary>
/// https://leetcode.com/submissions/detail/956102529/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int WordsTyping(string[] sentence, int rows, int cols)
    {
        var dp = new DynamicProgramming<(int wordIndex, int rowsLeft), int>((key, recursiveFunc) =>
        {
            var (wordIndex, rowsLeft) = key;

            if (rowsLeft == 0)
            {
                return 0;
            }

            var columnIndex = 0;
            var currentWordIndex = wordIndex;
            var ans = 0;

            while (true)
            {
                var word = sentence[currentWordIndex];

                var isStart = columnIndex == 0;

                if (!isStart)
                {
                    columnIndex++;
                }

                columnIndex += word.Length;

                if (columnIndex > cols)
                {
                    if (isStart)
                    {
                        return 0;
                    }

                    return ans + recursiveFunc((currentWordIndex, rowsLeft - 1));
                }

                currentWordIndex++;

                if (currentWordIndex < sentence.Length)
                {
                    continue;
                }

                ans++;
                currentWordIndex = 0;
            }
        });

        return dp.GetOrCalculate((0, rows));
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
