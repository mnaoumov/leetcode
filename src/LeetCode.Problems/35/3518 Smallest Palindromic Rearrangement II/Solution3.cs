using System.Numerics;

namespace LeetCode.Problems._3518_Smallest_Palindromic_Rearrangement_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-445/problems/smallest-palindromic-rearrangement-ii/submissions/1605187760/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public string SmallestPalindrome(string s, int k)
    {
        if (s.Length == 1)
        {
            return k == 1 ? s : "";
        }

        var counts = s.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());
        for (var letter = 'a'; letter <= 'z'; letter++)
        {
            counts.TryAdd(letter, 0);
        }

        var m = s.Length / 2;
        var factorials = new BigInteger[m + 1];
        factorials[0] = 1;

        for (var i = 1; i <= m; i++)
        {
            factorials[i] = factorials[i - 1] * i;
        }

        var middleLetter = counts.FirstOrDefault(kvp => kvp.Value % 2 == 1).Key;
        const char noMiddleLetter = '\0';
        if (middleLetter != noMiddleLetter)
        {
            counts[middleLetter]--;
        }

        var dp = new DynamicProgramming<(string halfCountsStr, BigInteger index), (string palindrome, BigInteger totalCount)>((key, recursiveFunc) =>
        {
            var (halfCountsStr, index) = key;
            var halfCounts = halfCountsStr.Split(' ').Select(int.Parse).ToArray();

            var totalCount = factorials[halfCounts.Sum()];
            totalCount = halfCounts.Aggregate(totalCount, (current, halfCount) => current / factorials[halfCount]);

            if (index > totalCount)
            {
                return ("", totalCount);
            }

            for (var letter = 'a'; letter <= 'z'; letter++)
            {
                var letterIndex = letter - 'a';
                if (halfCounts[letterIndex] == 0)
                {
                    continue;
                }

                halfCounts[letterIndex]--;
                var (middlePalindrome, middleTotalCount) = recursiveFunc((Join(halfCounts), index));

                if (middlePalindrome == "")
                {
                    index -= middleTotalCount;
                    halfCounts[letterIndex]++;
                }
                else
                {
                    if (middlePalindrome[0] == noMiddleLetter)
                    {
                        middlePalindrome = middleLetter == noMiddleLetter ? "" : middleLetter.ToString();
                    }

                    return (letter + middlePalindrome + letter, totalCount);
                }
            }

            return (noMiddleLetter.ToString(), totalCount);
        });

        var halfCounts = counts.OrderBy(kvp => kvp.Key).Select(kvp => kvp.Value / 2).ToArray();
        return dp.GetOrCalculate((Join(halfCounts), k)).palindrome;

        static string Join(int[] arr) => string.Join(' ', arr);
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
