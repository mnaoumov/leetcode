namespace LeetCode._2642_Design_Graph_With_Shortest_Path_Calculator;

/// <summary>
/// https://leetcode.com/submissions/detail/934240484/
/// </summary>
public class Graph6 : IGraph
{
    private readonly SortedSet<(int node, int cost)>[] _adjacentNodes;

    public Graph6(int n, IEnumerable<int[]> edges)
    {
        var comparer = Comparer<(int node, int cost)>.Create((x1, x2) =>
        {
            var result = x1.cost.CompareTo(x2.cost);
            return result != 0 ? result : x1.node.CompareTo(x2.node);
        });

        _adjacentNodes = Enumerable.Range(0, n).Select(_ => new SortedSet<(int node, int cost)>(comparer)).ToArray();

        foreach (var edge in edges)
        {
            AddEdge(edge);
        }
    }

    public void AddEdge(int[] edge) => _adjacentNodes[edge[0]].Add((node: edge[1], cost: edge[2]));

    public int ShortestPath(int node1, int node2)
    {
        if (node1 == node2)
        {
            return 0;
        }

        var minCosts = new Dictionary<(int node1, int node2), int>();

        var queue = new Queue<(int node, int pathCost)>();

        queue.Enqueue((node1, 0));

        var result = int.MaxValue;

        while (queue.Count > 0)
        {
            var (node, pathCost) = queue.Dequeue();

            if (pathCost > result)
            {
                continue;
            }

            if (node == node2)
            {
                result = Math.Min(result, pathCost);
                continue;
            }

            if (minCosts.GetValueOrDefault((node1, node), int.MaxValue) <= pathCost)
            {
                continue;
            }

            minCosts[(node1, node)] = pathCost;

            foreach (var (adjNode, cost) in _adjacentNodes[node])
            {
                queue.Enqueue((adjNode, pathCost + cost));
            }
        }

        if (result == int.MaxValue)
        {
            result = -1;
        }

        minCosts[(node1, node2)] = result;
        return result;
    }
}
