using JetBrains.Annotations;

namespace LeetCode._2467_Most_Profitable_Path_in_a_Tree;

/// <summary>
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution5 : ISolution
{
    public int MostProfitablePath(int[][] edges, int bob, int[] amount)
    {
        var parentsMap = new Dictionary<int, int>();

        var neighborsMap = new Dictionary<int, List<int>>();

        var totalCostMap = new Dictionary<int, int>();

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

        var nodesQueue = new Queue<(int node, int level)>();

        nodesQueue.Enqueue((0, 0));

        var leafNodes = new List<(int node, int level)>();
        var currentLevelNodes = new List<(int node, int level)>();
        var lastLevel = 0;

        while (nodesQueue.Count > 0)
        {
            var (node, level) = nodesQueue.Dequeue();

            var children = neighborsMap[node].Except(totalCostMap.Keys).ToArray();

            totalCostMap[node] = amount[node];

            if (node != 0)
            {
                totalCostMap[node] += totalCostMap[parentsMap[node]];
            }

            if (children.Length == 0)
            {
                leafNodes.Add((node, level));
            }

            if (level > lastLevel)
            {
                currentLevelNodes.Clear();
            }

            lastLevel = level;
            currentLevelNodes.Add((node, level));

            if (node == bob)
            {
                RecalculateForBob(level);
            }

            foreach (var child in children)
            {
                parentsMap[child] = node;
                nodesQueue.Enqueue((child, level + 1));
            }
        }

        return leafNodes.Select(x => totalCostMap[x.node]).Max();

        void RecalculateForBob(int level)
        {
            var correctionsMap = new Dictionary<int, int>();

            var node = bob;

            for (var i = 0; i <= level / 2; i++)
            {
                correctionsMap[node] = 0;
                var correction = -amount[node];

                if (i * 2 == level)
                {
                    correction /= 2;
                }

                foreach (var bobAncestorOrSelf in correctionsMap.Keys)
                {
                    correctionsMap[bobAncestorOrSelf] += correction;
                    totalCostMap[bobAncestorOrSelf] += correction;
                }

                node = parentsMap[node];
            }

            foreach (var (node2, level2) in currentLevelNodes.Union(leafNodes))
            {
                ApplyCorrection(node2, level2);
            }

            return;

            int ApplyCorrection(int node2, int level2)
            {
                if (correctionsMap.TryGetValue(node2, out var applyCorrection))
                {
                    return applyCorrection;
                }

                if (level2 < level / 2)
                {
                    return 0;
                }

                var correction = ApplyCorrection(parentsMap[node2], level2 - 1);

                correctionsMap[node2] = correction;
                totalCostMap[node2] += correction;

                return correction;
            }
        }
    }
}
