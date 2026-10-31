// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedType.Local
// ReSharper disable UnusedMember.Global

namespace LeetCode.Templates;

public static class PrimMinimumSpanningTreeTemplate
{
    // Undirected; add every node with AddNode, so a node with no edge still counts when checking IsConnected.
    public sealed class EdgeWeightedGraph<T> where T : notnull
    {
        private static readonly List<Edge<T>> NoEdges = [];
        private readonly Dictionary<T, List<Edge<T>>> _adjacentEdges = new();

        public void AddEdge(T node1, T node2, double weight)
        {
            AddNode(node1);
            AddNode(node2);
            _adjacentEdges[node1].Add(new Edge<T>(node1, node2, weight));
            _adjacentEdges[node2].Add(new Edge<T>(node2, node1, weight));
        }

        public void AddNode(T node) => _adjacentEdges.TryAdd(node, []);

        public IEnumerable<T> Nodes => _adjacentEdges.Keys;

        public int NodeCount => _adjacentEdges.Count;

        public IReadOnlyList<Edge<T>> AdjacentEdges(T node) => _adjacentEdges.GetValueOrDefault(node, NoEdges);
    }

    // Lazy Prim, O(E log E). Spans the component of the first node; IsConnected says whether that is every node.
    // For a dense graph given as points (every pair is an edge), the O(V^2) array version without a queue is faster.
    public sealed class PrimMinimumSpanningTree<T> where T : notnull
    {
        private readonly HashSet<T> _marked = new();
        private readonly List<Edge<T>> _edges = [];

        public PrimMinimumSpanningTree(EdgeWeightedGraph<T> graph)
        {
            NodeCount = graph.NodeCount;

            if (NodeCount == 0)
            {
                return;
            }

            var queue = new PriorityQueue<Edge<T>, double>();
            Visit(graph.Nodes.First());

            while (queue.Count > 0 && _marked.Count < NodeCount)
            {
                var edge = queue.Dequeue();

                if (_marked.Contains(edge.To))
                {
                    continue;
                }

                _edges.Add(edge);
                Weight += edge.Weight;
                Visit(edge.To);
            }

            return;

            void Visit(T node)
            {
                _marked.Add(node);

                foreach (var edge in graph.AdjacentEdges(node))
                {
                    if (!_marked.Contains(edge.To))
                    {
                        queue.Enqueue(edge, edge.Weight);
                    }
                }
            }
        }

        private int NodeCount { get; }

        public double Weight { get; }

        public IReadOnlyList<Edge<T>> Edges => _edges;

        public bool IsConnected => _marked.Count == NodeCount;
    }

    public sealed record Edge<T>(T From, T To, double Weight);
}
