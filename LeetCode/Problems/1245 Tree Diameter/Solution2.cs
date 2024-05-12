using JetBrains.Annotations;

namespace LeetCode.Problems._1245_Tree_Diameter;

/// <summary>
/// https://leetcode.com/submissions/detail/1182510470/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int TreeDiameter(int[][] edges)
    {
        var n = edges.Length + 1;
        var adjNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            adjNodes[edge[0]].Add(edge[1]);
            adjNodes[edge[1]].Add(edge[0]);
        }

        var (_, b) = Bfs(0);
        var (ans, _) = Bfs(b);
        return ans;

        (int depth, int deepestNode) Bfs(int startingNode)
        {
            var queue = new Queue<(int node, int parent)>();
            queue.Enqueue((startingNode, -1));

            var deepestNode = -1;
            var depth = -1;

            while (queue.Count > 0)
            {
                depth++;
                var count = queue.Count;

                for (var i = 0; i < count; i++)
                {
                    var (node, parent) = queue.Dequeue();
                    deepestNode = node;

                    foreach (var adjNode in adjNodes[node].Except(new[] { parent }))
                    {
                        queue.Enqueue((adjNode, node));
                    }
                }
            }

            return (depth, deepestNode);
        }
    }
}
