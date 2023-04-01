using JetBrains.Annotations;

namespace LeetCode._6330_Shortest_Cycle_in_a_Graph;

/// <summary>
/// https://leetcode.com/submissions/detail/926161098/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution5 : ISolution
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
            var path = new HashSet<int>();

            Backtrack(i, -1);

            void Backtrack(int node, int parent)
            {
                if (node == i && path.Count > 0)
                {
                    result = Math.Min(result, path.Count);
                    return;
                }

                if (!path.Add(node))
                {
                    return;
                }

                foreach (var adjacentNode in adjacentNodes[node].Where(adjacentNode => adjacentNode != parent))
                {
                    Backtrack(adjacentNode, node);
                }

                path.Remove(node);
            }
        }

        return result == int.MaxValue ? -1 : result;
    }
}
