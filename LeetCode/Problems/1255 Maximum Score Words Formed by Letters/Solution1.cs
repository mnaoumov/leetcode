using System.Collections;
using JetBrains.Annotations;

namespace LeetCode.Problems._1255_Maximum_Score_Words_Formed_by_Letters;

/// <summary>
/// https://leetcode.com/submissions/detail/1266484533/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxScoreWords(string[] words, char[] letters, int[] score)
    {
        var initialCounts = new int[26];

        foreach (var letter in letters)
        {
            initialCounts[letter - 'a']++;
        }

        (IDictionary<char, int> letterCounts, int score)[] wordData = words.Select(ProcessWord).ToArray();

        var dp = new DynamicProgramming<(int wordIndex, HashableImmutableArray<int> letterCounts), int>((key, recursiveFunc) =>
        {
            var (wordIndex, letterCounts) = key;

            if (wordIndex == words.Length)
            {
                return 0;
            }

            var ans = recursiveFunc((wordIndex + 1, letterCounts));
            var wordLetterCounts = wordData[wordIndex].letterCounts;

            var canTakeWord = true;

            var nextLetterCounts = letterCounts.ToArray();

            foreach (var (letter, count) in wordLetterCounts)
            {
                var letterIndex = LetterIndex(letter);
                nextLetterCounts[letterIndex] -= count;

                if (nextLetterCounts[letterIndex] >= 0)
                {
                    continue;
                }

                canTakeWord = false;
                break;
            }

            if (canTakeWord)
            {
                ans = Math.Max(ans,
                    wordData[wordIndex].score +
                    recursiveFunc((wordIndex + 1, new HashableImmutableArray<int>(nextLetterCounts))));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, new HashableImmutableArray<int>(initialCounts)));

        (IDictionary<char, int> letterCounts, int wordScore) ProcessWord(string word)
        {
            var wordScore = 0;
            var letterCounts = new Dictionary<char, int>();
            foreach (var letter in word)
            {
                letterCounts.TryAdd(letter, 0);
                letterCounts[letter]++;
                wordScore += score[LetterIndex(letter)];
            }

            return (letterCounts, wordScore);
        }

    }

    private static int LetterIndex(char letter) => letter - 'a';

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }

    private class HashableImmutableArray<T> : IReadOnlyList<T>
    {
        private readonly T[] _items;
        public HashableImmutableArray(IEnumerable<T> items) => _items = items.ToArray();

        public override int GetHashCode() => (_items as IStructuralEquatable).GetHashCode(EqualityComparer<T>.Default);

        public override bool Equals(object? obj) =>
            ReferenceEquals(this, obj) ||
            obj is HashableImmutableArray<T> other && _items.SequenceEqual(other._items);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        // ReSharper disable once NotDisposedResourceIsReturned
        public IEnumerator<T> GetEnumerator() => _items.AsEnumerable().GetEnumerator();
        public int Count => _items.Length;
        public T this[int index] => _items[index];
    }
}
