// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedType.Local
// ReSharper disable UnusedMember.Global

namespace LeetCode.Templates;

public static class TopologicalSortTemplate
{
    private sealed class TopologicalSort<T> where T : notnull
    {
        private readonly HashSet<T> _seen = new();
        private readonly HashSet<T> _processing = new();
        private readonly DirectedGraph<T> _graph;
        private readonly Stack<T> _order = new();

        public TopologicalSort(DirectedGraph<T> graph)
        {
            _graph = graph;
            IsAcyclic = true;

            foreach (var node in graph.Nodes)
            {
                if (_seen.Contains(node))
                {
                    continue;
                }

                if (Dfs(node))
                {
                    continue;
                }

                IsAcyclic = false;
                break;
            }
        }

        private bool Dfs(T node)
        {
            if (!_processing.Add(node))
            {
                return false;
            }

            if (!_seen.Add(node))
            {
                _processing.Remove(node);
                return true;
            }

            if (_graph.AdjacentNodes(node).Any(adjacentNode => !Dfs(adjacentNode)))
            {
                return false;
            }

            _order.Push(node);
            _processing.Remove(node);
            return true;
        }

        public bool IsAcyclic { get; }
        public IEnumerable<T> Order => IsAcyclic ? _order : Enumerable.Empty<T>();
    }

    private sealed class DirectedGraph<T> where T : notnull
    {
        private readonly Dictionary<T, List<T>> _adjacentNodes = new();

        public void AddEdge(T from, T to)
        {
            AddNode(from);
            AddNode(to);

            _adjacentNodes.TryAdd(from, new List<T>());
            _adjacentNodes[from].Add(to);
        }

        public IEnumerable<T> Nodes => _adjacentNodes.Keys;
        public List<T> AdjacentNodes(T node) => _adjacentNodes.GetValueOrDefault(node, new List<T>());
        public void AddNode(T node) => _adjacentNodes.TryAdd(node, new List<T>());
    }
}
