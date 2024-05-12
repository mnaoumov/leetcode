using JetBrains.Annotations;

namespace LeetCode._2539_Count_the_Number_of_Good_Subsequences;

/// <summary>
/// https://leetcode.com/submissions/detail/880961622/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int CountGoodSubsequences(string s)
    {
        const int modulo = 1_000_000_007;

        var letterCounts = s.GroupBy(letter => letter).Select(g => g.Count()).ToArray();

        var result = 0;

        var n = letterCounts.Length;

        var selectedCounts = new int[n];

        var chooseDp = new DynamicProgramming<(int m, int k), int>((key, recursiveFunc) =>
        {
            var (m, k) = key;

            if (m == 0)
            {
                return k == 0 ? 1 : 0;
            }

            return (recursiveFunc((m - 1, k)) + recursiveFunc((m - 1, k - 1))) % modulo;
        });

        ProcessLetter(0, 0);

        return result;

        void ProcessLetter(int letterIndex, int equalLetterCount)
        {
            if (letterIndex == n)
            {
                var product = 1;
                var hasLetters = false;

                for (var i = 0; i < n; i++)
                {
                    if (selectedCounts[i] == 0)
                    {
                        continue;
                    }

                    hasLetters = true;
                    product = (int) (1L * product * Choose(letterCounts[i], selectedCounts[i]) % modulo);
                }

                if (hasLetters)
                {
                    result = (result + product) % modulo;
                }

                return;
            }

            var maxLetterCount = letterCounts[letterIndex];

            if (equalLetterCount == 0)
            {
                for (var letterCount = 0; letterCount <= maxLetterCount; letterCount++)
                {
                    selectedCounts[letterIndex] = letterCount;
                    ProcessLetter(letterIndex + 1, letterCount);
                    selectedCounts[letterIndex] = 0;
                }
            }
            else
            {
                ProcessLetter(letterIndex + 1, equalLetterCount);

                if (maxLetterCount < equalLetterCount)
                {
                    return;
                }

                selectedCounts[letterIndex] = equalLetterCount;
                ProcessLetter(letterIndex + 1, equalLetterCount);
                selectedCounts[letterIndex] = 0;
            }
        }

        int Choose(int m, int k) => chooseDp.GetOrCalculate((m, k));
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
