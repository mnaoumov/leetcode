namespace LeetCode.Problems._1245_Tree_Diameter;

/// <summary>
/// https://leetcode.com/submissions/detail/1182506686/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
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

        return Enumerable.Range(0, n).Max(Depth);

        int Depth(int startingNode)
        {
            var queue = new Queue<(int node, int parent)>();
            queue.Enqueue((startingNode, -1));

            var ans = -1;

            while (queue.Count > 0)
            {
                ans++;
                var count = queue.Count;

                for (var i = 0; i < count; i++)
                {
                    var (node, parent) = queue.Dequeue();

                    foreach (var adjNode in adjNodes[node].Except(new[] { parent }))
                    {
                        queue.Enqueue((adjNode, node));
                    }
                }
            }

            return ans;
        }
    }
}
