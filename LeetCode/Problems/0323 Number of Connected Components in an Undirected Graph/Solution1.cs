namespace LeetCode.Problems._0323_Number_of_Connected_Components_in_an_Undirected_Graph;

/// <summary>
/// https://leetcode.com/submissions/detail/897903675/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountComponents(int n, int[][] edges)
    {
        var neighbors = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            neighbors[edge[0]].Add(edge[1]);
            neighbors[edge[1]].Add(edge[0]);
        }

        var result = 0;
        var nodes = Enumerable.Range(0, n).ToHashSet();

        while (nodes.Count > 0)
        {
            result++;
            var node = nodes.First();
            Dfs(node);
        }

        return result;

        void Dfs(int node)
        {
            if (!nodes.Remove(node))
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
