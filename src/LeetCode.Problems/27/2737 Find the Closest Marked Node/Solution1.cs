namespace LeetCode.Problems._2737_Find_the_Closest_Marked_Node;

/// <summary>
/// https://leetcode.com/problems/find-the-closest-marked-node/submissions/1581843517/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumDistance(int n, IList<IList<int>> edges, int s, int[] marked)
    {
        var pq = new PriorityQueue<(int node, int distance), int>();
        pq.Enqueue((s, 0), 0);
        var nodeEdgesMap = Enumerable.Range(0, n).Select(_ => new List<Direction>()).ToArray();
        var markedSet = marked.ToHashSet();

        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            var w = edge[2];
            var edgeObj = new Direction(v, w);
            nodeEdgesMap[u].Add(edgeObj);
        }

        var minDistances = Enumerable.Repeat(int.MaxValue, n).ToArray();

        while (pq.Count > 0)
        {
            var (node, distance) = pq.Dequeue();

            if (minDistances[node] <= distance)
            {
                continue;
            }

            minDistances[node] = distance;

            if (markedSet.Contains(node))
            {
                return distance;
            }

            foreach (var edge in nodeEdgesMap[node])
            {
                var nextDistance = distance + edge.Weight;
                pq.Enqueue((edge.To, nextDistance), nextDistance);
            }
        }

        return -1;
    }

    private record Direction(int To, int Weight);
}
