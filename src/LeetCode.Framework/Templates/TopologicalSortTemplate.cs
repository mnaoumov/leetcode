// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedType.Local
// ReSharper disable UnusedMember.Global

namespace LeetCode.Templates;

public static class TopologicalSortTemplate
{
    public sealed class TopologicalSort<T> where T : notnull
    {
        private readonly List<T> _order = [];

        public TopologicalSort(DirectedGraph<T> graph)
        {
            var inDegrees = graph.Nodes.ToDictionary(node => node, _ => 0);

            foreach (var node in graph.Nodes)
            {
                foreach (var adjacentNode in graph.AdjacentNodes(node))
                {
                    inDegrees[adjacentNode]++;
                }
            }

            var ready = new Queue<T>(inDegrees.Where(pair => pair.Value == 0).Select(pair => pair.Key));

            while (ready.Count > 0)
            {
                var node = ready.Dequeue();
                _order.Add(node);

                foreach (var adjacentNode in graph.AdjacentNodes(node))
                {
                    if (--inDegrees[adjacentNode] == 0)
                    {
                        ready.Enqueue(adjacentNode);
                    }
                }
            }

            IsAcyclic = _order.Count == inDegrees.Count;
        }

        public bool IsAcyclic { get; }
        public IEnumerable<T> Order => IsAcyclic ? _order : Enumerable.Empty<T>();
    }

    public sealed class DirectedGraph<T> where T : notnull
    {
        private static readonly List<T> NoNodes = [];
        private readonly Dictionary<T, List<T>> _adjacentNodes = new();

        public void AddEdge(T from, T to)
        {
            AddNode(from);
            AddNode(to);
            _adjacentNodes[from].Add(to);
        }

        public IEnumerable<T> Nodes => _adjacentNodes.Keys;
        public IReadOnlyList<T> AdjacentNodes(T node) => _adjacentNodes.GetValueOrDefault(node, NoNodes);
        public void AddNode(T node) => _adjacentNodes.TryAdd(node, []);
    }
}
