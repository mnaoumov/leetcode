using JetBrains.Annotations;

namespace LeetCode.Problems._2467_Most_Profitable_Path_in_a_Tree;

/// <summary>
/// https://leetcode.com/problems/most-profitable-path-in-a-tree/submissions/842038064/
/// https://leetcode.com/problems/most-profitable-path-in-a-tree/submissions/842080268/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public int MostProfitablePath(int[][] edges, int bob, int[] amount)
    {
        var childrenMap = new Dictionary<int, List<int>>();
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

        var parentQueue = new Queue<int>();

        parentQueue.Enqueue(0);

        while (parentQueue.Count > 0)
        {
            var parent = parentQueue.Dequeue();

            var children = neighborsMap[parent].Except(childrenMap.Keys).ToArray();

            if (children.Length == 0)
            {
                continue;
            }

            childrenMap[parent] = new List<int>();

            foreach (var child in children)
            {
                childrenMap[parent].Add(child);
                parentsMap[child] = parent;
                parentQueue.Enqueue(child);
            }
        }

        var queue = new Queue<(int aliceNode, long aliceProfit, int bobNode)>();
        queue.Enqueue((0, 0, bob));
        var result = long.MinValue;

        while (queue.Count > 0)
        {
            var (aliceNode, aliceProfit, bobNode) = queue.Dequeue();

            var aliceNextProfit = aliceProfit + (aliceNode == bobNode ? amount[aliceNode] / 2 : amount[aliceNode]);
            amount[aliceNode] = 0;
            amount[bobNode] = 0;

            if (!childrenMap.ContainsKey(aliceNode))
            {
                result = Math.Max(result, aliceNextProfit);
                continue;
            }

            var bobNextNode = bobNode == 0 ? 0 : parentsMap[bobNode];

            foreach (var aliceNextNode in childrenMap[aliceNode])
            {
                queue.Enqueue((aliceNextNode, aliceNextProfit, bobNextNode));
            }
        }

        // ReSharper disable once IntVariableOverflowInUncheckedContext
        return (int) result;
    }
}
