namespace LeetCode.Problems._1928_Minimum_Cost_to_Reach_Destination_in_Time;

/// <summary>
/// https://leetcode.com/submissions/detail/941145521/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int MinCost(int maxTime, int[][] edges, int[] passingFees)
    {
        var n = passingFees.Length;

        var timeGraph = new EdgeWeightedGraph<int>();

        for (var i = 0; i < n; i++)
        {
            timeGraph.AddNode(i);
        }

        foreach (var edge in edges)
        {
            timeGraph.AddEdge(new Edge<int>(edge[0], edge[1], edge[2]));
        }

        var feeGraph = new DirectedEdgeWeightedGraph<int>();

        const int beforeStartCity = -1;

        feeGraph.AddNode(beforeStartCity);

        var visited = new HashSet<int>();

        Dfs(0, 0, beforeStartCity);

        var sp = new DijkstraDirectedShortestPath<int>(feeGraph, beforeStartCity);
        var distance = sp.DistanceTo(n - 1);
        return double.IsPositiveInfinity(distance) ? -1 : (int) distance;

        void Dfs(int city, int time, int previousCity)
        {
            if (time > maxTime)
            {
                return;
            }

            if (!visited.Add(city))
            {
                return;
            }

            feeGraph.AddEdge(new DirectedEdge<int>(previousCity, city, passingFees[city]));

            foreach (var road in timeGraph.AdjacentEdges(city))
            {
                Dfs(road.Other(city), time + (int) road.Weight, city);
            }
        }
    }

    private record DirectedEdge<T>(T From, T To, double Weight);

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

        public void AddNode(T node) => _adjacentEdges.TryAdd(node, new HashSet<DirectedEdge<T>>());
        public IEnumerable<DirectedEdge<T>> AdjacentEdges(T node) => _adjacentEdges.GetValueOrDefault(node, new HashSet<DirectedEdge<T>>());
    }

    private class EdgeWeightedGraph<T> where T : notnull
    {
        private readonly Dictionary<T, HashSet<Edge<T>>> _adjacentEdges = new();

        public void AddEdge(Edge<T> edge)
        {
            var v = edge.Either();
            var w = edge.Other(v);
            AddNode(v);
            AddNode(w);
            _adjacentEdges[v].Add(edge);
            _adjacentEdges[w].Add(edge);
        }

        public void AddNode(T node) => _adjacentEdges.TryAdd(node, new HashSet<Edge<T>>());
        public IEnumerable<Edge<T>> AdjacentEdges(T node) => _adjacentEdges.GetValueOrDefault(node, new HashSet<Edge<T>>());
    }

    private record Edge<T>(T Node1, T Node2, double Weight)
    {
        public T Either() => Node1;

        public T Other(T node)
        {
            if (Equals(node, Node1))
            {
                return Node2;
            }

            if (Equals(node, Node2))
            {
                return Node1;
            }

            throw new InvalidOperationException();
        }
    }

    private class DijkstraDirectedShortestPath<T> where T : notnull
    {
        private readonly Dictionary<T, double> _distances = new();

        public DijkstraDirectedShortestPath(DirectedEdgeWeightedGraph<T> graph, T source)
        {
            _distances[source] = 0;
            var marked = new HashSet<T>();
            var unmarked = new HashSet<T> { source };

            while (unmarked.Count > 0)
            {
                var v = unmarked.MinBy(node => _distances[node])!;
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
                    unmarked.Add(w);
                }

                marked.Add(v);
                unmarked.Remove(v);
            }
        }

        public double DistanceTo(T target) => _distances.GetValueOrDefault(target, double.PositiveInfinity);
    }
}
