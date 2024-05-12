using JetBrains.Annotations;

namespace LeetCode.Problems._2603_Collect_Coins_in_a_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/922255051/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int CollectTheCoins(int[] coins, int[][] edges)
    {
        var n = coins.Length;

        var coinNodes = Enumerable.Range(0, n).Where(i => coins[i] == 1).ToArray();

        if (coinNodes.Length == 0)
        {
            return 0;
        }

        var adjacentNodes = Enumerable.Range(0, n).Select(_ => new HashSet<int>()).ToArray();

        foreach (var edge in edges)
        {
            adjacentNodes[edge[0]].Add(edge[1]);
            adjacentNodes[edge[1]].Add(edge[0]);
        }

        var leafNodes = new HashSet<int>();
        var leafNodesWithoutCoins = new HashSet<int>();
        var removedNodes = new HashSet<int>();

        for (var i = 0; i < n; i++)
        {
            TryAddLeaf(i);
        }

        while (leafNodesWithoutCoins.Count > 0)
        {
            TryRemoveLeaf(leafNodesWithoutCoins.First());
        }

        var parentNodes = new HashSet<int>();

        foreach (var node in leafNodes.ToArray())
        {
            if (adjacentNodes[node].Count == 1)
            {
                parentNodes.Add(adjacentNodes[node].First());
            }

            TryRemoveLeaf(node);
        }

        foreach (var parentNode in parentNodes.Where(node => adjacentNodes[node].Count == 1).ToArray())
        {
            TryRemoveLeaf(parentNode);
        }

        return Math.Max(0, 2 * (n - removedNodes.Count - 1));

        void TryRemoveLeaf(int node)
        {
            if (adjacentNodes[node].Count > 1)
            {
                return;
            }

            if (!removedNodes.Add(node))
            {
                return;
            }

            leafNodes.Remove(node);
            leafNodesWithoutCoins.Remove(node);

            if (adjacentNodes[node].Count == 0)
            {
                return;
            }

            var parentNode = adjacentNodes[node].First();
            adjacentNodes[parentNode].Remove(node);
            TryAddLeaf(parentNode);
        }

        void TryAddLeaf(int node)
        {
            if (adjacentNodes[node].Count > 1)
            {
                return;
            }

            leafNodes.Add(node);

            if (coins[node] != 1)
            {
                leafNodesWithoutCoins.Add(node);
            }
        }
    }
}
