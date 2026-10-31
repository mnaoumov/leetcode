// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedType.Local
// ReSharper disable UnusedMember.Global

namespace LeetCode.Templates;

public static class DijkstraShortestPathTemplate
{
    public sealed class EdgeWeightedGraph<T> where T : notnull
    {
        private static readonly List<Edge<T>> NoEdges = [];
        private readonly Dictionary<T, List<Edge<T>>> _adjacentEdges = new();

        public void AddEdge(Edge<T> edge)
        {
            AddNode(edge.From);
            AddNode(edge.To);
            _adjacentEdges[edge.From].Add(edge);
        }

        public void AddUndirectedEdge(T node1, T node2, double weight)
        {
            AddEdge(new Edge<T>(node1, node2, weight));
            AddEdge(new Edge<T>(node2, node1, weight));
        }

        public void AddNode(T node) => _adjacentEdges.TryAdd(node, []);

        public IReadOnlyList<Edge<T>> AdjacentEdges(T node) => _adjacentEdges.GetValueOrDefault(node, NoEdges);
    }

    public sealed class DijkstraShortestPath<T> where T : notnull
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

                if (!marked.Add(v))
                {
                    continue;
                }

                var dv = DistanceTo(v);

                foreach (var (_, w, weight) in graph.AdjacentEdges(v))
                {
                    if (marked.Contains(w))
                    {
                        continue;
                    }

                    var dw2 = dv + weight;

                    if (dw2 >= DistanceTo(w))
                    {
                        continue;
                    }

                    _distances[w] = dw2;
                    unmarked.Enqueue(w, dw2);
                }
            }
        }

        public double DistanceTo(T target) => _distances.GetValueOrDefault(target, double.PositiveInfinity);
    }

    public sealed record Edge<T>(T From, T To, double Weight);
}
