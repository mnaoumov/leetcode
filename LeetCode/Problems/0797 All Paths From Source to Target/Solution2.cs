namespace LeetCode.Problems._0797_All_Paths_From_Source_to_Target;

/// <summary>
/// https://leetcode.com/problems/all-paths-from-source-to-target/submissions/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        var n = graph.Length;
        var result = new List<IList<int>>();
        var path = new List<int>();
        var visited = new bool[n];
        Backtrack(0);

        return result;

        void Backtrack(int node)
        {
            path.Add(node);
            visited[node] = true;

            if (node == n - 1)
            {
                result.Add(path.ToList());
            }

            foreach (var neighbor in graph[node])
            {
                if (!visited[neighbor])
                {
                    Backtrack(neighbor);
                }
            }

            path.RemoveAt(path.Count - 1);
            visited[node] = false;
        }
    }
}
