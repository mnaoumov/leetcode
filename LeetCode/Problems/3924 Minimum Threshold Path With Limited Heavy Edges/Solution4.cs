using System.Collections.Immutable;

namespace LeetCode.Problems._3924_Minimum_Threshold_Path_With_Limited_Heavy_Edges;

/// <summary>
/// https://leetcode.com/problems/minimum-threshold-path-with-limited-heavy-edges/submissions/1999236945/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution4 : ISolution
{
    public int MinimumThreshold(int n, int[][] edges, int source, int target, int k)
    {
        if (source == target)
        {
            return 0;
        }

        if (edges.Length == 0)
        {
            return -1;
        }

        var edgeObjs = edges.Select(arr => new Edge(arr[0], arr[1], arr[2])).ToArray();
        var nodeEdgesMap = Enumerable.Range(0, n).Select(_ => new List<Edge>()).ToArray();

        foreach (var edge in edgeObjs)
        {
            nodeEdgesMap[edge.U].Add(edge);
            nodeEdgesMap[edge.V].Add(edge);
        }

        var low = 0;
        var high = edgeObjs.Max(e => e.Weight);

        if (!HasPath(high))
        {
            return -1;
        }

        while (low <= high)
        {
            var mid = (low + high) / 2;

            if (HasPath(mid))
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;


        bool HasPath(int threshold)
        {
            var queue = new Queue<(int node, ImmutableHashSet<int> visitedNodes, int heavyEdgeCount)>();
            queue.Enqueue((source, ImmutableHashSet<int>.Empty, 0));

            while (queue.Count > 0)
            {
                var (node, visitedNodes, heavyEdgeCount) = queue.Dequeue();

                if (node == target)
                {
                    return true;
                }

                foreach (var edge in nodeEdgesMap[node])
                {
                    var other = edge.Other(node);

                    if (visitedNodes.Contains(other))
                    {
                        continue;
                    }

                    if (edge.Weight <= threshold)
                    {
                        queue.Enqueue((other, visitedNodes.Add(node), heavyEdgeCount));
                    }
                    else if (heavyEdgeCount < k)
                    {
                        queue.Enqueue((other, visitedNodes.Add(node), heavyEdgeCount + 1));
                    }
                }
            }

            return false;
        }
    }

    private sealed record Edge(int U, int V, int Weight)
    {
        public int Other(int node)
        {
            if (node == U)
            {
                return V;
            }

            if (node == V)
            {
                return U;
            }

            throw new ArgumentException("Wrong node", nameof(node));
        }
    }
}
