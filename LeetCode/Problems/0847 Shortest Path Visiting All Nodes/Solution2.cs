using JetBrains.Annotations;

namespace LeetCode._0847_Shortest_Path_Visiting_All_Nodes;

/// <summary>
/// https://leetcode.com/submissions/detail/928676497/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int ShortestPathLength(int[][] graph)
    {
        var n = graph.Length;

        const int impossible = -1;

        var fullMask = (1 << n) - 1;

        var result = int.MaxValue;

        for (var i = 0; i < n; i++)
        {
            var seen = new HashSet<(int node, int visitedNodesMask)>();
            var dp = new Dictionary<(int node, int visitedNodesMask), int>();

            var nextResult = Dfs(i, 0);

            if (nextResult != impossible)
            {
                result = Math.Min(result, nextResult);
            }

            continue;

            int Dfs(int node, int visitedNodesMask)
            {
                var key = (node, visitedNodesMask);

                if (dp.TryGetValue(key, out var result2))
                {
                    return result2;
                }

                if (!seen.Add(key))
                {
                    return impossible;
                }

                var currentVisitedNodeMask = visitedNodesMask | 1 << node;

                if (currentVisitedNodeMask == fullMask)
                {
                    return dp[key] = 0;
                }

                result2 = graph[node]
                    .Select(adjacentNode => Dfs(adjacentNode, currentVisitedNodeMask))
                    .Where(nextResult2 => nextResult2 != impossible)
                    .Select(nextResult2 => 1 + nextResult2)
                    .DefaultIfEmpty(impossible)
                    .Min();

                return dp[key] = result2;
            }
        }

        return result;
    }
}
