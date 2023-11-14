using JetBrains.Annotations;

namespace LeetCode._2467_Most_Profitable_Path_in_a_Tree;

/// <summary>
/// https://leetcode.com/problems/most-profitable-path-in-a-tree/submissions/842134474/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int MostProfitablePath(int[][] edges, int bob, int[] amount)
    {
        var parentsMap = new Dictionary<int, int>();

        var neighborsMap = new Dictionary<int, List<int>>();

        foreach (var edge in edges)
        {
            AddNeighbor(edge[0], edge[1]);
            AddNeighbor(edge[1], edge[0]);
            continue;

            void AddNeighbor(int node1, int node2)
            {
                if (!neighborsMap.ContainsKey(node1))
                {
                    neighborsMap[node1] = new List<int>();
                }

                neighborsMap[node1].Add(node2);
            }
        }

        var processedNodes = new HashSet<int>();
        var leafNodes = new List<(int node, int level)>();

        var nodesQueue = new Queue<(int node, int level)>();

        nodesQueue.Enqueue((0, 0));

        int node;

        while (nodesQueue.Count > 0)
        {
            (node, var level) = nodesQueue.Dequeue();

            var children = neighborsMap[node].Except(processedNodes).ToArray();

            if (children.Length == 0)
            {
                leafNodes.Add((node, level));
                continue;
            }

            processedNodes.Add(node);

            foreach (var child in children)
            {
                parentsMap[child] = node;
                nodesQueue.Enqueue((child, level + 1));
            }
        }

        var bobNodeHeight = 0;

        node = bob;

        while (node != 0)
        {
            node = parentsMap[node];
            bobNodeHeight++;
        }

        node = bob;

        for (var i = 0; i <= (bobNodeHeight - 1) / 2; i++)
        {
            amount[node] = 0;
            node = parentsMap[node];
        }

        if (bobNodeHeight % 2 == 0)
        {
            amount[node] /= 2;
        }

        var costsMap = new Dictionary<int, int>();

        var queue = new PriorityQueue<(int node, int level), int>();

        foreach (var leafNode in leafNodes)
        {
            queue.Enqueue(leafNode, -leafNode.level);
            costsMap[leafNode.node] = amount[leafNode.node];
        }

        while (queue.Count > 0)
        {
            (node, var level) = queue.Dequeue();

            if (node == 0)
            {
                continue;
            }

            var parent = parentsMap[node];

            if (!costsMap.ContainsKey(parent))
            {
                queue.Enqueue((parent, level - 1), 1 - level);
                costsMap[parent] = int.MinValue;
            }

            costsMap[parent] = Math.Max(costsMap[parent], amount[parent] + costsMap[node]);
        }

        return costsMap[0];
    }
}
