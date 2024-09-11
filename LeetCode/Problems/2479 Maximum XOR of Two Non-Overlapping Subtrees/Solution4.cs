using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2479_Maximum_XOR_of_Two_Non_Overlapping_Subtrees;

/// <summary>
/// https://leetcode.com/submissions/detail/874423159/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution4 : ISolution
{
    private const int MaxBitIndex = 46; // n <= 5 * 10^4, value <= 10^9 => sum <= 5^10^13 < 2^46

    public long MaxXor(int n, int[][] edges, int[] values)
    {
        var neighbors = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            neighbors[edge[0]].Add(edge[1]);
            neighbors[edge[1]].Add(edge[0]);
        }

        var root = new TrieNode();
        long maxXor = 0;
        var subtreeSums = new long[n];

        CalculateSubtreeSums(0, -1);
        CalculateXor(0, -1);

        return maxXor;

        long CalculateSubtreeSums(int node, int parent) =>
            subtreeSums[node] = values[node] + neighbors[node].Except(new[] { parent })
                .Sum(child => CalculateSubtreeSums(child, node));

        void CalculateXor(int node, int parent)
        {
            var trieNode = root;

            var xor = 0;

            for (var i = MaxBitIndex - 1; i >= 0; i--)
            {
                var bit = (int) (subtreeSums[node] >> i & 1);

                if (trieNode.Next[bit ^ 1] is { } nextTrieNode)
                {
                    xor |= 1 << i;
                    trieNode = nextTrieNode;
                }
                else if (trieNode.Next[bit] is { } nextTrieNode2)
                {
                    trieNode = nextTrieNode2;
                }
                else
                {
                    break;
                }
            }

            maxXor = Math.Max(maxXor, xor);


            foreach (var child in neighbors[node].Except(new[] { parent }))
            {
                CalculateXor(child, node);
            }

            trieNode = root;

            for (var i = MaxBitIndex - 1; i >= 0; i--)
            {
                var bit = (int) (subtreeSums[node] >> i & 1);

                if (trieNode.Next[bit] is not { } nextTrieNode)
                {
                    trieNode.Next[bit] = nextTrieNode = new TrieNode();
                }

                trieNode = nextTrieNode;
            }
        }
    }

    private class TrieNode
    {
        public readonly TrieNode?[] Next = new TrieNode?[2];
    }
}

