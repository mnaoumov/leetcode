using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3203_Find_Minimum_Diameter_After_Merging_Two_Trees;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-404/submissions/detail/1304447663/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinimumDiameterAfterMerge(int[][] edges1, int[][] edges2)
    {
        var diameter1= TreeDiameter(edges1);
        var diameter2 = TreeDiameter(edges2);

        return 1 + (diameter1 + 1) / 2 + (diameter2 + 1) / 2;
    }

    private static int TreeDiameter(int[][] edges)
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
