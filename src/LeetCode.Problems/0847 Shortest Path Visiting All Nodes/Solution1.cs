namespace LeetCode.Problems._0847_Shortest_Path_Visiting_All_Nodes;

/// <summary>
/// https://leetcode.com/submissions/detail/928532408/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int ShortestPathLength(int[][] graph)
    {
        var n = graph.Length;

        var seen = new HashSet<(int node, int visitedNodesMask)>();
        var dp = new Dictionary<(int node, int visitedNodesMask), int>();
        const int impossible = -1;

        var fullMask = (1 << n) - 1;
        return Enumerable.Range(0, n).Min(node => Dfs(node, 0));

        int Dfs(int node, int visitedNodesMask)
        {
            var key = (node, visitedNodesMask);

            if (dp.TryGetValue(key, out var result))
            {
                return result;
            }

            if (!seen.Add(key))
            {
                return impossible;
            }

            visitedNodesMask |= 1 << node;

            if (visitedNodesMask == fullMask)
            {
                return dp[key] = 0;
            }

            result = graph[node]
                .Select(adjacentNode => Dfs(adjacentNode, visitedNodesMask))
                .Where(nextResult => nextResult != impossible)
                .Select(nextResult => 1 + nextResult)
                .DefaultIfEmpty(impossible)
                .Min();

            return dp[key] = result;
        }
    }
}
