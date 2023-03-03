using JetBrains.Annotations;

namespace LeetCode._2192_All_Ancestors_of_a_Node_in_a_Directed_Acyclic_Graph;

/// <summary>
/// https://leetcode.com/submissions/detail/906711937/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public IList<IList<int>> GetAncestors(int n, int[][] edges)
    {
        var result = Enumerable.Range(0, n).Select(_ => new HashSet<int>()).ToArray();
        var nextNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray<IList<int>>();
        var roots = Enumerable.Range(0, n).ToHashSet();

        foreach (var edge in edges)
        {
            nextNodes[edge[0]].Add(edge[1]);
            roots.Remove(edge[1]);
        }

        foreach (var root in roots)
        {
            Dfs(root, -1);
        }

        void Dfs(int node, int parent)
        {
            if (parent != -1)
            {
                result[node].UnionWith(result[parent]);
                result[node].Add(parent);
            }

            foreach (var next in nextNodes[node])
            {
                Dfs(next, node);
            }
        }

        return result.Select(set => set.OrderBy(x => x).ToArray()).ToArray<IList<int>>();
    }
}
