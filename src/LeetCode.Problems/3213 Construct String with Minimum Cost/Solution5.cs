namespace LeetCode.Problems._3213_Construct_String_with_Minimum_Cost;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-405/submissions/detail/1312368408/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution5 : ISolution
{
    private const int Impossible = int.MaxValue;

    public int MinimumCost(string target, string[] words, int[] costs)
    {
        var trie = new TrieNode();
        var reverseTrie = new TrieNode();

        foreach (var (word, cost) in words.Zip(costs, (word, cost) => (word, cost)))
        {
            if (word.Length > target.Length)
            {
                continue;
            }

            trie.Add(word, cost);
            var reverseWord = new string(word.Reverse().ToArray());
            reverseTrie.Add(reverseWord, cost);
        }

        var dp = new DynamicProgramming<(int start, int end), int>((key, recursiveFunc) =>
        {
            var (start, end) = key;

            if (start > end)
            {
                return 0;
            }

            var node = trie;

            var startIndicesCost = new List<(int index, int cost)>();
            var endIndicesCost = new List<(int index, int cost)>();

            for (var i = start; i <= end; i++)
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

                startIndicesCost.Add((i, node.Cost));
            }

            endIndicesCost.Add((end + 1, 0));

            node = reverseTrie;

            for (var i = end; i >= start; i--)
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

                endIndicesCost.Add((i, node.Cost));
            }

            var ans = Impossible;

            foreach (var startIndexCost in startIndicesCost)
            {
                if (ans <= startIndexCost.cost)
                {
                    continue;
                }

                var low = 0;
                var high = endIndicesCost.Count - 1;

                while (low <= high)
                {
                    var mid = low + (high - low >> 1);

                    if (endIndicesCost[mid].index <= startIndexCost.index)
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }

                for (var i = 0; i <= high; i++)
                {
                    var endIndexCost = endIndicesCost[i];

                    if (ans <= startIndexCost.cost + endIndexCost.cost)
                    {
                        continue;
                    }

                    var next = recursiveFunc((startIndexCost.index + 1, endIndexCost.index - 1));

                    if (next != Impossible)
                    {
                        ans = Math.Min(ans, startIndexCost.cost + endIndexCost.cost + next);
                    }
                }
            }

            return ans;
        });

        var ans = dp.GetOrCalculate((0, target.Length - 1));
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
