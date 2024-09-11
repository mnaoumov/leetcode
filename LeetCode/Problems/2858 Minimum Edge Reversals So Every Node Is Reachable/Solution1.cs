using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2858_Minimum_Edge_Reversals_So_Every_Node_Is_Reachable;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-113/submissions/detail/1051054272/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int[] MinEdgeReversals(int n, int[][] edges)
    {
        var edgesMap = Enumerable.Range(0, n).Select(_ => new List<(int node, bool isDirectEdge)>()).ToArray();

        foreach (var edge in edges)
        {
            edgesMap[edge[0]].Add((edge[1], true));
            edgesMap[edge[1]].Add((edge[0], false));
        }

        var ans = new int[n];

        for (var i = 0; i < n; i++)
        {
            var seen = new bool[n];
            ans[i] = Dfs(i);
            continue;

            int Dfs(int node)
            {
                seen[node] = true;
                var ans2 = 0;

                foreach (var (adjNode, isDirectEdge) in edgesMap[node])
                {
                    if (seen[adjNode])
                    {
                        continue;
                    }

                    if (!isDirectEdge)
                    {
                        ans2++;
                    }

                    ans2 += Dfs(adjNode);
                }

                return ans2;
            }
        }

        return ans;
    }
}
