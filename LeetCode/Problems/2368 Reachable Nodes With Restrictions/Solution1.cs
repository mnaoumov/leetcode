using JetBrains.Annotations;

namespace LeetCode._2368_Reachable_Nodes_With_Restrictions;

/// <summary>
/// https://leetcode.com/submissions/detail/897955963/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ReachableNodes(int n, int[][] edges, int[] restricted)
    {
        var restrictedSet = restricted.ToHashSet();
        var neighbors = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            neighbors[edge[0]].Add(edge[1]);
            neighbors[edge[1]].Add(edge[0]);
        }

        var visited = new HashSet<int>();

        Dfs(0);

        return visited.Count;

        void Dfs(int node)
        {
            if (restrictedSet.Contains(node))
            {
                return;
            }

            if (!visited.Add(node))
            {
                return;
            }

            foreach (var neighbor in neighbors[node])
            {
                Dfs(neighbor);
            }
        }
    }
}
