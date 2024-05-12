using JetBrains.Annotations;

namespace LeetCode.Problems._1135_Connecting_Cities_With_Minimum_Cost;

/// <summary>
/// https://leetcode.com/submissions/detail/939771087/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinimumCost(int n, int[][] connections)
    {
        var graph = new EdgeWeightedGraph<int>();

        for (var i = 1; i <= n; i++)
        {
            graph.AddNode(i);
        }

        foreach (var connection in connections)
        {
            graph.AddEdge(new Edge<int>(connection[0], connection[1], connection[2]));
        }

        var mst = new PrimMinimumSpanningTree<int>(graph);

        if (!mst.IsConnected())
        {
            return -1;
        }

        return (int) mst.Weight();
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

        public IEnumerable<T> Nodes => _adjacentEdges.Keys;

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

    private class PrimMinimumSpanningTree<T> where T : notnull
    {
        private readonly EdgeWeightedGraph<T> _graph;
        private readonly HashSet<T> _marked = new();
        private readonly PriorityQueue<Edge<T>, double> _pq = new();
        private readonly double _weight;

        public PrimMinimumSpanningTree(EdgeWeightedGraph<T> graph)
        {
            _graph = graph;

            var node = graph.Nodes.First();
            Visit(graph, node);

            while (_pq.Count > 0)
            {
                var e = _pq.Dequeue();
                var v = e.Either();
                var w = e.Other(v);

                if (_marked.Contains(v) && _marked.Contains(w))
                {
                    continue;
                }

                _weight += e.Weight;

                if (!_marked.Contains(v))
                {
                    Visit(graph, v);
                }

                if (!_marked.Contains(w))
                {
                    Visit(graph, w);
                }
            }
        }

        private void Visit(EdgeWeightedGraph<T> graph, T node)
        {
            _marked.Add(node);

            foreach (var edge in graph.AdjacentEdges(node))
            {
                if (!_marked.Contains(edge.Other(node)))
                {
                    _pq.Enqueue(edge, edge.Weight);
                }
            }
        }

        public bool IsConnected() => _marked.Count == _graph.Nodes.Count();

        public double Weight() => _weight;
    }
}
