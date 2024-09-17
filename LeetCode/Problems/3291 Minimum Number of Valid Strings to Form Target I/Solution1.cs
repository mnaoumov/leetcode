namespace LeetCode.Problems._3291_Minimum_Number_of_Valid_Strings_to_Form_Target_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-415/submissions/detail/1390521182/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MinValidStrings(string[] words, string target)
    {
        const int impossible = -1;

        var trie = new Trie();

        foreach (var word in words)
        {
            trie.Insert(word);
        }

        var dp = new DynamicProgramming<int, int>((targetIndex, recursiveFunc) =>
        {
            if (targetIndex == target.Length)
            {
                return 0;
            }

            var prefix = "";
            var ans = int.MaxValue;

            for (var i = targetIndex; i < target.Length; i++)
            {
                prefix += target[i];
                var count = trie.CountWordsStartingWith(prefix);

                if (count == 0)
                {
                    break;
                }

                var next = recursiveFunc(i + 1);
                if (next != impossible)
                {
                    ans = Math.Min(ans, 1 + next);
                }
            }

            return ans == int.MaxValue ? impossible : ans;
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

    private class Trie
    {
        private readonly TrieNode _root = new();

        public void Insert(string word)
        {
            var node = _root;

            foreach (var letter in word)
            {
                node.ChildNodes.TryAdd(letter, new TrieNode());
                node = node.ChildNodes[letter];
                node.WordsStartingWithCount++;
            }

            node.WordsEqualToCount++;
        }

        public int CountWordsStartingWith(string prefix)
        {
            var node = _root;

            foreach (var letter in prefix)
            {
                node = node.ChildNodes.GetValueOrDefault(letter);

                if (node == null)
                {
                    return 0;
                }
            }

            return node.WordsStartingWithCount;
        }

        public void Erase(string word)
        {
            var count = CountWordsStartingWith(word);

            if (count == 0)
            {
                return;
            }

            var node = _root;

            foreach (var letter in word)
            {
                node = node.ChildNodes[letter];
                node.WordsStartingWithCount--;
            }

            if (node.WordsEqualToCount > 0)
            {
                node.WordsEqualToCount--;
            }
        }

        private class TrieNode
        {
            public Dictionary<char, TrieNode> ChildNodes { get; } = new();
            public int WordsEqualToCount { get; set; }
            public int WordsStartingWithCount { get; set; }
        }

    }
}
