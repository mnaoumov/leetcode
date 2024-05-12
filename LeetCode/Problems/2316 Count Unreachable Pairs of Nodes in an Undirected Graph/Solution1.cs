using JetBrains.Annotations;

namespace LeetCode.Problems._2316_Count_Unreachable_Pairs_of_Nodes_in_an_Undirected_Graph;

/// <summary>
/// https://leetcode.com/submissions/detail/921593778/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long CountPairs(int n, int[][] edges)
    {
        var adjacentEdges = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            adjacentEdges[edge[0]].Add(edge[1]);
            adjacentEdges[edge[1]].Add(edge[0]);
        }

        var seen = new bool[n];
        var componentSizes = new List<int>();

        for (var i = 0; i < n; i++)
        {
            if (seen[i])
            {
                continue;
            }

            componentSizes.Add(Dfs(i));
        }

        var result = 0L;

        for (var i = 0; i < componentSizes.Count; i++)
        {
            for (var j = i + 1; j < componentSizes.Count; j++)
            {
                result += componentSizes[i] * componentSizes[j];
            }
        }

        return result;

        int Dfs(int node)
        {
            seen[node] = true;
            return 1 + adjacentEdges[node].Where(adjacentNode => !seen[adjacentNode]).Sum(Dfs);
        }
    }
}
