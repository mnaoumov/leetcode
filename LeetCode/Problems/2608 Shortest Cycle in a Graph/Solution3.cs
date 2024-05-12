using JetBrains.Annotations;

namespace LeetCode._2608_Shortest_Cycle_in_a_Graph;

/// <summary>
/// https://leetcode.com/submissions/detail/926068734/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public int FindShortestCycle(int n, int[][] edges)
    {
        var adjacentNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            adjacentNodes[edge[0]].Add(edge[1]);
            adjacentNodes[edge[1]].Add(edge[0]);
        }

        var depths = new Dictionary<int, int>();
        var result = int.MaxValue;

        for (var i = 0; i < n; i++)
        {
            if (depths.ContainsKey(i))
            {
                continue;
            }

            result = Math.Min(result, Dfs(i, -1, 0));
        }

        return result == int.MaxValue ? -1 : result;

        int Dfs(int node, int parent, int depth)
        {
            if (depths.TryGetValue(node, out var previousDepth))
            {
                return depth > previousDepth ? depth - previousDepth : depth + previousDepth;
            }

            depths[node] = depth;

            var enumerable = adjacentNodes[node]
                .Where(adjacentNode => adjacentNode != parent)
                .Select(adjacentNode => Dfs(adjacentNode, node, depth + 1))
                .Prepend(int.MaxValue).ToArray();
            var min = enumerable
                .Min();
            return min;
        }
    }
}
