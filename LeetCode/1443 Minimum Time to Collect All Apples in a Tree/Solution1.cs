using JetBrains.Annotations;

namespace LeetCode._1443_Minimum_Time_to_Collect_All_Apples_in_a_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/875855179/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinTime(int n, int[][] edges, IList<bool> hasApple)
    {
        var neighbors = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            neighbors[edge[0]].Add(edge[1]);
            neighbors[edge[1]].Add(edge[0]);
        }

        return 2 * Dfs(0, -1);

        int Dfs(int node, int parent)
        {
            var childSum = neighbors[node].Except(new[] { parent }).Sum(child => Dfs(child, node));
            return childSum + (node > 0 && (childSum != 0 || hasApple[node]) ? 1 : 0);
        }
    }
}
