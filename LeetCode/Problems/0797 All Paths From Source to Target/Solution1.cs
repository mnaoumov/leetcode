using JetBrains.Annotations;

namespace LeetCode.Problems._0797_All_Paths_From_Source_to_Target;

/// <summary>
/// https://leetcode.com/submissions/detail/868286764/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        var n = graph.Length;
        var result = new List<IList<int>>();
        var path = new List<int>();
        var visited = new bool[n];
        Dfs(0);

        return result;

        void Dfs(int node)
        {
            if (visited[node])
            {
                return;
            }

            path.Add(node);
            visited[node] = true;

            if (node == n - 1)
            {
                result.Add(path.ToList());
            }
            else
            {
                foreach (var neighbor in graph[node])
                {
                    Dfs(neighbor);
                }
            }

            path.RemoveAt(path.Count - 1);
            visited[node] = false;
        }
    }
}
