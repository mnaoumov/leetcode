namespace LeetCode.Problems._1971_Find_if_Path_Exists_in_Graph;

/// <summary>
/// https://leetcode.com/submissions/detail/861846464/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        var neighbors = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            neighbors[edge[0]].Add(edge[1]);
            neighbors[edge[1]].Add(edge[0]);
        }

        var visited = new bool[n];

        var queue = new Queue<int>();
        queue.Enqueue(source);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (node == destination)
            {
                return true;
            }

            if (visited[node])
            {
                continue;
            }

            visited[node] = true;

            foreach (var neighbor in neighbors[node])
            {
                queue.Enqueue(neighbor);
            }
        }

        return false;
    }
}
