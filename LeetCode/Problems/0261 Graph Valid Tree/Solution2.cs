using JetBrains.Annotations;

namespace LeetCode._0261_Graph_Valid_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/931499127/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool ValidTree(int n, int[][] edges)
    {
        var seen = new HashSet<int>();

        var adjacentNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            adjacentNodes[edge[0]].Add(edge[1]);
            adjacentNodes[edge[1]].Add(edge[0]);
        }

        return Dfs(0, -1) && seen.Count == n;

        bool Dfs(int node, int parent) => seen.Add(node) && adjacentNodes[node].Except(new[] { parent }).All(adjacentNode => Dfs(adjacentNode, node));
    }
}
