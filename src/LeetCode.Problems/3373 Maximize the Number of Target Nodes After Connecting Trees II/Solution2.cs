namespace LeetCode.Problems._3373_Maximize_the_Number_of_Target_Nodes_After_Connecting_Trees_II;

/// <summary>
/// https://leetcode.com/problems/maximize-the-number-of-target-nodes-after-connecting-trees-ii/submissions/1648065799/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2)
    {
        var adj1 = ToAdjList(edges1);
        var adj2 = ToAdjList(edges2);
        var n = adj1.Length;
        var m = adj2.Length;

        var evenDistanceNodes1 = GetEvenDistanceNodes(adj1).ToHashSet();
        var evenDistanceNodes2 = GetEvenDistanceNodes(adj2);
        var max2 = Math.Max(evenDistanceNodes2.Length, m - evenDistanceNodes2.Length);

        var ans = new int[n];

        for (var i = 0; i < n; i++)
        {
            var isEvenDistanceNode = evenDistanceNodes1.Contains(i);
            ans[i] = (isEvenDistanceNode ? evenDistanceNodes1.Count : n - evenDistanceNodes1.Count) + max2;
        }

        return ans;
    }

    private static int[] GetEvenDistanceNodes(List<int>[] adj)
    {
        var n = adj.Length;
        var list = new List<int>();

        var queue = new Queue<int>();
        queue.Enqueue(0);
        var visited = new bool[n];
        var isEvenDistance = true;

        while (queue.Count > 0)
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

                if (isEvenDistance)
                {
                    list.Add(node);
                }

                var neighbors = adj[node];
                foreach (var neighbor in neighbors.Where(neighbor => !visited[neighbor]))
                {
                    queue.Enqueue(neighbor);
                }
            }

            isEvenDistance = !isEvenDistance;
        }

        return list.ToArray();
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
