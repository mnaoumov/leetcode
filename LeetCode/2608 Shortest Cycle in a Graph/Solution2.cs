using JetBrains.Annotations;

namespace LeetCode._2608_Shortest_Cycle_in_a_Graph;

/// <summary>
/// https://leetcode.com/submissions/detail/926044770/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int FindShortestCycle(int n, int[][] edges)
    {
        var adjacentNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            adjacentNodes[edge[0]].Add(edge[1]);
            adjacentNodes[edge[1]].Add(edge[0]);
        }

        var seen = new bool[n];
        var result = int.MaxValue;

        for (var i = 0; i < n; i++)
        {
            if (seen[i])
            {
                continue;
            }

            result = Math.Min(result, Dfs(i, -1, 1));
        }

        return result == int.MaxValue ? -1 : result;

        int Dfs(int node, int parent, int length)
        {
            seen[node] = true;

            var minLength = int.MaxValue;

            if (adjacentNodes[node].Any(adjacentNode => adjacentNode != parent && seen[adjacentNode]))
            {
                minLength = length;
            }

            return adjacentNodes[node].Where(adjacentNode => !seen[adjacentNode])
                .Select(adjacentNode => Dfs(adjacentNode, node, length + 1)).Prepend(minLength).Min();
        }
    }
}
