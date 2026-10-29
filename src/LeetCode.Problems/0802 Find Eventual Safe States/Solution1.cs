namespace LeetCode.Problems._0802_Find_Eventual_Safe_States;

/// <summary>
/// https://leetcode.com/submissions/detail/928116085/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IList<int> EventualSafeNodes(int[][] graph)
    {
        var n = graph.Length;
        var safeNodes = new bool?[n];
        var result = new List<int>();

        for (var i = 0; i < n; i++)
        {
            var seen = new bool[n];

            if (Dfs(i))
            {
                result.Add(i);
            }

            continue;

            bool Dfs(int node)
            {
                if (safeNodes[node] is { } isSafeNode)
                {
                    return isSafeNode;
                }

                seen[node] = true;

                foreach (var adjacentNode in graph[node])
                {
                    if (seen[adjacentNode])
                    {
                        safeNodes[node] = false;
                        return false;
                    }

                    if (Dfs(adjacentNode))
                    {
                        continue;
                    }

                    safeNodes[node] = false;
                    return false;
                }

                safeNodes[node] = true;
                return true;
            }
        }

        return result;
    }
}
