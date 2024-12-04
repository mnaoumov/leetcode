namespace LeetCode.Problems._2204_Distance_to_a_Cycle_in_Undirected_Graph;

/// <summary>
/// https://leetcode.com/submissions/detail/1467990362/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] DistanceToCycle(int n, int[][] edges)
    {
        var adjNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            var node1 = edge[0];
            var node2 = edge[1];
            adjNodes[node1].Add(node2);
            adjNodes[node2].Add(node1);
        }

        var path = new List<int>();
        var pathSet = new HashSet<int>();

        Dfs(0, 0);

        var cycle = path.SkipWhile(node => node != path.Last()).Skip(1).ToArray();

        var ans = Enumerable.Repeat(int.MaxValue, n).ToArray();

        var queue = new Queue<int>();

        foreach (var node in cycle)
        {
            queue.Enqueue(node);
        }

        var distance = 0;

        while (queue.Count > 0)
        {
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                if (ans[node] != int.MaxValue)
                {
                    continue;
                }
                ans[node] = distance;
                foreach (var adjNode in adjNodes[node])
                {
                    queue.Enqueue(adjNode);
                }
            }

            distance++;
        }

        return ans;

        bool Dfs(int node, int parent)
        {
            path.Add(node);

            if (!pathSet.Add(node))
            {
                return true;
            }

            if (adjNodes[node].Except(new[] { parent }).Any(adjNode => Dfs(adjNode, node)))
            {
                return true;
            }

            path.RemoveAt(path.Count - 1);
            pathSet.Remove(node);
            return false;
        }
    }
}
