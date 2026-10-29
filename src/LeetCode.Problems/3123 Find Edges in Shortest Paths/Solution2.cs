using System.Collections.Immutable;

namespace LeetCode.Problems._3123_Find_Edges_in_Shortest_Paths;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-394/submissions/detail/1237870470/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool[] FindAnswer(int n, int[][] edges)
    {
        var m = edges.Length;

        var nodeEdgeIndicesMap = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        for (var index = 0; index < edges.Length; index++)
        {
            var edge = edges[index];
            var a = edge[0];
            var b = edge[1];
            nodeEdgeIndicesMap[a].Add(index);
            nodeEdgeIndicesMap[b].Add(index);
        }

        var queue = new Queue<(int node, int pathLength, ImmutableHashSet<int> edgeIndices)>();
        queue.Enqueue((0, 0, ImmutableHashSet<int>.Empty));

        var minPathLengths = Enumerable.Range(0, n).Select(_ => int.MaxValue).ToArray();
        var minPathEdgeIndices = new HashSet<int>();

        while (queue.Count > 0)
        {
            var (node, pathLength, edgeIndices) = queue.Dequeue();

            if (pathLength > minPathLengths[node])
            {
                continue;
            }

            if (node == n - 1)
            {
                if (pathLength < minPathLengths[node])
                {
                    minPathEdgeIndices.Clear();
                }

                minPathEdgeIndices.UnionWith(edgeIndices);
                minPathLengths[node] = pathLength;
                continue;
            }

            minPathLengths[node] = pathLength;

            foreach (var index in nodeEdgeIndicesMap[node])
            {
                var edge = edges[index];
                var a = edge[0];
                var b = edge[1];
                var w = edge[2];

                var adjNode = a == node ? b : a;

                queue.Enqueue((adjNode, pathLength + w, edgeIndices.Add(index)));
            }
        }

        return Enumerable.Range(0, m).Select(minPathEdgeIndices.Contains).ToArray();
    }
}
