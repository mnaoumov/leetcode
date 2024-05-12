using JetBrains.Annotations;

namespace LeetCode._2603_Collect_Coins_in_a_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/922209965/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int CollectTheCoins(int[] coins, int[][] edges)
    {
        var n = coins.Length;

        var coinNodes = Enumerable.Range(0, n).Where(i => coins[i] == 1).ToArray();

        if (coinNodes.Length == 0)
        {
            return 0;
        }

        var adjacentNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            adjacentNodes[edge[0]].Add(edge[1]);
            adjacentNodes[edge[1]].Add(edge[0]);
        }

        var queue = new Queue<(int coinNode, int pickupNode)>();

        foreach (var node in coinNodes)
        {
            queue.Enqueue((node, node));
        }

        var pickupCoinNodesMap = new Dictionary<int, HashSet<int>>();

        for (var i = 0; i <= 2; i++)
        {
            var count = queue.Count;

            for (var j = 0; j < count; j++)
            {
                var (coinNode, pickupNode) = queue.Dequeue();

                if (!pickupCoinNodesMap.ContainsKey(pickupNode))
                {
                    pickupCoinNodesMap[pickupNode] = new HashSet<int>();
                }

                if (!pickupCoinNodesMap[pickupNode].Add(coinNode))
                {
                    continue;
                }

                foreach (var adjacentNode in adjacentNodes[pickupNode])
                {
                    queue.Enqueue((coinNode, adjacentNode));
                }
            }
        }

        var queue2 = new Queue<(int pathNode, int startingNode)>();
        var distance = 0;

        var coinsMap =
            pickupCoinNodesMap.Keys.ToDictionary(pickupCoinNode => pickupCoinNode, _ => new HashSet<int>());

        var visitedNodesMap =
            pickupCoinNodesMap.Keys.ToDictionary(pickupCoinNode => pickupCoinNode, _ => new HashSet<int>());

        foreach (var pickupNode in pickupCoinNodesMap.Keys)
        {
            queue2.Enqueue((pickupNode, pickupNode));
        }

        while (true)
        {
            var count = queue2.Count;

            for (var i = 0; i < count; i++)
            {
                var (pathNode, startingNode) = queue2.Dequeue();

                visitedNodesMap[startingNode].Add(pathNode);

                if (pickupCoinNodesMap.TryGetValue(pathNode, out var currentCoinNodes))
                {
                    coinsMap[startingNode].UnionWith(currentCoinNodes);

                    if (coinsMap[startingNode].Count == coinNodes.Length)
                    {
                        return distance;
                    }
                }

                foreach (var adjacentNode in adjacentNodes[pathNode].Where(adjacentNode => !visitedNodesMap[startingNode].Contains(adjacentNode)))
                {
                    queue2.Enqueue((adjacentNode, startingNode));
                }

            }

            distance += 2;
        }
    }
}
