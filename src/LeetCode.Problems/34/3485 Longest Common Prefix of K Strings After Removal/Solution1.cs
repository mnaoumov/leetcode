namespace LeetCode.Problems._3485_Longest_Common_Prefix_of_K_Strings_After_Removal;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-152/problems/longest-common-prefix-of-k-strings-after-removal/submissions/1574626085/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int[] LongestCommonPrefix(string[] words, int k)
    {
        var root = new TrieNode();
        var n = words.Length;

        var pq = new PriorityQueue<TrieNode, int>();

        for (var i = 0; i < n; i++)
        {
            var word = words[i];

            var node = root;

            for (var j = 0; j < word.Length; j++)
            {
                var letter = word[j];
                node = node.GetOrCreate(letter);
                node.WordIndices.Add(i);
                node.PrefixLength = j + 1;
                pq.Enqueue(node, -node.PrefixLength);
            }
        }

        var ans = new int[n];
        var unsetIndices = Enumerable.Range(0, n).ToHashSet();

        while (pq.Count > 0 && unsetIndices.Count > 0)
        {
            var node = pq.Dequeue();

            if (node.WordIndices.Count < k)
            {
                continue;
            }

            foreach (var unsetIndex in unsetIndices.ToArray())
            {
                if (node.WordIndices.Count == k && node.WordIndices.Contains(unsetIndex))
                {
                    continue;
                }

                ans[unsetIndex] = node.PrefixLength;
                unsetIndices.Remove(unsetIndex);
            }
        }

        return ans;
    }

    private class TrieNode
    {
        private readonly Dictionary<char, TrieNode> _childNodes = new();
        public HashSet<int> WordIndices { get; } = new();
        public int PrefixLength { get; set; }

        public TrieNode GetOrCreate(char letter)
        {
            _childNodes.TryAdd(letter, new TrieNode());
            return _childNodes[letter];
        }
    }
}
