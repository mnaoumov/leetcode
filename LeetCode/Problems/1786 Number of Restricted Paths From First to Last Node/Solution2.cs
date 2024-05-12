using JetBrains.Annotations;

namespace LeetCode.Problems._1786_Number_of_Restricted_Paths_From_First_to_Last_Node;

/// <summary>
/// https://leetcode.com/submissions/detail/969772489/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int CountRestrictedPaths(int n, int[][] edges)
    {
        var graph = new EdgeWeightedGraph<int>();

        for (var i = 1; i <= n; i++)
        {
            graph.AddNode(i);
        }

        foreach (var edge in edges)
        {
            graph.AddEdge(new Edge<int>(edge[0], edge[1], edge[2]));
        }

        var sp = new DijkstraShortestPath<int>(graph, n);

        var directedGraph = new DirectedGraph<int>();

        foreach (var (node1, node2, _) in graph.Edges)
        {
            var d1 = sp.DistanceTo(node1);
            var d2 = sp.DistanceTo(node2);

            if (d1 > d2)
            {
                directedGraph.AddEdge(node1, node2);
            }
            else if (d1 < d2)
            {
                directedGraph.AddEdge(node2, node1);
            }
        }

        const int modulo = 1_000_000_007;

        var dp = new DynamicProgramming<int, int>((node, recursiveFunc) =>
        {
            return node == n
                ? 1
                : directedGraph.AdjacentNodes(node)
                    .Aggregate(0, (current, adj) => (current + recursiveFunc(adj)) % modulo);
        });

        return dp.GetOrCalculate(1);
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }

    private class EdgeWeightedGraph<T> where T : notnull
    {
        private readonly Dictionary<T, HashSet<Edge<T>>> _adjacentEdges = new();
        private readonly HashSet<Edge<T>> _edges = new();

        public void AddEdge(Edge<T> edge)
        {
            var v = edge.Either();
            var w = edge.Other(v);
            AddNode(v);
            AddNode(w);
            _adjacentEdges[v].Add(edge);
            _adjacentEdges[w].Add(edge);
            _edges.Add(edge);
        }

        public void AddNode(T node) => _adjacentEdges.TryAdd(node, new HashSet<Edge<T>>());

        public IEnumerable<Edge<T>> AdjacentEdges(T node) => _adjacentEdges.GetValueOrDefault(node, new HashSet<Edge<T>>());

        public IEnumerable<Edge<T>> Edges => _edges;
    }

    private class DijkstraShortestPath<T> where T : notnull
    {
        private readonly Dictionary<T, double> _distances = new();

        public DijkstraShortestPath(EdgeWeightedGraph<T> graph, T source)
        {
            _distances[source] = 0;
            var marked = new HashSet<T>();
            var unmarked = new PriorityQueue<T, double>();
            unmarked.Enqueue(source, 0);

            while (unmarked.Count > 0)
            {
                var v = unmarked.Dequeue();
                var dv = DistanceTo(v);

                foreach (var adjEdge in graph.AdjacentEdges(v))
                {
                    var w = adjEdge.Other(v);

                    if (marked.Contains(w))
                    {
                        continue;
                    }

                    var dw = DistanceTo(w);
                    var dw2 = dv + adjEdge.Weight;

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

    private class DirectedGraph<T> where T : notnull
    {
        private readonly Dictionary<T, List<T>> _adjacentNodes = new();

        public void AddEdge(T from, T to)
        {
            AddNode(from);
            AddNode(to);

            _adjacentNodes.TryAdd(from, new List<T>());
            _adjacentNodes[from].Add(to);
        }

        public IEnumerable<T> AdjacentNodes(T node) => _adjacentNodes.GetValueOrDefault(node, new List<T>());
        private void AddNode(T node) => _adjacentNodes.TryAdd(node, new List<T>());
    }
}
