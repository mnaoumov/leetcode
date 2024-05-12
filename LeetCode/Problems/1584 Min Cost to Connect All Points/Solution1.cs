using JetBrains.Annotations;

namespace LeetCode.Problems._1584_Min_Cost_to_Connect_All_Points;

/// <summary>
/// https://leetcode.com/submissions/detail/939773020/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int MinCostConnectPoints(int[][] points)
    {
        var graph = new EdgeWeightedGraph<int>();

        for (var i = 0; i < points.Length; i++)
        {
            var point1 = points[i];

            for (var j = i + 1; j < points.Length; j++)
            {
                var point2 = points[j];
                double weight = Math.Abs(point1[0] - point2[0]) + Math.Abs(point1[1] - point2[1]);
                graph.AddEdge(new Edge<int>(i, j, weight));
            }
        }

        var mst = new PrimMinimumSpanningTree<int>(graph);
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

        private void AddNode(T node) => _adjacentEdges.TryAdd(node, new HashSet<Edge<T>>());

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
        private readonly HashSet<T> _marked = new();
        private readonly PriorityQueue<Edge<T>, double> _pq = new();
        private readonly double _weight;

        public PrimMinimumSpanningTree(EdgeWeightedGraph<T> graph)
        {
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

        public double Weight() => _weight;
    }
}
