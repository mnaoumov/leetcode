using JetBrains.Annotations;

namespace LeetCode._0261_Graph_Valid_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/931497000/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool ValidTree(int n, int[][] edges)
    {
        var seen = new bool[n];

        var adjacentNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            adjacentNodes[edge[0]].Add(edge[1]);
            adjacentNodes[edge[1]].Add(edge[0]);
        }

        return Dfs(0, -1);

        bool Dfs(int node, int parent)
        {
            if (seen[node])
            {
                return false;
            }

            seen[node] = true;

            return adjacentNodes[node].Except(new[] { parent }).All(adjacentNode => Dfs(adjacentNode, node));
        }
    }
}
