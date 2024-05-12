using JetBrains.Annotations;

namespace LeetCode.Problems._0785_Is_Graph_Bipartite_;

/// <summary>
/// https://leetcode.com/submissions/detail/928794176/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsBipartite(int[][] graph)
    {
        var n = graph.Length;

        var a = new HashSet<int>();
        var b = new HashSet<int>();

        for (var i = 0; i < n; i++)
        {
            if (a.Contains(i) || b.Contains(i))
            {
                continue;
            }

            if (!Dfs(i, a))
            {
                return false;
            }
        }

        return true;

        bool Dfs(int node, ISet<int> set)
        {
            set.Add(node);

            var otherSet = set == a ? b : a;

            foreach (var adjacentNode in graph[node])
            {
                if (set.Contains(adjacentNode))
                {
                    return false;
                }

                if (otherSet.Contains(adjacentNode))
                {
                    continue;
                }

                if (!Dfs(adjacentNode, otherSet))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
