using JetBrains.Annotations;

namespace LeetCode.Problems._1489_Find_Critical_and_Pseudo_Critical_Edges_in_Minimum_Spanning_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/940761304/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> FindCriticalAndPseudoCriticalEdges(int n, int[][] edges)
    {
        var graph = CreateGraph((_, edge) => edge);
        var mst = new PrimMinimumSpanningTree<int>(graph);

        var criticalEdges = new List<int>();
        var pseudoCriticalEdges = new List<int>();

        if (!mst.IsConnected())
        {
            return new IList<int>[] { criticalEdges, pseudoCriticalEdges };
        }

        var weight = (int) mst.Weight();

        for (var i = 0; i < edges.Length; i++)
        {
            var i2 = i;
            graph = CreateGraph((j, edge) => j == i2 ? null : edge);
            mst = new PrimMinimumSpanningTree<int>(graph);

            if (!mst.IsConnected() || mst.Weight() > weight)
            {
                criticalEdges.Add(i);
            }
            else
            {
                graph = CreateGraph((j, edge) => j == i2 ? edge with { Weight = 0 } : edge);
                mst = new PrimMinimumSpanningTree<int>(graph);

                if ((int) mst.Weight() + edges[i][2] == weight)
                {
                    pseudoCriticalEdges.Add(i);
                }
            }
        }

        return new IList<int>[] { criticalEdges, pseudoCriticalEdges };

        EdgeWeightedGraph<int> CreateGraph(Func<int, Edge<int>, Edge<int>?> modifyEdgeFunc)
        {
            graph = new EdgeWeightedGraph<int>();

            for (var k = 0; k < n; k++)
            {
                graph.AddNode(k);
            }

            for (var j = 0; j < edges.Length; j++)
            {
                var edgeArr = edges[j];
                var edge = new Edge<int>(edgeArr[0], edgeArr[1], edgeArr[2]);

                var newEdge = modifyEdgeFunc(j, edge);

                if (newEdge != null)
                {
                    graph.AddEdge(newEdge);
                }
            }

            return graph;
        }
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
