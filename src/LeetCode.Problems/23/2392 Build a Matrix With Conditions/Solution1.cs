namespace LeetCode.Problems._2392_Build_a_Matrix_With_Conditions;

/// <summary>
/// https://leetcode.com/submissions/detail/1328911633/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int[][] BuildMatrix(int k, int[][] rowConditions, int[][] colConditions)
    {
        var rowConditionsTs = new TopologicalSort<int>(BuildGraph(rowConditions));
        var colConditionsTs = new TopologicalSort<int>(BuildGraph(colConditions));

        if (!rowConditionsTs.IsAcyclic || !colConditionsTs.IsAcyclic)
        {
            return Array.Empty<int[]>();
        }

        var valueRowIndexMap = GetValueIndexMap(rowConditionsTs);
        var valueColIndexMap = GetValueIndexMap(colConditionsTs);

        var ans = Enumerable.Range(0, k).Select(_ => new int[k]).ToArray();

        for (var i = 1; i <= k; i++)
        {
            var rowIndex = valueRowIndexMap[i];
            var colIndex = valueColIndexMap[i];
            ans[rowIndex][colIndex] = i;
        }

        return ans;
    }

    private static Dictionary<int, int> GetValueIndexMap(TopologicalSort<int> ts) => ts.Order
        .Select((num, index) => (num, index))
        .ToDictionary(x => x.num, x => x.index);

    private static DirectedGraph<int> BuildGraph(int[][] conditions)
    {
        var graph = new DirectedGraph<int>();

        foreach (var condition in conditions)
        {
            var before = condition[0];
            var after = condition[1];
            graph.AddEdge(before, after);
        }

        return graph;
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
        private void AddNode(T node) => _adjacentNodes.TryAdd(node, new List<T>());
    }
}
