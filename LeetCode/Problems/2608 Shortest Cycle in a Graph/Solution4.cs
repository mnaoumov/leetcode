using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2608_Shortest_Cycle_in_a_Graph;

/// <summary>
/// https://leetcode.com/submissions/detail/926131468/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution4 : ISolution
{
    public int FindShortestCycle(int n, int[][] edges)
    {
        var adjacentNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            adjacentNodes[edge[0]].Add(edge[1]);
            adjacentNodes[edge[1]].Add(edge[0]);
        }

        var result = int.MaxValue;

        for (var i = 0; i < n; i++)
        {
            var queue = new Queue<(int node, int parent, HashSet<int> path)>();
            queue.Enqueue((i, -1, new HashSet<int>()));

            while (queue.Count > 0)
            {
                var (node, parent, path) = queue.Dequeue();

                if (node == i && path.Count > 0)
                {
                    result = Math.Min(result, path.Count);
                    continue;
                }

                if (!path.Add(node))
                {
                    continue;
                }

                foreach (var adjacentNode in adjacentNodes[node].Where(adjacentNode => adjacentNode != parent))
                {
                    queue.Enqueue((adjacentNode, node, path.ToHashSet()));
                }
            }
        }

        return result == int.MaxValue ? -1 : result;
    }
}
