using JetBrains.Annotations;

namespace LeetCode._2050_Parallel_Courses_III;

/// <summary>
/// https://leetcode.com/submissions/detail/1077985941/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumTime(int n, int[][] relations, int[] time)
    {
        var graph = new DirectedGraph<int>();

        for (var i = 1; i <=n; i++)
        {
            graph.AddNode(i);
        }

        foreach (var relation in relations)
        {
            graph.AddEdge(relation[0], relation[1]);
        }

        var ts = new TopologicalSort<int>(graph);

        var ans = 0;
        var minimumTimes = new int[n + 1];

        foreach (var node in ts.Order)
        {
            minimumTimes[node] =
                graph.PreviousNodes(node).Select(previousNode => minimumTimes[previousNode]).Append(0).Max() +
                time[node - 1];
            ans = Math.Max(ans, minimumTimes[node]);
        }

        return ans;
    }

    private class TopologicalSort<T> where T : notnull
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

        private bool IsAcyclic { get; }
        public IEnumerable<T> Order => IsAcyclic ? _order : Enumerable.Empty<T>();
    }

    private class DirectedGraph<T> where T : notnull
    {
        private readonly Dictionary<T, List<T>> _adjacentNodes = new();
        private readonly Dictionary<T, List<T>> _previousNodes = new();

        public void AddEdge(T from, T to)
        {
            AddNode(from);
            AddNode(to);

            _adjacentNodes.TryAdd(from, new List<T>());
            _adjacentNodes[from].Add(to);

            _previousNodes.TryAdd(to, new List<T>());
            _previousNodes[to].Add(from);
        }

        public IEnumerable<T> Nodes => _adjacentNodes.Keys;
        public IEnumerable<T> AdjacentNodes(T node) => _adjacentNodes.GetValueOrDefault(node, new List<T>());
        public IEnumerable<T> PreviousNodes(T node) => _previousNodes.GetValueOrDefault(node, new List<T>());
        public void AddNode(T node) => _adjacentNodes.TryAdd(node, new List<T>());
    }
}
