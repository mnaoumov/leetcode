namespace LeetCode.Problems._3373_Maximize_the_Number_of_Target_Nodes_After_Connecting_Trees_II;

/// <summary>
/// https://leetcode.com/problems/maximize-the-number-of-target-nodes-after-connecting-trees-ii/submissions/1647615108/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2)
    {
        var adj1 = ToAdjList(edges1);
        var adj2 = ToAdjList(edges2);
        var m = adj2.Length;

        var counts1 = GetEvenDistanceCounts(adj1);
        var counts2 = GetEvenDistanceCounts(adj2);
        var min2 = counts2.Min();

        return counts1.Select(count1 => count1 + m - min2).ToArray();
    }

    private static int[] GetEvenDistanceCounts(List<int>[] adj)
    {
        var n = adj.Length;
        var ans = new int[n];

        for (var i = 0; i < n; i++)
        {
            var queue = new Queue<int>();
            queue.Enqueue(i);
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
                        ans[i]++;
                    }

                    var neighbors = adj[node];
                    foreach (var neighbor in neighbors.Where(neighbor => !visited[neighbor]))
                    {
                        queue.Enqueue(neighbor);
                    }
                }

                isEvenDistance = !isEvenDistance;
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
