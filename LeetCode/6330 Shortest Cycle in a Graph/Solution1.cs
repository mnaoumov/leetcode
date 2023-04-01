using JetBrains.Annotations;

namespace LeetCode._6330_Shortest_Cycle_in_a_Graph;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-101/submissions/detail/926018470/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
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

            result = Math.Min(result, Dfs(i, 1));
        }

        return result == int.MaxValue ? -1 : result;

        int Dfs(int i, int length)
        {
            seen[i] = true;

            foreach (var adjacentNode in adjacentNodes[i].Where(adjacentNode => !seen[adjacentNode]))
            {
                return Dfs(adjacentNode, length + 1);
            }

            return adjacentNodes[i].Count == 2 ? length : int.MaxValue;
        }
    }
}
