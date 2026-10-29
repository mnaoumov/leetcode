namespace LeetCode.Problems._3213_Construct_String_with_Minimum_Cost;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-405/submissions/detail/1312326379/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    private const int Impossible = int.MaxValue;

    public int MinimumCost(string target, string[] words, int[] costs)
    {
        var trie = new TrieNode();

        foreach (var (word, cost) in words.Zip(costs, (word, cost) => (word, cost)))
        {
            trie.Add(word, cost);
        }

        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
        {
            if (index == target.Length)
            {
                return 0;
            }

            var node = trie;

            var ans = Impossible;

            for (var i = index; i < target.Length; i++)
            {
                var letter = target[i];
                node = node.Get(letter);

                if (node == null)
                {
                    break;
                }

                if (node.Cost == Impossible)
                {
                    continue;
                }

                var next = recursiveFunc(i + 1);

                if (next != Impossible)
                {
                    ans = Math.Min(ans, node.Cost + next);
                }
            }

            return ans;
        });

        var ans = dp.GetOrCalculate(0);
        return ans == Impossible ? -1 : ans;
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

    private class TrieNode
    {
        private readonly Dictionary<char, TrieNode> _childNodes = new();

        public void Add(string word, int cost)
        {
            var node = this;
            node = word.Aggregate(node, (current, letter) => current.GetOrAdd(letter));
            node.Cost = Math.Min(node.Cost, cost);
        }

        public int Cost { get; private set; } = Impossible;

        private TrieNode GetOrAdd(char letter)
        {
            if (_childNodes.TryGetValue(letter, out var childNode))
            {
                return childNode;
            }

            childNode = new TrieNode();
            _childNodes[letter] = childNode;
            return childNode;
        }

        public TrieNode? Get(char letter) => _childNodes.GetValueOrDefault(letter);
    }
}
