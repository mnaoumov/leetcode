using JetBrains.Annotations;

namespace LeetCode.Problems._1203_Sort_Items_by_Groups_Respecting_Dependencies;

/// <summary>
/// https://leetcode.com/submissions/detail/939755815/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] SortItems(int n, int m, int[] group, IList<IList<int>> beforeItems)
    {
        var groupsGraph = new DirectedGraph<int>();
        var graphs = Enumerable.Range(0, m).Select(_ => new DirectedGraph<int>()).ToArray();

        for (var i = 0; i < n; i++)
        {
            var groupId = GroupId(i);
            groupsGraph.AddNode(groupId);

            if (groupId >= 0)
            {
                graphs[groupId].AddNode(i);
            }

            foreach (var j in beforeItems[i])
            {
                var otherGroupId = GroupId(j);

                if (otherGroupId == groupId)
                {
                    graphs[groupId].AddEdge(j, i);
                }
                else
                {
                    groupsGraph.AddEdge(otherGroupId, groupId);
                }
            }
        }

        var ts = new TopologicalSort<int>(groupsGraph);

        if (!ts.IsAcyclic)
        {
            return Array.Empty<int>();
        }

        var ans = new List<int>();

        foreach (var groupId in ts.Order)
        {
            if (groupId < 0)
            {
                ans.Add(-1 - groupId);
            }
            else
            {
                ts = new TopologicalSort<int>(graphs[groupId]);

                if (!ts.IsAcyclic)
                {
                    return Array.Empty<int>();
                }

                ans.AddRange(ts.Order);
            }
        }

        return ans.ToArray();

        int GroupId(int i)
        {
            var g = group[i];
            return g == -1 ? -1 - i : g;
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

        public IEnumerable<T> Nodes => _adjacentNodes.Keys;
        public IEnumerable<T> AdjacentNodes(T node) => _adjacentNodes.GetValueOrDefault(node, new List<T>());
        public void AddNode(T node) => _adjacentNodes.TryAdd(node, new List<T>());
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

        public bool IsAcyclic { get; }
        public IEnumerable<T> Order => IsAcyclic ? _order : Enumerable.Empty<T>();
    }
}
