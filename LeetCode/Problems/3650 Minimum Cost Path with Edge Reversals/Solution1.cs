namespace LeetCode.Problems._3650_Minimum_Cost_Path_with_Edge_Reversals;

/// <summary>
/// https://leetcode.com/problems/minimum-cost-path-with-edge-reversals/submissions/1898152425/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinCost(int n, int[][] edges)
    {
        var graph = new DirectedEdgeWeightedGraph<int>();

        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            var w = edge[2];
            graph.AddEdge(new DirectedEdge<int>(u, v, w));
            graph.AddEdge(new DirectedEdge<int>(v, u, 2 * w));
        }

        var sp = new DijkstraDirectedShortestPath<int>(graph, 0);
        var dist = sp.DistanceTo(n - 1);
        return double.IsPositiveInfinity(dist) ? -1 : (int) dist;
    }

    private class DijkstraDirectedShortestPath<T> where T : notnull
    {
        private readonly Dictionary<T, double> _distances = new();

        public DijkstraDirectedShortestPath(DirectedEdgeWeightedGraph<T> graph, T source)
        {
            _distances[source] = 0;
            var marked = new HashSet<T>();
            var unmarked = new PriorityQueue<T, double>();
            unmarked.Enqueue(source, 0);

            while (unmarked.Count > 0)
            {
                var v = unmarked.Dequeue();
                var dv = DistanceTo(v);

                foreach (var (_, w, weight) in graph.AdjacentEdges(v))
                {
                    if (marked.Contains(w))
                    {
                        continue;
                    }

                    var dw = DistanceTo(w);
                    var dw2 = dv + weight;

                    if (dw2 >= dw)
                    {
                        continue;
                    }

                    _distances[w] = dw2;
                    unmarked.Enqueue(w, dw2);
                }

                marked.Add(v);
            }
        }

        public double DistanceTo(T target) => _distances.GetValueOrDefault(target, double.PositiveInfinity);
    }

    private class DirectedEdgeWeightedGraph<T> where T : notnull
    {
        private readonly Dictionary<T, HashSet<DirectedEdge<T>>> _adjacentEdges = new();

        public void AddEdge(DirectedEdge<T> edge)
        {
            var v = edge.From;
            var w = edge.To;
            AddNode(v);
            AddNode(w);
            _adjacentEdges[v].Add(edge);
        }

        private void AddNode(T node) => _adjacentEdges.TryAdd(node, new HashSet<DirectedEdge<T>>());
        public IEnumerable<DirectedEdge<T>> AdjacentEdges(T node) => _adjacentEdges.GetValueOrDefault(node, new HashSet<DirectedEdge<T>>());
    }

    private record DirectedEdge<T>(T From, T To, double Weight);
}
