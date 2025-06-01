namespace LeetCode.Problems._3372_Maximize_the_Number_of_Target_Nodes_After_Connecting_Trees_I;

/// <summary>
/// https://leetcode.com/problems/maximize-the-number-of-target-nodes-after-connecting-trees-i/submissions/1646524439/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2, int k)
    {
        var adj1 = ToAdjList(edges1);
        var adj2 = ToAdjList(edges2);

        var counts1 = GetCounts(adj1, k);
        var counts2 = GetCounts(adj2, k - 1);
        var max2 = counts2.Max();

        return counts1.Select(count1 => count1 + max2).ToArray();
    }

    private static int[] GetCounts(List<int>[] adj, int k)
    {
        var n = adj.Length;
        var ans = new int[n];

        for (var i = 0; i < n; i++)
        {
            var queue = new Queue<int>();
            queue.Enqueue(i);
            var visited = new bool[n];
            var dist = 0;

            while (queue.Count > 0 && dist <= k)
            {
                var count = queue.Count;

                for (var j = 0; j < count; j++)
                {
                    var node = queue.Dequeue();
                    if (visited[node])
                    {
                        continue;
                    }
                    visited[node] = true;
                    ans[i]++;
                    var neighbors = adj[node];
                    foreach (var neighbor in neighbors.Where(neighbor => !visited[neighbor]))
                    {
                        queue.Enqueue(neighbor);
                    }
                }

                dist++;
            }
        }

        return ans;
    }

    private static List<int>[] ToAdjList(int[][] edges)
    {
        var n = edges.Length + 1;
        var ans = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            var a = edge[0];
            var b = edge[1];
            ans[a].Add(b);
            ans[b].Add(a);
        }

        return ans;
    }
}
