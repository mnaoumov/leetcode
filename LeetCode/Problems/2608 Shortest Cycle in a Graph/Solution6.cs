using JetBrains.Annotations;

namespace LeetCode.Problems._2608_Shortest_Cycle_in_a_Graph;

/// <summary>
/// https://leetcode.com/submissions/detail/926162365/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
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
            continue;

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

                if (path.Count < result)
                {
                    foreach (var adjacentNode in adjacentNodes[node].Where(adjacentNode => adjacentNode != parent))
                    {
                        Backtrack(adjacentNode, node);
                    }
                }

                path.Remove(node);
            }
        }

        return result == int.MaxValue ? -1 : result;
    }
}
